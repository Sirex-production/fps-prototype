using UnityEngine;
using Zenject;

namespace Ingame.Gunplay.Sway
{
	public sealed class WeaponBaker : MonoBehaviour
	{
		[SerializeField] private AnimationCurve bobbingAnimationCurve;
		
		[Inject]
		private void Construct()
		{
			var entity = Contexts.sharedInstance.gameplay.CreateEntity();
			
			entity.AddTransformMdl(transform, transform.localRotation, transform.localPosition);
			
			//Sway
			entity.AddSwayCmp(bobbingAnimationCurve,.0001f, .0001f, 1f, .5f);
			entity.isInHangsTag = true;
		}
	}
}