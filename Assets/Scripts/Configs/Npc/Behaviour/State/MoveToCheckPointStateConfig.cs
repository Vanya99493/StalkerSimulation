using StalkerSimulation.Npc;
using UnityEngine;

namespace StalkerSimulation.Configs.Npc
{
	[CreateAssetMenu(fileName = "MoveToCheckPointStateConfig",
		menuName = "Scriptable Objects/Npc/Behaviour/States/Move To Check Point State")]
	public class MoveToCheckPointStateConfig : NpcStateConfig
	{
		[SerializeField]
		private StateData _stateData;

		public override NpcState BuildNpcState() => new MoveToCheckPointState(_stateData);
	}
}