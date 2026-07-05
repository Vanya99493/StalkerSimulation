using System;
using UnityEngine;

namespace StalkerSimulation.Npc
{
	public interface INpcMovementController
	{
		public event Action DestinationReachedEvent;

		public void Move(Vector3 destinationPosition);
	}
}