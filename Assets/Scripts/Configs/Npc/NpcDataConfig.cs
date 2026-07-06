using System.Collections.Generic;
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
		
		[Space(20)]
		[SerializeField]
		private List<string> _npcNames = new();

		[SerializeField]
		private List<string> _npcSurnames = new();

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