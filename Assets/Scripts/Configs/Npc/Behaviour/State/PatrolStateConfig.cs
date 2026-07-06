using StalkerSimulation.Npc;
using UnityEngine;

namespace StalkerSimulation.Configs.Npc
{
	[CreateAssetMenu(fileName = "PatrolStateConfig", menuName = "Scriptable Objects/Npc/Behaviour/States/Patrol State")]
	public class PatrolStateConfig : NpcStateConfig
	{
		public override NpcState BuildNpcState() => new PatrolState();
	}
}