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
		private CheckPointsCollection _checkPointsCollection;

		[Space(10)]
		[SerializeField]
		private OrderData _defaultOrderData;
		
		[Header("Configs")]
		[SerializeField]
		private NpcBehaviourConfig _npcBehaviourConfig;
		
		[SerializeField]
		private NpcDataConfig _npcDataConfig;

		private NpcBuilder _npcBuilder;
		private readonly List<NpcController> _npcList = new ();

		public void Initialize()
		{
			_npcBuilder = new NpcBuilder(
				_navMeshSurface,
				_npcBehaviourConfig, 
				_npcDataConfig);
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
			ICheckPoint checkPoint = GetCheckPointByTeam(teamType);
			
			NpcController npcController = _npcFactory.Create(checkPoint.SpawnPosition, Quaternion.identity);
			
			_npcBuilder.BuildNpc(npcController, teamType, checkPoint, _defaultOrderData);
			
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

		private ICheckPoint GetCheckPointByTeam(TeamType teamType)
		{
			return teamType switch
			{
				TeamType.Team1 => _checkPointsCollection.Team1BaseCheckPoint,
				TeamType.Team2 => _checkPointsCollection.Team2BaseCheckPoint,
			};
		}
	}
}