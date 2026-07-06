using UnityEngine;
using UnityEngine.AI;

namespace StalkerSimulation.Npc
{
	public class PatrolState : NpcState
	{
		private readonly StateData _stateData;
		private bool _isMoving;

		public override float AlertRadius => _stateData.AlertRadius;

		public PatrolState(StateData stateData)
		{
			_stateData = stateData;
		}
		
		public override void EnterState()
		{
			_isMoving = false;
			
			_npcController.MovementController.DestinationReachedEvent += OnDestinationReachedEventHandler;
		}

		public override void Act()
		{
			if (_isMoving)
			{
				return;
			}
			
			(float, float) radius = GetRadius();

			if (radius.Item1 <= 0f)
			{
				_npcController.ChangeState<HoldState>();
			}

			Vector3 destinationPosition = GetRandomPositionInsideArea(radius.Item1, radius.Item2);
			_npcController.MovementController.Move(destinationPosition);
			
			_isMoving = true;
		}

		public override void ExitState()
		{
			_npcController.MovementController.DestinationReachedEvent -= OnDestinationReachedEventHandler;
		}

		private (float, float) GetRadius()
		{
			return _npcController.OrderData.OrderType switch
			{
				OrderType.PatrolInnerYard => (_npcController.CurrentCheckPoint.CheckPointInnerRadius, 0f),
				OrderType.PatrolOuterArea => (_npcController.CurrentCheckPoint.CheckPointOuterRadius, _npcController.CurrentCheckPoint.CheckPointInnerRadius),
				_ => (0f, 0f),
			};
		}

		private Vector3 GetRandomPositionInsideArea(float outerRadius, float innerRadius = 0f)
		{
			const int maxAttempts = 30;

			for (int i = 0; i < maxAttempts; i++)
			{
				float angle = Random.Range(0f, Mathf.PI * 2f); 
				float radius = Random.Range(innerRadius, outerRadius); 
				
				Vector3 randomPosition = _npcController.CurrentCheckPoint.CenterTransform.position + new Vector3(Mathf.Cos(angle) * radius, 0f, Mathf.Sin(angle) * radius);

				if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, outerRadius + 1f, NavMesh.AllAreas))
				{
					return hit.position;
				}
			}

			Debug.LogError("[NPC, PatrolState]: cannot find available position to patrol");
			return _npcController.CurrentCheckPoint.SpawnPosition;
		}

		private void OnDestinationReachedEventHandler()
		{
			_npcController.ChangeState<ObserveState>();
		}
	}
}