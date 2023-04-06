using Entitas;
using Ingame.Camerawork;
using Ingame.ConfigProvision;
using Ingame.Gunplay.Sway;
using Ingame.Gunplay.Sway.WeaponSwitch;
using Ingame.Player.Movement;
using UnityEngine;
using Zenject;

namespace Ingame.Setup
{
	public sealed class EcsGameplaySetup : MonoBehaviour
	{
		private GameplayContext _gameplayContext;
		private Systems _updateSystems;
		private Systems _fixedUpdateSystems;

		[Inject]
		private void Construct(ConfigProvider configProvider)
		{
			_gameplayContext = Contexts.sharedInstance.gameplay;
			_updateSystems = new Systems();
			_fixedUpdateSystems = new Systems();
			
			_updateSystems.Add(new PlayerMovementFeature(configProvider));
			_updateSystems.Add(new WeaponSwitchFeature());
			_updateSystems.Add(new SwayFeature());
			_updateSystems.Add(new CameraworkFeature());
			
			_fixedUpdateSystems.Add(new MoveObjectDueToVelocitySystem());
		}

		private void Awake()
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			
			_updateSystems.Initialize();
			_fixedUpdateSystems.Initialize();
		}

		private void Update()
		{
			_updateSystems.Execute();
			_updateSystems.Cleanup();
		}

		private void FixedUpdate()
		{
			_fixedUpdateSystems.Execute();
			_fixedUpdateSystems.Cleanup();
		}

		private void OnDestroy()
		{
			_updateSystems.TearDown();
			_fixedUpdateSystems.TearDown();

			_gameplayContext.DestroyAllEntities();
		}
	}
}