using UnityEngine;

namespace StalkerSimulation.Npc
{
	public class AlertController : MonoBehaviour
	{
		private NpcController _npcController;

		public void Initialize(NpcController npcController)
		{
			_npcController = npcController;
		}
	}
}