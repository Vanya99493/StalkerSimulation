using UnityEngine;

namespace StalkerSimulation.Attributes
{
	public class MinMaxAttribute : PropertyAttribute
	{
		public readonly float Min;
		public readonly float Max;

		public MinMaxAttribute(float min, float max)
		{
			Min = min;
			Max = max;
		}
	}
}