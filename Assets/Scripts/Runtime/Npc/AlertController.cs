using UnityEngine;

namespace StalkerSimulation.Npc
{
	public class AlertController : MonoBehaviour
	{
		[Range(0, 30)]
		[SerializeField]
		private float _visionUpdatePerSecond = 5;
		
		private INpcController _npcController;
		
		private float _visionUpdateDelay = 100f;	// Large default value to avoid vision updating after npc spawn but before initializing 
		private float _passedTime;
		
		private readonly Collider[] _rangeColliders = new Collider[32];

		private void Update()
		{
			if (_passedTime >= _visionUpdateDelay)
			{
				UpdateVision();
				_passedTime = 0f;
			}
			
			_passedTime += Time.deltaTime;
		}

		public void Initialize(INpcController npcController)
		{
			_npcController = npcController;
			
			_visionUpdateDelay = 1f / _visionUpdatePerSecond;
			_passedTime = 0f;
		}

		private void UpdateVision()
		{
			float radius = _npcController.CurrentState.AlertRadius;
			
			// TODO: create vision simulation
		}
	}
}