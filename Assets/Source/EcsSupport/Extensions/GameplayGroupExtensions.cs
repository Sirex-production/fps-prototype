using Entitas;

namespace EcsSupport.Extensions
{
	public static class GameplayGroupExtensions
	{
		public static GameplayEntity GetFirstEntity(this IGroup<GameplayEntity> group)
		{
			return group.GetEntities()[0];
		}
	}
}