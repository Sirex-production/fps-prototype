using DG.Tweening;
using Ingame.Settings.Service;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Ingame.Settings.UI
{
	public sealed class UiSettings : MonoBehaviour
	{
		[BoxGroup("References")]
		[Required, SerializeField] private CanvasGroup parentCanvasGroup;
		[BoxGroup("References")]
		[Required, SerializeField] private Button applySettingsButton;
		[BoxGroup("References")]
		[Required, SerializeField] private Button backButton;
		
		[BoxGroup("References (Sensitivity)")]
		[Required, SerializeField] private TMP_Text sensitivityText;
		[BoxGroup("References (Sensitivity)")]
		[Required, SerializeField] private Slider sensitivitySlider;
		
		[BoxGroup("References (SFX)")]
		[Required, SerializeField] private TMP_Text sfxVolumeText;
		[BoxGroup("References (SFX)")]
		[Required, SerializeField] private Slider sfxVolumeSlider;
		
		[BoxGroup("Animation options")]
		[SerializeField] [Min(0f)] private float fadeAnimationDuration = .3f;

		private GameSettingsService _gameSettingsService;

		[Inject]
		private void Construct(GameSettingsService gameSettingsService)
		{
			_gameSettingsService = gameSettingsService;

			applySettingsButton.onClick.AddListener(OnApplyButtonClicked);
			backButton.onClick.AddListener(OnBackButtonClicked);
			
			sensitivitySlider.onValueChanged.AddListener(OnSensitivitySliderValueChanged);
			sfxVolumeSlider.onValueChanged.AddListener(OnSfxVolumeSliderValueChanged);
			
			_gameSettingsService.OnSettingsShown += OnSettingsShown;
			_gameSettingsService.OnSettingsHidden += OnSettingsHidden;
			
			OnSettingsHidden();
			OnSensitivitySliderValueChanged(0f);
			OnSfxVolumeSliderValueChanged(0f);
		}

		private void OnDestroy()
		{
			applySettingsButton.onClick.RemoveListener(OnApplyButtonClicked);
			backButton.onClick.RemoveListener(OnBackButtonClicked);
			
			sensitivitySlider.onValueChanged.RemoveListener(OnSensitivitySliderValueChanged);
			sfxVolumeSlider.onValueChanged.RemoveListener(OnSfxVolumeSliderValueChanged);
			
			_gameSettingsService.OnSettingsShown -= OnSettingsShown;
			_gameSettingsService.OnSettingsHidden -= OnSettingsHidden;
		}

		private void OnApplyButtonClicked()
		{
			var settingsData = new SettingsData
			{
				sensitivity = sensitivitySlider.value,
				sfxVolume = sfxVolumeSlider.value
			};
			
			_gameSettingsService.SetSettingsData(settingsData);
			_gameSettingsService.HideSettings();
		}
		
		private void OnBackButtonClicked()
		{
			_gameSettingsService.HideSettings();
		}

		private void OnSensitivitySliderValueChanged(float value)
		{
			value = Mathf.FloorToInt(value);
			sensitivityText.SetText($"{value}");
		}
		
		private void OnSfxVolumeSliderValueChanged(float value)
		{
			value = Mathf.FloorToInt(value * 100);
			sfxVolumeText.SetText($"{value}");
		}

		private void OnSettingsShown()
		{
			parentCanvasGroup.gameObject.SetActive(true);
			parentCanvasGroup.DOFade(1f, fadeAnimationDuration);
		}

		private void OnSettingsHidden()
		{
			parentCanvasGroup.DOFade(0f, fadeAnimationDuration)
				.OnComplete(() => parentCanvasGroup.gameObject.SetActive(false));
		}
	}
}