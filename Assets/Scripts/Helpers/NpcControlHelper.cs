using NaughtyAttributes;
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

		[Button]
		public void Hold()
		{
			_npcController.SetOrder(new OrderData(OrderType.Hold));
		}

		[Button]
		public void Observe()
		{
			_npcController.SetOrder(new OrderData(OrderType.Observe));
		}

		[Button]
		public void PatrolInside()
		{
			_npcController.SetOrder(new OrderData(OrderType.PatrolInnerYard));
		}

		[Button]
		public void PatrolOutside()
		{
			_npcController.SetOrder(new OrderData(OrderType.PatrolOuterArea));
		}

		[Button]
		public void MoveToCheckPoint()
		{
			_npcController.SetOrder(new MoveToCheckPointOrderData(OrderType.MoveToCheckPoint, _checkPointToMove));
		}
	}
}