using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Ingame.Player.Abilities.UI
{
	public sealed class UiPlayerAbilitiesView : MonoBehaviour
	{
		[BoxGroup("References")]
		[SerializeField] private AbilityViewEntry[] abilityViews;
		
		[BoxGroup("Animation properties")]
		[SerializeField] [Range(0f, 1f)] private float animationDumping = .0001f;
		[BoxGroup("Animation properties")]
		[SerializeField] private Vector3 scaleWhenAbilityIsRecharging;

		private readonly Dictionary<AbilityDisplayType, float> _abilitiesCooldownDictionary = new();
		private bool _isMagnetActive = false;

		[Inject]
		private void Construct()
		{
			var entity = Contexts.sharedInstance.gameplay.CreateEntity();
			
			entity.AddUiPlayerAbilitiesViewMdl(this);
		}
		
		private void Update()
		{
			foreach(var abilityView in abilityViews)
			{
				if(abilityView.type == AbilityDisplayType.Magnet)
				{
					UpdateMagnetAbilityUi(abilityView);
					continue;
				}
				
				UpdateUsualAbilityUi(abilityView);
			}
		}

		private void UpdateMagnetAbilityUi(AbilityViewEntry magnetAbilityView)
		{
			var targetParentScale = _isMagnetActive ? Vector3.one : scaleWhenAbilityIsRecharging;
			var targetTimerImageScale = _isMagnetActive ? Vector3.one : Vector3.zero;
			
			magnetAbilityView.parentTransform.localScale = Vector3.Lerp
			(
				magnetAbilityView.parentTransform.localScale,
				targetParentScale,
				1f - Mathf.Pow(animationDumping, Time.deltaTime)
			);
			
			magnetAbilityView.cooldownBarImage.transform.localScale = Vector3.Lerp
			(
				magnetAbilityView.cooldownBarImage.transform.localScale,
				targetTimerImageScale,
				1f - Mathf.Pow(animationDumping, Time.deltaTime)
			);
		}

		private void UpdateUsualAbilityUi(AbilityViewEntry abilityView)
		{
			if(!_abilitiesCooldownDictionary.ContainsKey(abilityView.type))
				return;
			
			float fillAmount = _abilitiesCooldownDictionary[abilityView.type];
			var targetScale = fillAmount < 1f ? scaleWhenAbilityIsRecharging : Vector3.one;

			abilityView.cooldownBarImage.fillAmount = fillAmount;
			abilityView.parentTransform.localScale = Vector3.Lerp
			(
				abilityView.parentTransform.localScale,
				targetScale,
				1f - Mathf.Pow(animationDumping, Time.deltaTime)
			);
		}

		public void SetCooldown(AbilityDisplayType type, float timeLeft, float cooldown)
		{
			_abilitiesCooldownDictionary[type] = Mathf.InverseLerp(0f, cooldown, timeLeft);
		}

		public void SetMagnetAbilityActiveness(bool isMagnetActive)
		{
			_isMagnetActive = isMagnetActive;
		}

		[Serializable]
		public enum AbilityDisplayType
		{
			Dash,
			Slide,
			Magnet
		}

		[Serializable]
		public sealed class AbilityViewEntry
		{
			public AbilityDisplayType type;
			public Transform parentTransform;
			public Image cooldownBarImage;
		}
	}
}