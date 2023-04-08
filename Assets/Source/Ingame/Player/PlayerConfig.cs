using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

namespace Ingame.Player
{
	[CreateAssetMenu(menuName = "Configs/PlayerConfig")]
	public sealed class PlayerConfig : ScriptableObject
	{
		[BoxGroup("Movement")]
		[SerializeField] [Min(0f)] private float accelerationSpeed = 1f;
		[BoxGroup("Movement")]
		[SerializeField] [Range(0f, 1f)] private float frictionDumping = .000001f;
		[BoxGroup("Movement")]
		[SerializeField] [Range(0f, 1f)] private float accelerationDumping = .5f;
		[BoxGroup("Movement")]
		[SerializeField] [Min(0f)] private float jumpForce = 10f;
		[BoxGroup("Movement")]
		[SerializeField] [Min(0f)] private float gravityForce = 10f;
		
		[BoxGroup("Movement")]
		[SerializeField] [Min(0f)] private float dashDuration = .1f;
		[BoxGroup("Movement")]
		[SerializeField] [Min(0f)] private float dashSpeed = 10f;
		[BoxGroup("Movement")]
		[SerializeField] [Min(0f)] private float dashCooldown = 2f;

		public float AccelerationSpeed => accelerationSpeed;
		public float FrictionDumping => frictionDumping;
		public float AccelerationDumping => accelerationDumping;
		public float JumpForce => jumpForce;
		public float GravityForce => gravityForce;

		public float DashDuration => dashDuration;
		public float DashSpeed => dashSpeed;
		public float DashCooldown => dashCooldown;
	}
}