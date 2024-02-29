using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StrategyGame.UI.Tools
{
    public class InfiniteScroll : MonoBehaviour
    {
        [SerializeField] private GridLayoutGroup gridLayoutGroup;
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField] private RectTransform minEdgePosition;
        [SerializeField] private RectTransform maxEdgePosition;
        private List<RectTransform> contentItemList = new();
        public Vector2 contentItemMovementValue;

        public void Initialize(List<RectTransform> contentItemList)
        {
            scrollRect.movementType = ScrollRect.MovementType.Clamped;
            this.contentItemList = contentItemList;
            StartCoroutine(SetScrollPropertiesSeq());
        }

        private IEnumerator SetScrollPropertiesSeq()
        {
            yield return new WaitForEndOfFrame();
            contentItemMovementValue = (scrollRect.content.sizeDelta * Vector2.up) * 2f;
            scrollRect.movementType = ScrollRect.MovementType.Unrestricted;
            scrollRect.onValueChanged.AddListener(ScrollMovement);
            gridLayoutGroup.enabled = false;
        }

        private void OnDisable()
        {
            scrollRect.onValueChanged.RemoveListener(ScrollMovement);
        }

        private void ScrollMovement(Vector2 pos)
        {
            if (contentItemList.Count < 0) return;

            if (scrollRect.velocity.y > 0)
            {
                foreach (var item in contentItemList)
                {
                    if (item.transform.position.y > minEdgePosition.position.y + item.sizeDelta.y)
                        item.anchoredPosition -= contentItemMovementValue;
                }
            }
            else if (scrollRect.velocity.y < 0)
            {
                foreach (var item in contentItemList)
                {
                    if (item.transform.position.y < maxEdgePosition.position.y - item.sizeDelta.y)
                        item.anchoredPosition += contentItemMovementValue;
                }
            }
        }
    }
}



