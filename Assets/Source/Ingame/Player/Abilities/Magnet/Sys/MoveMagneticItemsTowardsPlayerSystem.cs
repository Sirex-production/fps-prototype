using Entitas;
using UnityEngine;

namespace Ingame.Player.Abilities.Magnet
{
	public sealed class MoveMagneticItemsTowardsPlayerSystem : IExecuteSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IGroup<GameplayEntity> _magneticItemsGroup;

		public MoveMagneticItemsTowardsPlayerSystem()
		{
			var magneticItemsMatcher = GameplayMatcher.AllOf
			(
				GameplayMatcher.MagneticItemTag,
				GameplayMatcher.RigidbodyMdl
			);

			_gameplayContext = Contexts.sharedInstance.gameplay;
			_magneticItemsGroup = _gameplayContext.GetGroup(magneticItemsMatcher);
		}

		public void Execute()
		{
			if(!_gameplayContext.hasIsMagnetActiveTag)
				return;

			if(!_gameplayContext.hasPlayerCmp)
				return;
			
			var playerEntity = _gameplayContext.playerCmpEntity;

			if(!playerEntity.hasTransformMdl)
				return;

			var magnetCmp = _gameplayContext.magnetCmp;
			var playerPos = playerEntity.transformMdl.transform.position;
			
			foreach(var entity in _magneticItemsGroup)
			{
				var magneticItemRigidbody = entity.rigidbodyMdl.rigidbody;
				
				if(Vector3.Distance(playerPos, magneticItemRigidbody.position) > magnetCmp.affectDistance)
					continue;

				var directionTowardsPlayer = Vector3.Normalize(playerPos - magneticItemRigidbody.position);
				var magneticForce = directionTowardsPlayer * magnetCmp.strength; 
				
				magneticItemRigidbody.AddForce(magneticForce * Time.deltaTime, ForceMode.Impulse);
			}
		}
	}
}