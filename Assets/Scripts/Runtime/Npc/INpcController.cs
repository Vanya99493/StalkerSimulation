using StalkerSimulation.Environment;
using StalkerSimulation.Weapon;
using UnityEngine;

namespace StalkerSimulation.Npc
{
	public interface INpcController
	{
		public IAnimationController AnimationController { get; }
		public INpcMovementController MovementController { get; }
		public IHealthController HealthController { get; }
		public IWeapon Weapon { get; }
		public NpcData NpcData { get; }
		public ICheckPoint CurrentCheckPoint { get; }
		public OrderData OrderData { get; }
		public INpcState CurrentState { get; }
		
		public Transform Transform { get; }
		public Vector3 EyePosition { get; }

		public void SetChekPoint(ICheckPoint checkPoint);
		public void SetOrder(OrderData orderData);
		public void Aim(Transform aimTransform);
		public bool ChangeState<T>() where T : NpcState;
		public void Destroy();
	}
}