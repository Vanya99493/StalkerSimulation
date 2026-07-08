using DG.Tweening;
using StalkerSimulation.Weapon;

namespace StalkerSimulation.Npc
{
	public abstract class AttackStrategy
	{
		protected FloatRange _shootingDelayRange;
		
		protected Tween _shootingTween;
		
		public bool IsShooting { get; protected set; }
		
		public AttackStrategy(FloatRange shootingDelayRange)
		{
			_shootingDelayRange = shootingDelayRange;
		}

		public abstract void StartShooting(IWeapon weapon);
		public abstract void StopShooting();
	}
}