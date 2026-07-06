using System.Collections.Generic;
using UnityEngine;

namespace StalkerSimulation.Configs.Npc
{
	[CreateAssetMenu(fileName = "NpcBehaviourConfig", menuName = "Scriptable Objects/Npc/Behaviour/Npc Behaviour")]
	public class NpcBehaviourConfig : ScriptableObject
	{
		public List<NpcStateConfig> NpcStateConfigs = new();
	}
}