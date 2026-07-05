using StalkerSimulation.Environment;

namespace StalkerSimulation.Npc
{
	public interface INpcController
	{
		public INpcMovementController MovementController { get; }
		public ICheckPoint CurrentCheckPoint { get; }    
		public OrderData OrderData { get; }

		public void SetChekPoint(ICheckPoint checkPoint);
		public void SetOrder(OrderData orderData);
		public bool ChangeState<T>() where T : NpcState;
	}
}