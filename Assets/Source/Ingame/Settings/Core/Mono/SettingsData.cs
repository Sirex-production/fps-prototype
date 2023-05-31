namespace Ingame.Settings.Service
{
	public struct SettingsData
	{
		public static SettingsData Default => new()
		{
			sensitivity = 30,
			sfxVolume = 1
		};

		public float sensitivity;
		public float sfxVolume;
	}
}