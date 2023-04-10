using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Ingame.Gunplay.UI
{
	public sealed class UiPlayerGunsView : MonoBehaviour
	{

		[BoxGroup("References")] [SerializeField]
		private GunViewEntry[] gunViews;

		[BoxGroup("Animation properties")] [SerializeField] [Range(0f, 1f)]
		private float animationDumping = .0001f;

		[FormerlySerializedAs("scaleWhenAbilityIsRecharging")] [BoxGroup("Animation properties")] [SerializeField]
		private Vector3 scaleOfInactiveGun;

		private GunDisplayType _currentlySelectedGun = GunDisplayType.ArrowGun;

		[Inject]
		private void Construct()
		{
			var entity = Contexts.sharedInstance.gameplay.CreateEntity();

			entity.AddUiPlayerGunsViewMdl(this);
		}

		private void Update()
		{
			foreach(var gunView in gunViews)
			{
				var targetScale = gunView.type == _currentlySelectedGun ? Vector3.one : scaleOfInactiveGun;

				gunView.parentTransform.localScale = Vector3.Lerp
				(
					gunView.parentTransform.localScale,
					targetScale,
					1f - Mathf.Pow(animationDumping, Time.deltaTime)
				);
			}
		}

		public void SetActiveGun(GunDisplayType gunType)
		{
			_currentlySelectedGun = gunType;
		}

		[Serializable]
		public enum GunDisplayType
		{
			ArrowGun = 0,
			EnergyGun = 1,
			Melee = 2
		}

		[Serializable]
		public sealed class GunViewEntry
		{
			public GunDisplayType type;
			public Transform parentTransform;
		}
	}
}