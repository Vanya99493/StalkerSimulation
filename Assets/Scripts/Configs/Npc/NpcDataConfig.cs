using System.Collections.Generic;
using System.Linq;
using StalkerSimulation.Npc;
using UnityEngine;

namespace StalkerSimulation.Configs.Npc
{
	[CreateAssetMenu(fileName = "NpcDataConfig", menuName = "Scriptable Objects/Npc/Data/Npc Data Config")]
	public class NpcDataConfig : ScriptableObject
	{
		private const string DEFAULT_NAME = "Default";
		private const string DEAFULT_SURNAME = "1";
		
		[field: SerializeField]
		public int MaxHealthPoints { get; private set; }

		[field: SerializeField] 
		public LayerMask InteractionLayerMask { get; private set; }
		
		[field: SerializeField]
		public float ViewAngle { get; private set; }

		[Space(20)]
		[SerializeField]
		private Color _defaultColor;
		
		[SerializeField]
		private List<Pair<TeamType, Color>> _teamColors = new();
		
		[Space(20)]
		[SerializeField]
		private List<string> _npcNames = new();

		[SerializeField]
		private List<string> _npcSurnames = new();

		public Color GetTeamColor(TeamType team) => _teamColors.FirstOrDefault(x => x.Key == team)?.Value ?? _defaultColor;

		public string GetRandomFullName()
		{
			string npcName = _npcNames.Count > 0
				? _npcNames[Random.Range(0, _npcNames.Count)]
				: DEFAULT_NAME;
			string npcSurname = _npcSurnames.Count > 0
				? _npcSurnames[Random.Range(0, _npcSurnames.Count)]
				: DEAFULT_SURNAME;

			return $"{npcName} {npcSurname}";
		}
	}
}