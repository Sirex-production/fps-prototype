using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Ingame.CollectableResources
{
	public sealed class CollectableResourceBaker : MonoBehaviour
	{
		[BoxGroup("RigidbodyMdl")]
		[Required, SerializeField] private Rigidbody rigidbody;
		
		[BoxGroup("CollectableArmorCmp")]
		[SerializeField] private bool givesArmor = false;
		[BoxGroup("CollectableArmorCmp"), ShowIf("givesArmor")]
		[SerializeField] [Min(0f)] private float amountOfArmorGiven;
		
		[BoxGroup("CollectableHealthCmp")]
		[SerializeField] private bool givesHealth = false;
		[BoxGroup("CollectableHealthCmp"), ShowIf("givesHealth")]
		[SerializeField] [Min(0f)] private float amountOfHealthGiven;

		[Inject]
		private void Construct()
		{
			var entity = Contexts.sharedInstance.gameplay.CreateEntity();

			if(givesArmor) 
				entity.AddCollectableArmorCmp(amountOfArmorGiven);
			
			if(givesHealth) 
				entity.AddCollectableHealthCmp(amountOfHealthGiven);
			
			entity.hasMagneticItemTag = true;
			entity.AddTransformMdl(transform, transform.localRotation, transform.localPosition);
			entity.AddRigidbodyMdl(rigidbody);
		}
	}
}