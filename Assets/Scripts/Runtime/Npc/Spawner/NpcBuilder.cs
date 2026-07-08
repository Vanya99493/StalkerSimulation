using System;
using System.Collections.Generic;
using StalkerSimulation.Configs.Npc;
using StalkerSimulation.Environment;
using Unity.AI.Navigation;

namespace StalkerSimulation.Npc
{
	public class NpcBuilder
	{
		private readonly NavMeshSurface _navMeshSurface;
		private readonly NpcBehaviourConfig _behaviourConfig;
		private readonly NpcDataConfig _npcDataConfig;

		public NpcBuilder(
			NavMeshSurface navMeshSurface,
			NpcBehaviourConfig behaviourConfig, 
			NpcDataConfig npcDataConfig)
		{
			_navMeshSurface = navMeshSurface;
			_behaviourConfig =  behaviourConfig;
			_npcDataConfig = npcDataConfig;
		}
		
		public void BuildNpc(
			NpcController npcController, 
			TeamType teamType,
			ICheckPoint checkPoint,
			OrderData orderData)
		{
			NpcData npcData = BuildNpcData(teamType);
			npcController.Initialize(npcData, _navMeshSurface);
			BuildNpcBehaviour(npcController);
			
			npcController.SetChekPoint(checkPoint);
			npcController.SetOrder(orderData);
		}

		private NpcData BuildNpcData(TeamType teamType)
		{
			return new NpcData()
			{
				Name = _npcDataConfig.GetRandomFullName(),
				TeamType = teamType,
				Color = _npcDataConfig.GetTeamColor(teamType),
				RankType = RankType.Junior,
				InteractionLayerMask = _npcDataConfig.InteractionLayerMask,
				MaxHealthPoints = _npcDataConfig.MaxHealthPoints,
				CurrentHealthPoints = _npcDataConfig.MaxHealthPoints,
			};
		}
		
		private void BuildNpcBehaviour(NpcController npcController)
		{
			Dictionary<Type, NpcState> npcBehaviourStates = new();

			foreach (var npcStateConfig in _behaviourConfig.NpcStateConfigs)
			{
				NpcState resultState = npcStateConfig.BuildNpcState();
				resultState.Initialize(npcController);
				npcBehaviourStates.Add(resultState.GetType(), resultState);
			}

			npcController.InitializeBehaviour(npcBehaviourStates);
		}
	}
}