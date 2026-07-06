namespace StalkerSimulation.Npc
{
	public class HoldState : NpcState
	{
		private readonly StateData _stateData;

		public override float AlertRadius => _stateData.AlertRadius;

		public HoldState(StateData stateData)
		{
			_stateData = stateData;
		}
		
		public override void EnterState()
		{
			_npcController.MovementController.DestinationReachedEvent += OnHoldPositionReachedEventHandler;
			_npcController.MovementController.Move(_npcController.CurrentCheckPoint.GetHoldPosition());
		}

		public override void Act() { }

		public override void ExitState()
		{
			_npcController.MovementController.DestinationReachedEvent -= OnHoldPositionReachedEventHandler;
		}

		private void OnHoldPositionReachedEventHandler()
		{
			_npcController.MovementController.DestinationReachedEvent -= OnHoldPositionReachedEventHandler;
		}
	}
}