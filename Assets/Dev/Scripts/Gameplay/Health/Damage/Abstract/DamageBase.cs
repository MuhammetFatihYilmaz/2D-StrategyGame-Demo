namespace StrategyGame.Gameplay.Health
{
    public abstract class DamageBase
    {
        public int DamageAmount;
        public abstract DamageType GivenDamageType { get; }
    }
}
