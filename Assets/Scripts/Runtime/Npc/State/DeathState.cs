using DG.Tweening;

namespace StalkerSimulation.Npc
{
	public class DeathState : NpcState
	{
		private readonly DeathStateData _deathStateData;

		private Tween _remainInDeathStateTween;

		public override float AlertRadius => _deathStateData.AlertRadius;

		public DeathState(DeathStateData deathStateData)
		{
			_deathStateData = deathStateData;
		}

		~DeathState()
		{
			_remainInDeathStateTween?.Kill();
			_remainInDeathStateTween = null;
		}

		public override void EnterState()
		{
			_npcController.AnimationController.SetDeathTrigger();
			RemainInDeathState();
		}

		public override void Act() { }
		public override void ExitState() { }

		private void RemainInDeathState()
		{
			float passedTime = 0f;
			
			_remainInDeathStateTween?.Kill();
			_remainInDeathStateTween = DOTween.To(
					() => passedTime,
					x => passedTime = x,
					_deathStateData.RemainInDeathStateTime,
					_deathStateData.RemainInDeathStateTime)
				.OnComplete(() => _npcController.Destroy());
		}
	}
}