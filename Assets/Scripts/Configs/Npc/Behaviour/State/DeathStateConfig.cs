using StalkerSimulation.Npc;
using UnityEngine;

namespace StalkerSimulation.Configs.Npc
{
	[CreateAssetMenu(fileName = "DeathStateConfig", menuName = "Scriptable Objects/Npc/Behaviour/States/Death State")]
	public class DeathStateConfig : NpcStateConfig
	{
		[SerializeField]
		private DeathStateData _deathStateData;
		
		public override NpcState BuildNpcState() => new DeathState(_deathStateData);
	}
}