using System.Collections.Generic;
using UnityEngine;

namespace StalkerSimulation.Npc
{
	public class VisualizationController : MonoBehaviour
	{
		[SerializeField]
		private List<Renderer> _renderers = new();

		public void Initialize(Color color)
		{
			foreach (Renderer renderer in _renderers)
			{
				renderer.material.color = color;
			}
		}
	}
}