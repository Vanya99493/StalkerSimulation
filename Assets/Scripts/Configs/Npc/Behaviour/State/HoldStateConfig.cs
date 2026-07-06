using StalkerSimulation.Npc;
using UnityEngine;

namespace StalkerSimulation.Configs.Npc
{
	[CreateAssetMenu(fileName = "HoldStateConfig", menuName = "Scriptable Objects/Npc/Behaviour/States/Hold State")]
	public class HoldStateConfig : NpcStateConfig
	{
		public override NpcState BuildNpcState() => new HoldState();
	}
}