using StalkerSimulation.Environment;

namespace StalkerSimulation.Npc
{
	public interface INpcController
	{
		public IAnimationController AnimationController { get; }
		public INpcMovementController MovementController { get; }
		public ICheckPoint CurrentCheckPoint { get; }    
		public OrderData OrderData { get; }
		public INpcState CurrentState { get; }

		public void SetChekPoint(ICheckPoint checkPoint);
		public void SetOrder(OrderData orderData);
		public bool ChangeState<T>() where T : NpcState;
		public void Destroy();
	}
}