using StalkerSimulation.Npc;
using UnityEngine;

namespace StalkerSimulation.Configs.Npc
{
	[CreateAssetMenu(fileName = "AttackStateConfig", menuName = "Scriptable Objects/Npc/Behaviour/States/Attack State")]
	public class AttackStateConfig : NpcStateConfig
	{
		[SerializeField]
		private AttackStateData _attackStateData;

		public override NpcState BuildNpcState() => new AttackState(_attackStateData);
	}
}