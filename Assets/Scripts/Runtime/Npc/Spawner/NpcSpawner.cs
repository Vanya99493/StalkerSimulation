using System.Collections.Generic;
using StalkerSimulation.Configs.Npc;
using StalkerSimulation.Environment;
using Unity.AI.Navigation;
using UnityEngine;

namespace StalkerSimulation.Npc
{
	public class NpcSpawner : MonoBehaviour
	{
		[SerializeField]
		private NpcFactory _npcFactory;
		
		[Space(10)]
		[SerializeField]
		private NavMeshSurface _navMeshSurface;

		[Space(10)]
		[SerializeField]
		private CheckPoint _team1Base;
		
		[SerializeField]
		private CheckPoint _team2Base;

		[Space(10)]
		[SerializeField]
		private OrderData _defaultOrderData;
		
		[Header("Configs")]
		[SerializeField]
		private NpcBehaviourConfig _npcBehaviourConfig;

		private NpcBuilder _npcBuilder;
		private readonly List<NpcController> _npcList = new ();

		public void Initialize()
		{
			_npcBuilder = new NpcBuilder();
		}
		
		public void SpawnNpc(TeamType teamType, int npcCount)
		{
			for (int i = 0; i < npcCount; i++)
			{
				SpawnNpc(teamType);
			}
		}
		
		public void SpawnNpc(TeamType teamType)
		{
			CheckPoint checkPoint = GetCheckPointByTeam(teamType);
			
			NpcController npcController = _npcFactory.Create(checkPoint.SpawnPosition, Quaternion.identity);
			npcController.Initialize(_navMeshSurface);
			
			_npcBuilder.BuildNpcBehaviour(npcController, _npcBehaviourConfig);
			
			npcController.SetChekPoint(checkPoint);
			npcController.SetOrder(_defaultOrderData);
			
			_npcList.Add(npcController);
		}

		public void DestroyAllNpc()
		{
			foreach (var npc in _npcList)
			{
				npc.Destroy();
			}
			_npcList.Clear();
		}

		private CheckPoint GetCheckPointByTeam(TeamType teamType)
		{
			return teamType switch
			{
				TeamType.Team1 => _team1Base,
				TeamType.Team2 => _team2Base,
			};
		}
	}
}