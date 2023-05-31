
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
using Ingame.CollectableResources;
using Ingame.DeadScreen;
using Ingame.Interactive.Environment;
using Ingame.PauseMenu;
using Ingame.Vfx.ShotTrail.FloatingEffect;
using Source.EcsSupport.Support;
using Source.Ingame.Bullet;
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
			
			_updateSystems.Add(new PlayerMovementFeature(configProvider))
				.Add(new WeaponSwitchFeature())
				.Add(new ArrowGunFeature(diContainer))
				.Add(new EnergyGunFeature(configProvider))
				.Add(new AxeFeature())
				.Add(new ProjectileFeature())
				.Add(new MeleeAttackFeature())
				.Add(new CollectableResourceFeature(configProvider))
				.Add(new EffectsFeature())
				.Add(new AbilitiesFeature(configProvider))
				.Add(new SwayFeature())
				.Add(new CameraworkFeature(configProvider))
				.Add(new VfxFeature())
				.Add(new FloatingEffectFeature())
				.Add(new GameplayCleanupSystems(Contexts.sharedInstance))
				.Add(new AiFeature(_gameplayContext))
				.Add(new BulletFeature())
				.Add(new EnvironmentFeature(_gameplayContext))
				.Add(new HealthFeature(_gameplayContext))
				.Add(new PauseMenuFeature())
				.Add(new DeadScreenFeature())
				.Add(new UnlinkEntityFromGameObjectSys());
		}

		private void Awake()
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			
			_updateSystems.Initialize();
			_fixedUpdateSystems.Initialize();

			/*_gameplayContext.OnEntityDestroyed += (context, entity) =>
			{
				if (entity is GameplayEntity { hasClearLinkOnDestroyMdl: true } ent)
				{
					ent.clearLinkOnDestroyMdl.linkedGameObject.Unlink();
				}
			};*/
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
			
			_updateSystems.DeactivateReactiveSystems();
			_fixedUpdateSystems.DeactivateReactiveSystems();
			
			_updateSystems.ClearReactiveSystems();
			_fixedUpdateSystems.ClearReactiveSystems();
			
			_gameplayContext.DestroyAllEntities();
		}
	}
}