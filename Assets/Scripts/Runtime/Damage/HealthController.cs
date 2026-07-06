using System;
using System.Collections.Generic;
using UnityEngine;

namespace StalkerSimulation.Npc
{
	public class HealthController : MonoBehaviour, IHealthController
	{
		[SerializeField]
		private List<DamageableBodyPart> _damageableBodyParts = new();
		
		public int MaxHealth { get; private set; }
		public int CurrentHealth { get; private set; }
		public bool IsAlive => CurrentHealth > 0;

		public event Action<DamageArgs> TakeDamageEvent;
		public event Action<DamageArgs> DeathEvent;

		public void Initialize(int maxHealth, int currentHealth)
		{
			MaxHealth = maxHealth;
			CurrentHealth = currentHealth;
			
			foreach (var bodyPart in _damageableBodyParts)
			{
				bodyPart.Initialize(this);
			}
		}

		public void TakeDamage(DamageArgs damageArgs)
		{
			CurrentHealth = Mathf.Clamp(CurrentHealth - damageArgs.Damage, 0, MaxHealth);
			TakeDamageEvent?.Invoke(damageArgs);

			if (IsAlive)
			{
				DeathEvent?.Invoke(damageArgs);
			}
		}
	}
}