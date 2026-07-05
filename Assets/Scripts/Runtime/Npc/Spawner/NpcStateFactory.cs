using StalkerSimulation.Configs.Npc;
using StalkerSimulation.Npc.Data;

namespace StalkerSimulation.Npc
{
	public class NpcStateFactory
	{
		public NpcState CreateState(NpcStateConfig stateConfig)
		{
			return stateConfig switch
			{
				HoldStateConfig holdStateConfig => new HoldState(),
				ObserveStateConfig observeStateConfig => new ObserveState(observeStateConfig.GetStateData() as ObserveStateData),
				PatrolStateConfig patrolStateConfig => new PatrolState(),
				MoveToCheckPointStateConfig moveToCheckPointStateConfig => new MoveToCheckPointState(),
				_ => new HoldState(),
			};
		}
	}
}