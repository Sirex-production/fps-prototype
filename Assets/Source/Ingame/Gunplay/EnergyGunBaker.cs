using Ingame.Gunplay.Sway;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Ingame.Gunplay.EnergyGun
{
	public sealed class EnergyGunBaker : WeaponBaker
	{
		[BoxGroup("EnergyGunCmp")]
		[SerializeField] [Min(0f)] private float cooldownBetweenShots;
		
		[BoxGroup("LineRendererMdl")]
		[Required, SerializeField] [Min(0f)] private LineRenderer lineRenderer;
		
		[Inject]
		private void Construct()
		{
			var entity = Contexts.sharedInstance.gameplay.CreateEntity();
			
			BakeWeapon(entity);
			
			entity.AddEnergyGunCmp(cooldownBetweenShots, cooldownBetweenShots);
			entity.AddLineRendererMdl(lineRenderer);
		}
	}
}