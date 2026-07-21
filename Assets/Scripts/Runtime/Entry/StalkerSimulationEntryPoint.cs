using NaughtyAttributes;
using StalkerSimulation.Npc;
using UnityEngine;

namespace StalkerSimulation.Entry
{
	public class StalkerSimulationEntryPoint : MonoBehaviour
	{
		[SerializeField]
		private NpcSpawner _npcSpawner;

		private void Awake()
		{
			_npcSpawner.Initialize();
		}

		private void OnDestroy()
		{
			_npcSpawner.DestroyAllNpc();
		}

		[Button]
		public void SpawnTeam1Npc()
		{
			SpawnNpc(TeamType.Team1);
		}

		[Button]
		public void SpawnTeam2Npc()
		{
			SpawnNpc(TeamType.Team2);
		}

		private void SpawnNpc(TeamType teamType, int count = 1)
		{
			_npcSpawner.SpawnNpc(teamType, count);
		}
	}
}