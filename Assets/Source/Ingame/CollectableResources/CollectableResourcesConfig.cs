using NaughtyAttributes;
using UnityEngine;

namespace Ingame.CollectableResources
{
	[CreateAssetMenu(menuName = "Configs/CollectableResourcesConfig")]
	public sealed class CollectableResourcesConfig : ScriptableObject
	{
		[field: BoxGroup("Common")]
		[field: SerializeField, Min(0f)] public float InteractionDistance { get; private set; } = 2f;
		
		[field: BoxGroup("Animation properties")]
		[field: SerializeField, Min(0f)] public float ResourceConsumptionAnimationDuration { get; private set; } = .5f;
	}
}