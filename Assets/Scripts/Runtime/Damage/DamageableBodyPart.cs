using UnityEngine;

namespace StalkerSimulation.Npc
{
	public class DamageableBodyPart : MonoBehaviour, IDamageable
	{
		[Range(0, 10)]
		[SerializeField]
		private float _damageMultiplier = 1f;
		
		private IHealthController _healthController;

		public void Initialize(IHealthController healthController)
		{
			_healthController = healthController;
		}
		
		public void TakeDamage(in DamageArgs args)
		{
			DamageArgs modifiedArgs = args.WithDamage((int)(args.Damage *  _damageMultiplier));
			_healthController.TakeDamage(modifiedArgs);
		}
	}
}