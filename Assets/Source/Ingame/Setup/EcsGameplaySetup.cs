using Entitas;
using Ingame.Camerawork;
using Ingame.ConfigProvision;
using Ingame.Effects;
using Ingame.Gunplay.ArrowGun;
using Ingame.Gunplay.Axe;
using Ingame.Gunplay.EnergyGun;
using Ingame.Gunplay.MeleeAttack;
using Ingame.Gunplay.Projectile;
using Ingame.Gunplay.Sway;
using Ingame.Gunplay.Sway.WeaponSwitch;
using Ingame.Player.Abilities;
using Ingame.Player.Movement;
using Ingame.Vfx.ShotTrail;
using Ingame.Ai;
using Ingame.Interactive.Environment;
using Source.Ingame.Health;
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
		private void Construct(DiContainer diContainer, ConfigProvider configProvider)
		{
			_gameplayContext = Contexts.sharedInstance.gameplay;
			_updateSystems = new Systems();
			_fixedUpdateSystems = new Systems();
			
			_updateSystems.Add(new PlayerMovementFeature(configProvider));
			_updateSystems.Add(new WeaponSwitchFeature());
			_updateSystems.Add(new ArrowGunFeature(diContainer));
			_updateSystems.Add(new EnergyGunFeature(configProvider));
			_updateSystems.Add(new AxeFeature());
			_updateSystems.Add(new ProjectileFeature());
			_updateSystems.Add(new MeleeAttackFeature());
			_updateSystems.Add(new EffectsFeature());
			_updateSystems.Add(new AbilitiesFeature(configProvider));
			_updateSystems.Add(new SwayFeature());
			_updateSystems.Add(new CameraworkFeature());
			_updateSystems.Add(new VfxFeature());
			_updateSystems.Add(new GameplayCleanupSystems(Contexts.sharedInstance));
			_updateSystems.Add(new AiFeature(_gameplayContext));
			_updateSystems.Add(new AiFeature(_gameplayContext));
			_updateSystems.Add(new EnvironmentFeature(_gameplayContext));
			_updateSystems.Add(new HealthFeature(_gameplayContext));
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
			
			_updateSystems.ClearReactiveSystems();
			_fixedUpdateSystems.ClearReactiveSystems();
			
			_updateSystems.DeactivateReactiveSystems();
			_fixedUpdateSystems.DeactivateReactiveSystems();
			
			_gameplayContext.DestroyAllEntities();
		}
	}
}