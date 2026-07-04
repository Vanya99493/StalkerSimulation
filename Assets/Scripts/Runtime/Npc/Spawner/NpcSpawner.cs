using System.Collections.Generic;
using UnityEngine;

namespace StalkerSimulation.Npc
{
	public class NpcSpawner : MonoBehaviour
	{
		[SerializeField]
		private NpcFactory _npcFactory;

		private readonly List<NpcController> _npcList = new ();
		
		public void SpawnNpc()
		{
			NpcController npc = _npcFactory.Create();
			npc.Initialize();
			_npcList.Add(npc);
		}

		public void DestroyAllNpc()
		{
			foreach (var npc in _npcList)
			{
				npc.Destroy();
			}
			_npcList.Clear();
		}
	}
}