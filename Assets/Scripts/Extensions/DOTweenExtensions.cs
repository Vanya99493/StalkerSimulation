using System;
using DG.Tweening;

namespace StalkerSimulation.Extensions
{
	public static class DOTweenExtensions
	{
		public static void To(
			this Tween tween, 
			float duration, 
			Action onUpdateCallback = null,
			Action onCompleteCallback = null)
		{
			float passedTime = 0f;
			
			tween?.Kill();
			tween = DOTween.To(() => passedTime, x => passedTime = x, duration, duration)
				.OnUpdate(() => onUpdateCallback?.Invoke())
				.OnComplete(() => onCompleteCallback?.Invoke());;
		}
	}
}