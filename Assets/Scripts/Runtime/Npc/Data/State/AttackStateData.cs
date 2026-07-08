using System;
using StalkerSimulation.Attributes;

namespace StalkerSimulation.Npc
{
	[Serializable]
	public class AttackStateData : StateData
	{
		[MinMax(0f, 10f)]
		public FloatRange ShootingRange;
		
		[MinMax(0f, 10f)]
		public FloatRange ShootingDelayRange;
	}
}