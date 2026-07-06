using StalkerSimulation.Npc;
using UnityEngine;

namespace StalkerSimulation.Configs.Npc
{
	public abstract class NpcStateConfig : ScriptableObject
	{
		public abstract NpcState BuildNpcState();
	}
}