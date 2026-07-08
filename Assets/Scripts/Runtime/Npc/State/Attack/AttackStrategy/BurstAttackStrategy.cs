using DG.Tweening;
using StalkerSimulation.Extensions;
using StalkerSimulation.Weapon;

namespace StalkerSimulation.Npc
{
	public class BurstAttackStrategy : AttackStrategy
	{
		protected FloatRange _shootingRange;

		private IWeapon _weaponBase;
		
		public BurstAttackStrategy(FloatRange shootingRange, FloatRange shootingDelayRange) : base(shootingDelayRange)
		{
			_shootingRange = shootingRange;
		}

		public override void StartShooting(IWeapon weapon)
		{
			_weaponBase = weapon;
			
			IsShooting = true;
			Shoot();
		}

		public override void StopShooting()
		{
			IsShooting = false;
			_weaponBase.SetTriggerHold(false);
			_shootingTween?.Kill();
		}

		private void Shoot()
		{
			if (!IsShooting)
			{
				_weaponBase.SetTriggerHold(false);
				return;
			}
			
			_weaponBase.SetTriggerHold(true);
			
			_shootingTween?.Kill();
			_shootingTween.To(
				_shootingRange.Random(), 
				onCompleteCallback: Wait);
		}

		private void Wait()
		{
			if (!IsShooting)
			{
				_weaponBase.SetTriggerHold(false);
				return;
			}
			
			_weaponBase.SetTriggerHold(false);
			
			_shootingTween?.Kill();
			_shootingTween.To(
				_shootingDelayRange.Random(), 
				onCompleteCallback: Shoot);
		}
	}
}