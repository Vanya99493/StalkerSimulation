using System;

namespace StalkerSimulation.Npc
{
	[Serializable]
	public class ObserveStateData : StateData
	{
		public float MinimalObserveTime;
		public float MaximalObserveTime;
	}
}