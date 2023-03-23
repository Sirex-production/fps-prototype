using System;
using Entitas;
using Ingame.ConfigProvision;
using Ingame.Player.Movement;
using Ingame.Ai;
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
			
			_updateSystems
				.Add(new PlayerMovementFeature(configProvider))
				.Add(new AiFeature());
			
			_fixedUpdateSystems.Add(new MoveObjectDueToVelocitySystem());
		}

		private void Awake()
		{
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