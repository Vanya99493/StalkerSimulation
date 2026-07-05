using System;

namespace StalkerSimulation.Npc.Data
{
	[Serializable]
	public class ObserveStateData : StateData
	{
		public float MinimalObserveTime;
		public float MaximalObserveTime;
	}
}