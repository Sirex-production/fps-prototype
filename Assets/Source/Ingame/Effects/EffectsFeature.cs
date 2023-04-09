namespace Ingame.Effects
{
	public sealed class EffectsFeature : Feature
	{
		public EffectsFeature()
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;
			
			Add(new ApplyDamageSystem(gameplayContext));
		}
	}
}