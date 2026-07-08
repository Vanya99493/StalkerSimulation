using System;
using StalkerSimulation.Environment;
using StalkerSimulation.Npc;
using UnityEngine;

namespace StalkerSimulation.Helpers
{
	public class NpcControlHelper : MonoBehaviour
	{
		[SerializeField]
		private NpcController _npcController;
		
		[Space(20)]
		[Header("Debug")]
		[SerializeField]
		private string _currentStateDebugString;
		
		[Space(20)]
		[SerializeField]
		private CheckPoint _checkPointToMove;

		private void Update()
		{
			_currentStateDebugString = _npcController.CurrentState?.ToString();
		}

		[ContextMenu("Hold")]
		public void Hold()
		{
			_npcController.SetOrder(new OrderData(OrderType.Hold));
		}

		[ContextMenu("Observe")]
		public void Observe()
		{
			_npcController.SetOrder(new OrderData(OrderType.Observe));
		}

		[ContextMenu("Patrol Inside")]
		public void PatrolInside()
		{
			_npcController.SetOrder(new OrderData(OrderType.PatrolInnerYard));
		}

		[ContextMenu("Patrol Outside")]
		public void PatrolOutside()
		{
			_npcController.SetOrder(new OrderData(OrderType.PatrolOuterArea));
		}

		[ContextMenu("Move To CheckPoint")]
		public void MoveToCheckPoint()
		{
			_npcController.SetOrder(new MoveToCheckPointOrderData(OrderType.MoveToCheckPoint, _checkPointToMove));
		}
	}
}