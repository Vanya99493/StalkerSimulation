using StalkerSimulation.Npc;
using UnityEngine;

namespace StalkerSimulation.Configs.Npc
{
	public class DeathStateConfig : NpcStateConfig
	{
		[SerializeField]
		private DeathStateData _deathStateData;
		
		public override NpcState BuildNpcState() => new DeathState(_deathStateData);
	}
}