using System;
using DG.Tweening;
using Ingame.Settings.Service;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Ingame.MainMenu.UI
{
	public sealed class UiMainButtons : MonoBehaviour
	{
		[BoxGroup("References")]
		[Required, SerializeField] private CanvasGroup parentCanvasGroup;
		[BoxGroup("References")]
		[Required, SerializeField] private Button playButton;
		[BoxGroup("References")]
		[Required, SerializeField] private Button settingsButton;
		[BoxGroup("References")]
		[Required, SerializeField] private Button exitButton;

		[BoxGroup("Scene loading properties")]
		[SerializeField, Scene] private int sceneToLoad;
		
		[BoxGroup("Animation properties")]
		[SerializeField] [Min(0f)] private float fadeAnimationDuration;
		
		private GameSettingsService _gameSettingsService;

		[Inject]
		private void Construct(GameSettingsService gameSettingsService)
		{
			_gameSettingsService = gameSettingsService;

			playButton.onClick.AddListener(OnPlayButtonClicked);
			settingsButton.onClick.AddListener(OnSettingsButtonClicked);
			exitButton.onClick.AddListener(OnExitButtonClicked);
			
			_gameSettingsService.OnSettingsShown += OnSettingsShown;
			_gameSettingsService.OnSettingsHidden += OnSettingsHidden;
		}
		
		private void OnDestroy()
		{
			playButton.onClick.RemoveListener(OnPlayButtonClicked);
			settingsButton.onClick.RemoveListener(OnSettingsButtonClicked);
			exitButton.onClick.RemoveListener(OnExitButtonClicked);
			
			_gameSettingsService.OnSettingsShown -= OnSettingsShown;
			_gameSettingsService.OnSettingsHidden -= OnSettingsHidden;
		}

		private void OnPlayButtonClicked()
		{
			SceneManager.LoadScene(sceneToLoad);
		}
		
		private void OnSettingsButtonClicked()
		{
			_gameSettingsService.ShowSettings();
		}
		
		private void OnExitButtonClicked()
		{
			Application.Quit();
		}

		private void OnSettingsHidden()
		{
			parentCanvasGroup.gameObject.SetActive(true);
			parentCanvasGroup.DOFade(1f, fadeAnimationDuration);
		}

		private void OnSettingsShown()
		{
			parentCanvasGroup.DOFade(0f, fadeAnimationDuration)
				.OnComplete(() => parentCanvasGroup.gameObject.SetActive(false));
		}
	}
}