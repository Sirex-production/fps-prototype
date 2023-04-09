using Entitas;
using UnityEngine;

namespace Ingame.Player.Movement
{
	public sealed class UpdateTravelTimeSystem : IExecuteSystem
	{
		public void Execute()
		{
			var playerEntity = Contexts.sharedInstance.gameplay.playerCmpEntity;

			if(!playerEntity.hasVelocityCmp)
				return;

			var velocityCmp = playerEntity.velocityCmp;
			var horizontalVelocity = velocityCmp.currentVelocity;
			horizontalVelocity.y = 0;
			
			if(horizontalVelocity.sqrMagnitude < .1f)
				return;

			velocityCmp.timeSpentTraveling += Time.deltaTime;
		}
	}
}