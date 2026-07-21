using System.Collections.Generic;
using System.Linq;
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
			List<INpcController> sightAngleTargets = OverlapsSurrounding();

			if (DetermineEnemiesIfExists(sightAngleTargets, out List<INpcController> enemies))
			{
				INpcController priorityEnemyTarget =  DeterminePriorityEnemyTarget(enemies);
				_npcController.SetOrder(new AttackOrderData(OrderType.AttackTarget, priorityEnemyTarget));
			}
		}

		private List<INpcController> OverlapsSurrounding()
		{
			List<INpcController> sightAngleTargets = new();
				
			int count = Physics.OverlapSphereNonAlloc(
				_npcController.EyePosition, 
				_npcController.CurrentState.AlertRadius, 
				_rangeColliders,
				_npcController.NpcData.InteractionLayerMask);

			for (int i = 0; i < count; i++)
			{
				Collider target = _rangeColliders[i];

				if (target.transform == _npcController.Transform)
				{
					continue;
				}
				
				Vector3 direction = (target.transform.position + new Vector3(0f, _npcController.EyePosition.y, 0f)) - _npcController.EyePosition;

				if (Vector3.Angle(transform.forward, direction) > _npcController.NpcData.ViewAngle * 0.5f)
				{
					continue;
				}

				if (Physics.Raycast(
					    _npcController.EyePosition, 
					    direction.normalized, 
					    out RaycastHit hit, 
					    direction.magnitude,
					    _npcController.NpcData.InteractionLayerMask))
				{
					if (hit.transform.TryGetComponent(out INpcController npcController))
					{
						sightAngleTargets.Add(npcController);
					}
				}
			}

			return sightAngleTargets;
		}

		private bool DetermineEnemiesIfExists(List<INpcController> targets, out List<INpcController> enemies)
		{
			enemies = targets.Where(x => x.NpcData.TeamType != _npcController.NpcData.TeamType && x.HealthController.IsAlive).ToList();
			return enemies.Count > 0;
		}

		private INpcController DeterminePriorityEnemyTarget(List<INpcController> enemies)
		{
			float minimalDistance = 100000f;
			INpcController priorityEnemy = null;

			foreach (var enemyController in enemies)
			{
				float distance = Vector3.Distance(transform.position, enemyController.Transform.position);

				if (distance < minimalDistance)
				{
					minimalDistance = distance;
					priorityEnemy = enemyController;
				}
			}

			return priorityEnemy;
		}
	}
}