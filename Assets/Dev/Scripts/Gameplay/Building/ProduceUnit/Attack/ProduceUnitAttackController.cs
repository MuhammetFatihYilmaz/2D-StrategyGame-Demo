using StrategyGame.Events;
using StrategyGame.Gameplay.GameInput;
using StrategyGame.Gameplay.GameInput.UnitAttacking;
using StrategyGame.Gameplay.Health;
using StrategyGame.Management.ObjectPoolManagement;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace StrategyGame.Gameplay.Building.ProduceUnit
{
    public class ProduceUnitAttackController : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private LayerMask attackLayermask;
        private AttackableProduceUnitSO attackableProduceUnitSO;
        private RuntimeUnitAttackingInputDataSO runtimeUnitAttackingInputDataSO;

        private IEnumerator currentAttackEnemySeq;
        private bool isAttackDetectSequenceStarted;
        private bool isPositionCanAttack;
        private bool isAttackWaiterActive;
        private float enemyDistance;

        private void Awake()
        {
            var allRuntimeInputDataSO = ObjectPoolManager.Instance.PullScriptable<AllGameRuntimeInputDataSO>();
            runtimeUnitAttackingInputDataSO = allRuntimeInputDataSO.RuntimeUnitAttackingInputDataSO;
        }

        public void Initialize(ProduceUnitBaseSO produceUnitSO)
        {
            this.attackableProduceUnitSO = produceUnitSO as AttackableProduceUnitSO;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            StartAttackDetection();
        }

        private void StartAttackDetection()
        {
            if (isAttackDetectSequenceStarted) return;
            StartCoroutine(AttackDetectSequence());
        }

        private IEnumerator AttackDetectSequence()
        {
            isAttackDetectSequenceStarted = true;
            GameEvents.GameplayEvents.OnProduceUnitAttackDetectingStarted?.Invoke();

            while (isAttackDetectSequenceStarted)
            {

                isPositionCanAttack = IsCursorOnEnemy();

                if (runtimeUnitAttackingInputDataSO.AttackingApplyTrigger && !isPositionCanAttack)
                {
                    GameEvents.GameplayEvents.OnProduceUnitAttackDetectingDenied?.Invoke();
                }

                if (runtimeUnitAttackingInputDataSO.AttackingApplyTrigger && isPositionCanAttack)
                {
                    if (currentAttackEnemySeq != null) StopCoroutine(currentAttackEnemySeq);

                    currentAttackEnemySeq = AttackEnemy();
                    StartCoroutine(currentAttackEnemySeq);
                    isAttackDetectSequenceStarted = false;
                }

                if (runtimeUnitAttackingInputDataSO.AttackingCancelTrigger)
                {
                    isAttackDetectSequenceStarted = false;
                }

                yield return new WaitForEndOfFrame();
            }

            GameEvents.GameplayEvents.OnProduceUnitAttackDetectingEnded?.Invoke();
            isAttackDetectSequenceStarted = false;
        }

        private IEnumerator AttackEnemy()
        {
            RaycastHit2D hit = Physics2D.Raycast(runtimeUnitAttackingInputDataSO.AttackingIndicatorPos, Vector2.zero, 1f, attackLayermask);
            if (hit.collider != null)
            {
                enemyDistance = Vector2.Distance(transform.position, hit.point);
                StartCoroutine(ActiveAttackWaiter());
                yield return new WaitUntil(() => (enemyDistance < 3f) || !isAttackWaiterActive);

                hit.collider.TryGetComponent(out ITakeDamage enemy);
                if (enemy == null) yield break;
                MakeAttack(enemy);
            }
        }

        private IEnumerator ActiveAttackWaiter()
        {
            float t = 0f;
            isAttackWaiterActive = true;
            while (t < (enemyDistance / 2))
            {
                t += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            isAttackWaiterActive = false;
        }

        private void MakeAttack(ITakeDamage enemy)
        {
            if (attackableProduceUnitSO.GivenDamageType == DamageType.PhysicalDamage)
                enemy.TakeDamage(new PhysicalDamage() { DamageAmount = attackableProduceUnitSO.DamageAmount });
            else
                enemy.TakeDamage(new MagicalDamage() { DamageAmount = attackableProduceUnitSO.DamageAmount });
        }

        private bool IsCursorOnEnemy()
        {
            RaycastHit2D hit = Physics2D.Raycast(runtimeUnitAttackingInputDataSO.AttackingIndicatorPos, Vector2.zero, 1f, attackLayermask);
            if (hit.collider != null) return true;

            return false;
        }
    }
}
