using System;
using UnityEngine;

namespace StalkerSimulation
{
	[Serializable]
	public struct FloatRange
	{
		[field: SerializeField]
		public float Min { get; private set; }
		
		[field: SerializeField]
		public float Max { get; private set; }

		public FloatRange(float min, float max)
		{
			Min = Mathf.Min(min, max);
			Max = Mathf.Max(min, max);
		}

		public void Set(float min, float max)
		{
			Min = Mathf.Min(min, max);
			Max = Mathf.Max(min, max);
		}

		public float Lerp(float t)
		{
			return Mathf.Lerp(Min, Max, t);
		}

		public float Random()
		{
			return UnityEngine.Random.Range(Min, Max);
		}
	}
}