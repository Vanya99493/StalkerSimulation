using StalkerSimulation.Npc.Data;
using UnityEngine;

namespace StalkerSimulation.Configs.Npc
{
	public abstract class NpcStateConfig : ScriptableObject
	{
		public virtual StateData GetStateData() => new StateData();
	}
}