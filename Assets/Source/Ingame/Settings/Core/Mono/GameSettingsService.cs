using System;

namespace Ingame.Settings.Service
{
	public sealed class GameSettingsService
	{
		public SettingsData CurrentSettings => Contexts.sharedInstance.app.settingsCmp.currentSettingsData;

		public event Action OnSettingsShown;
		public event Action OnSettingsHidden;
		
		public void SetSettingsData(SettingsData settingsData)
		{
			var appContext = Contexts.sharedInstance.app;
			var settingsCmp = appContext.settingsCmp;

			settingsCmp.currentSettingsData = settingsData;
		}

		public void ShowSettings()
		{
			OnSettingsShown?.Invoke();
		}
		
		public void HideSettings()
		{
			OnSettingsHidden?.Invoke();
		}
	}
}