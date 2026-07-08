namespace StalkerSimulation.Npc
{
	public interface IHealthController
	{
		public int MaxHealth { get; }
		public int CurrentHealth { get; }
		public bool IsAlive { get; }
		
		public void TakeDamage(DamageArgs damageArgs);
	}
}