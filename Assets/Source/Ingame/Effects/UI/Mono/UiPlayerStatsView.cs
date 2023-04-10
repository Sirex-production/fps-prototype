using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Ingame.Effects.UI
{
	public sealed class UiPlayerStatsView : MonoBehaviour
	{
		[BoxGroup("References")]
		[SerializeField] private List<StatsViewEntry> statsViewEntries;
		
		[BoxGroup("Animation settings")]
		[SerializeField] [Range(0f, 1f)] private float animationDumping = .01f;

		private readonly Dictionary<DisplayStatType, float> _statsDictionary = new();

		[Inject]
		private void Construct()
		{
			var entity = Contexts.sharedInstance.gameplay.CreateEntity();
			
			entity.AddUiPlayerStatsViewMdl(this);
		}
		
		private void Update()
		{
			foreach(var statsViewEntry in statsViewEntries)
			{
				if(!_statsDictionary.ContainsKey(statsViewEntry.statType))
					continue;
				
				var sliderImage = statsViewEntry.sliderImage;
				float targetFillAmount = _statsDictionary[statsViewEntry.statType];

				sliderImage.fillAmount = Mathf.Lerp(sliderImage.fillAmount, targetFillAmount, 1f - Mathf.Pow(animationDumping, Time.deltaTime));
			}
		}

		public void SetStat(DisplayStatType statType, float current, float max)
		{
			_statsDictionary[statType] = Mathf.InverseLerp(0f, max, current);
		}

		[Serializable]
		public enum DisplayStatType
		{
			Health,
			Armor
		}
		
		[Serializable]
		private sealed class StatsViewEntry
		{
			public DisplayStatType statType;
			public Image sliderImage;
		}
	}
}