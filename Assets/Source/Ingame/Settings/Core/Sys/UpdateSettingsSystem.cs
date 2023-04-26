using System.Collections.Generic;
using Entitas;
using Ingame.Settings.Service;

namespace Source.Ingame.Settings.Core
{
	public sealed class InitializeSettingsSystem : ReactiveSystem<AppEntity>
	{
		private readonly AppContext _appContext;
		
		public InitializeSettingsSystem(IContext<AppEntity> context) : base(context)
		{
			_appContext = Contexts.sharedInstance.app;
			
			var entity = _appContext.CreateEntity();
			entity.AddSettingsCmp(SettingsData.Default);
		}

		protected override ICollector<AppEntity> GetTrigger(IContext<AppEntity> context)
		{
			return context.CreateCollector(AppMatcher.UpdateSettingsEvent);
		}

		protected override bool Filter(AppEntity entity)
		{
			return true;
		}

		protected override void Execute(List<AppEntity> entities)
		{
			var settingsCmp = _appContext.settingsCmp;
			//TODO implement settings changes
		}
	}
}