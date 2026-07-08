using System;
using UnityEngine;

namespace StalkerSimulation
{
	[Serializable]
	public class Pair<T, K>
	{
		[field: SerializeField] 
		public T Key { get; private set; }
		
		[field: SerializeField]
		public K Value { get; private set; }
	}
}