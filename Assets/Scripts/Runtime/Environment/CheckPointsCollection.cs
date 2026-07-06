using UnityEngine;

namespace StalkerSimulation.Environment
{
	public class CheckPointsCollection : MonoBehaviour
	{
		[SerializeField]
		private CheckPoint _team1BaseCheckPoint;
		
		[SerializeField]
		private CheckPoint _team2BaseCheckPoint;
		
		public ICheckPoint Team1BaseCheckPoint => _team1BaseCheckPoint;
		public ICheckPoint Team2BaseCheckPoint => _team2BaseCheckPoint;
	}
}