using Entitas;

namespace Ingame.Gunplay.Axe
{
	public sealed class InvokeAxeAnimationsSystem : IExecuteSystem
	{
		private const string AXE_ATTACK_TRIGGER_NAME = "Attack";
		
		public void Execute()
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;
			var appContext = Contexts.sharedInstance.app;
			
			if(!gameplayContext.hasAxeCmp || !appContext.hasInputCmp)
				return;
			
			var inputCmp = Contexts.sharedInstance.app.inputCmp;
			var axeEntity = gameplayContext.axeCmpEntity;

			if(!inputCmp.shootTapInput || !axeEntity.hasAnimatorMdl)
				return;

			var axeAnimator = axeEntity.animatorMdl.aninmator;
			
			axeAnimator.ResetTrigger(AXE_ATTACK_TRIGGER_NAME);
			axeAnimator.SetTrigger(AXE_ATTACK_TRIGGER_NAME);
		}
	}
}