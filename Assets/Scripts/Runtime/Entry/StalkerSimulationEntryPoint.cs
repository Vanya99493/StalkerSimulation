using StalkerSimulation.Npc;
using UnityEngine;

namespace StalkerSimulation.Entry
{
	public class StalkerSimulationEntryPoint : MonoBehaviour
	{
		[SerializeField]
		private NpcSpawner _npcSpawner;

		private void OnDestroy()
		{
			_npcSpawner.DestroyAllNpc();
		}

		[ContextMenu("Spawn NPC")]
		public void SpawnNpc()
		{
			_npcSpawner.SpawnNpc();
		}
	}
}