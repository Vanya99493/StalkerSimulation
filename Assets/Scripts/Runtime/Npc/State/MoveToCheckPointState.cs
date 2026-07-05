using StalkerSimulation.Environment;
using UnityEngine;

namespace StalkerSimulation.Npc
{
	public class MoveToCheckPointState : NpcState
	{
		public override void EnterState()
		{
			_npcController.MovementController.DestinationReachedEvent += OnCheckPointReachedEventHandler;
			
			ICheckPoint checkPoint = ((MoveToCheckPointOrderData)_npcController.OrderData).DestinationCheckPoint;
			_npcController.SetChekPoint(checkPoint);
			Vector3 checkPointPosition = checkPoint.CenterTransform.position;
			_npcController.MovementController.Move(checkPointPosition);
		}

		public override void Act() { }

		public override void ExitState()
		{
			_npcController.MovementController.DestinationReachedEvent -= OnCheckPointReachedEventHandler;
		}

		private void OnCheckPointReachedEventHandler()
		{
			_npcController.MovementController.DestinationReachedEvent -= OnCheckPointReachedEventHandler;
			_npcController.ChangeState<HoldState>();
		}
	}
}