using UnityEngine;

namespace StalkerSimulation.Npc
{
	public class AttackState : NpcState
	{
		private readonly AttackStateData _stateData;

		private AttackStrategy _attackStrategy;
		
		public override float AlertRadius => _stateData.AlertRadius;

		public AttackState(AttackStateData stateData)
		{
			_stateData = stateData;

			_attackStrategy = new BurstAttackStrategy(
				_stateData.ShootingRange, 
				_stateData.ShootingDelayRange);
		}
		
		public override void EnterState()
		{
			if (_npcController.OrderData is AttackOrderData attackOrderData)
			{
				INpcController enemyToAttack = attackOrderData.TargetToAttack;
				
				_npcController.Aim(enemyToAttack.Transform);
			}
		}

		public override void Act()
		{
			if (_npcController.OrderData is AttackOrderData attackOrderData)
			{
				if (attackOrderData.TargetToAttack.HealthController.IsAlive && IsAimedAtTarget(attackOrderData.TargetToAttack.Transform))
				{
					if (!_attackStrategy.IsShooting)
					{
						_attackStrategy.StartShooting(_npcController.Weapon);
					}
				}
			}
		}

		public override void ExitState()
		{
			_attackStrategy.StopShooting();
			_npcController.Aim(null);
		}

		private bool IsAimedAtTarget(Transform target)
		{
			Vector3 directionToTarget = target.position - _npcController.Weapon.Muzzle.position;
			float angle = Vector3.Angle(_npcController.Weapon.Muzzle.forward, directionToTarget);

			return angle <= 1f;
		}
	}
}