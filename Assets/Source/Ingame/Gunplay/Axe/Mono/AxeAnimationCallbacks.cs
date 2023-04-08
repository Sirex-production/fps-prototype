using UnityEngine;

namespace Ingame.Gunplay.Axe
{
	public sealed class AxeAnimationCallbacks : MonoBehaviour
	{
		public void RequestMeleeAttack()
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;
			
			if(!gameplayContext.hasAxeCmp)
				return;

			var axeCmp = gameplayContext.axeCmp;
			
			gameplayContext.CreateEntity().AddPerformMeleeAttackReq(axeCmp.range, axeCmp.damage);
		}
	}
}