using StalkerSimulation.Npc;
using UnityEngine;

namespace StalkerSimulation
{
	public class NpcData
	{
		public string Name = "";
		public TeamType TeamType;
		public Color Color;
		public RankType RankType;
		public LayerMask InteractionLayerMask;
		public int ViewAngle;
		public int MaxHealthPoints;
		public int CurrentHealthPoints;
	}
}