using System;
using StalkerSimulation.Weapon;

namespace StalkerSimulation
{
	[Serializable]
	public class AmmunitionData
	{
		public AmmunitionType AmmunitionType;
		public float Speed;
		public float MaxDistance;
	}
}