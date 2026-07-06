using UnityEngine;

namespace StalkerSimulation.Npc
{
	public class AnimationController : MonoBehaviour, IAnimationController
	{
		[SerializeField]
		private Animator _animator;

		public void SetDeathTrigger()
		{
			_animator.SetTrigger("Death");
		}
	}
}