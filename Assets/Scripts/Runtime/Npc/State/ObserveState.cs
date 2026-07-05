using StalkerSimulation.Npc.Data;
using UnityEngine;

namespace StalkerSimulation.Npc
{
	public class ObserveState : NpcState
	{
		private readonly ObserveStateData _observeStateData;
		
		private bool _isObserving;
		private float _observingTime;
		private float _passedTime;

		public ObserveState(ObserveStateData observeStateData)
		{
			_observeStateData = observeStateData;
		}
		
		public override void EnterState()
		{
			_isObserving  = true;
			_observingTime = GetHoldingTime();
			_passedTime = 0f;
		}

		public override void Act()
		{
			if (_isObserving)
			{
				if (_passedTime >= _observingTime)
				{
					_npcController.ChangeState<PatrolState>();
				}
				
				_passedTime += Time.deltaTime;
			}
		}

		public override void ExitState()
		{
			_isObserving = false;
		}

		private float GetHoldingTime()
		{
			return Random.Range(_observeStateData.MinimalObserveTime, _observeStateData.MaximalObserveTime);
		}
	}
}