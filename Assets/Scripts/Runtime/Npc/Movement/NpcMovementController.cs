using System;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

namespace StalkerSimulation.Npc
{
	public class NpcMovementController : MonoBehaviour, INpcMovementController
	{
		[SerializeField]
		private NavMeshAgent _navMeshAgent;

		public NavMeshSurface NavMeshSurface { get; private set; }

		[SerializeField]
		private bool _isMoving;
		private Vector3 _destinationPosition;
		
		public event Action DestinationReachedEvent;

		private void Update()
		{
			CheckDestinationReached();
		}

		public void Initialize(NavMeshSurface navMeshSurface)
		{
			NavMeshSurface = navMeshSurface;

			_isMoving = false;
		}

		public void Move(Vector3 position)
		{
			_destinationPosition = position;
			_navMeshAgent.SetDestination(_destinationPosition);
			_isMoving = true;
		}
		
		private void CheckDestinationReached()
		{
			if (_isMoving)
			{
				Vector3 currentPosition = _navMeshAgent.transform.position;
				float distance = Vector3.Distance(currentPosition, _destinationPosition);

				if (distance < 0.1f)
				{
					_isMoving = false;
					DestinationReachedEvent?.Invoke();
				}
			}
		}
	}
}