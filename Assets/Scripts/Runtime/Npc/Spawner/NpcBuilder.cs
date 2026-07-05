using System;
using System.Collections.Generic;
using StalkerSimulation.Configs.Npc;

namespace StalkerSimulation.Npc
{
	public class NpcBuilder
	{
		private NpcStateFactory _npcStateFactory = new();

		public void BuildNpcBehaviour(NpcController npcController, NpcBehaviourConfig behaviourConfig)
		{
			Dictionary<Type, NpcState> npcBehaviourStates = BuildStates(npcController, behaviourConfig);

			npcController.InitializeBehaviour(npcBehaviourStates);
		}

		private Dictionary<Type, NpcState> BuildStates(NpcController npcController, NpcBehaviourConfig behaviourConfig)
		{
			Dictionary<Type, NpcState> npcBehaviourStates = new();

			foreach (var npcStateConfig in behaviourConfig.NpcStateConfigs)
			{
				NpcState resultState = _npcStateFactory.CreateState(npcStateConfig);
				resultState.Initialize(npcController);
				npcBehaviourStates.Add(resultState.GetType(), resultState);
			}
			
			return npcBehaviourStates;
		}
	}
}