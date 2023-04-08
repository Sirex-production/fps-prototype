using Entitas;
using Ingame.Input;
using UnityEngine;
using Zenject;

namespace Ingame.Setup
{
	public sealed class EcsAppSetup : MonoBehaviour
	{
		private AppContext _appContext;
		private Systems _systems;

		[Inject]
		private void Construct(InputActions inputActions)
		{
			_appContext = Contexts.sharedInstance.app;
			_systems = new Systems();

			_systems
				.Add(new InputFeature(inputActions));
		}

		private void Awake()
		{
			_systems.Initialize();
		}

		private void Update()
		{
			_systems.Execute();
			_systems.Cleanup();
		}

		private void OnDestroy()
		{
			_systems.TearDown();
			_appContext.DestroyAllEntities();
		}
	}
}