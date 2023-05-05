using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ingame.PauseMenu.UI
{
	public sealed class UiPauseMenu : MonoBehaviour
	{
		[BoxGroup("References")]
		[Required, SerializeField] private CanvasGroup parentCanvasGroup;
		[BoxGroup("References")]
		[Required, SerializeField] private Button continueMenuButton;
		[BoxGroup("References")]
		[Required, SerializeField] private Button mainMenuButton;
		
		[BoxGroup("Scene management")]
		[SerializeField] [Scene] private int mainMenuScene;
		
		[BoxGroup("Animation")]
		[SerializeField] [Min(0f)] private float fadeAnimationDuration = .1f;

		public bool IsShown { get; private set; }

		private void Awake()
		{
			continueMenuButton.onClick.AddListener(OnContinueButtonClicked);
			mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
			
			Hide();
		}

		private void OnDestroy()
		{
			continueMenuButton.onClick.RemoveListener(OnContinueButtonClicked);
			mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);
		}

		private void OnContinueButtonClicked()
		{
			Hide();
		}
		
		private void OnMainMenuButtonClicked()
		{
			SceneManager.LoadScene(mainMenuScene);
		}

		public void Show()
		{
			IsShown = true;
			
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			
			parentCanvasGroup.gameObject.SetActive(true);
			parentCanvasGroup.interactable = true;
			parentCanvasGroup.DOFade(1, fadeAnimationDuration)
				.SetLink(gameObject);
		}
		
		public void Hide()
		{
			IsShown = false;
			
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			
			parentCanvasGroup.interactable = false;
			parentCanvasGroup.DOFade(1, fadeAnimationDuration)
				.OnComplete(() => parentCanvasGroup.gameObject.SetActive(false))
				.SetLink(gameObject);
		}
	}
}