using System;
using StalkerSimulation.Npc.Data;
using UnityEngine;

namespace StalkerSimulation.Configs.Npc
{
	[CreateAssetMenu(fileName = "ObserveStateConfig", menuName = "Scriptable Objects/Npc/Behaviour/States/Observe State")]
	public class ObserveStateConfig : NpcStateConfig
	{
		[SerializeField]
		private ObserveStateData _observeStateData;

		public override StateData GetStateData() => _observeStateData;

#if UNITY_EDITOR
		private void OnValidate()
		{
			_observeStateData.MinimalObserveTime = Mathf.Clamp(_observeStateData.MinimalObserveTime, 0, Int64.MaxValue);
			_observeStateData.MaximalObserveTime = Mathf.Clamp(_observeStateData.MaximalObserveTime, 0, Int64.MaxValue);
			
			_observeStateData.MinimalObserveTime = Mathf.Clamp(_observeStateData.MinimalObserveTime, 0, _observeStateData.MaximalObserveTime);
			_observeStateData.MaximalObserveTime = Mathf.Clamp(_observeStateData.MaximalObserveTime, _observeStateData.MinimalObserveTime, Int64.MaxValue);
		}
#endif
	}
}