using StalkerSimulation.Npc;
using UnityEngine;

namespace StalkerSimulation
{
	public class NpcData
	{
		public string Guid = "";
		public string Name = "";
		public TeamType TeamType;
		public Color Color;
		public RankType RankType;
		public LayerMask InteractionLayerMask;
		public float ViewAngle;
		public int MaxHealthPoints;
		public int CurrentHealthPoints;
	}
}