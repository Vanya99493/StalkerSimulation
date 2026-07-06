using UnityEngine;

namespace StalkerSimulation
{
	public readonly struct DamageArgs
	{
		public readonly int Damage;
		public readonly DamageType DamageType;
		public readonly Vector3 HitPoint;
		public readonly Vector3 HitNormal;
		public readonly Vector3 Direction;
		public readonly GameObject Source;

		public DamageArgs(
			int damage,
			DamageType damageType,
			Vector3 hitPoint,
			Vector3 hitNormal,
			Vector3 direction,
			GameObject source)
		{
			Damage = damage;
			DamageType = damageType;
			HitPoint = hitPoint;
			HitNormal = hitNormal;
			Direction = direction;
			Source = source;
		}

		public DamageArgs WithDamage(int newDamage)
		{
			return new DamageArgs(
				newDamage, 
				DamageType, 
				HitPoint, 
				HitNormal, 
				Direction, 
				Source);
		}
	}
}