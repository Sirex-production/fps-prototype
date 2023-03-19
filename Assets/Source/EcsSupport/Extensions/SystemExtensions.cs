using Entitas;

namespace EcsSupport.Extensions
{
	public static class SystemExtensions
	{
		public static bool IsEmpty<T>(this IGroup<T> group) where T : class, IEntity
		{
			return group.GetEntities().Length < 1;
		}
	}
}