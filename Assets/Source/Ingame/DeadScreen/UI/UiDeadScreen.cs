using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ingame.DeadScreen
{
	public sealed class UiDeadScreen : MonoBehaviour
	{
		[BoxGroup("References")]
		[Required, SerializeField] private CanvasGroup parentCanvasGroup;
		[BoxGroup("References")]
		[Required, SerializeField] private Button restartButton;
		
		[BoxGroup("Animation")]
		[SerializeField] [Min(0f)] private float fadeAnimationDuration = .1f;

		private void Awake()
		{
			restartButton.onClick.AddListener(OnRestartButtonClicked);
			parentCanvasGroup.gameObject.SetActive(false);
		}

		private void OnDestroy()
		{
			restartButton.onClick.RemoveListener(OnRestartButtonClicked);
		}

		private void OnRestartButtonClicked()
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;

			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		
		public void Show()
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			
			parentCanvasGroup.gameObject.SetActive(true);
			parentCanvasGroup.interactable = true;
			parentCanvasGroup.DOFade(1, fadeAnimationDuration)
				.SetLink(gameObject);
		}
	}
}