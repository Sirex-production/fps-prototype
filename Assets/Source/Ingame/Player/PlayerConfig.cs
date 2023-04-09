using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

namespace Ingame.Player
{
	[CreateAssetMenu(menuName = "Configs/PlayerConfig")]
	public sealed class PlayerConfig : ScriptableObject
	{
		[BoxGroup("Common")]
		[SerializeField] [Min(0f)] private float defaultPlayerHeight = 2f;
		[BoxGroup("Common")]
		[SerializeField] [Range(0f, 1f)] private float playerHighChangeDumping = .0001f;
		
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
		
		[BoxGroup("Dash")]
		[SerializeField] [Min(0f)] private float dashDuration = .1f;
		[BoxGroup("Dash")]
		[SerializeField] [Min(0f)] private float dashSpeed = 10f;
		[BoxGroup("Dash")]
		[SerializeField] [Min(0f)] private float dashCooldown = 2f;
		
		[BoxGroup("Sliding")]
		[SerializeField] [Min(0f)] private float playerHeightWhileSliding = 2f;
		[BoxGroup("Sliding")]
		[SerializeField] [Min(0f)] private float slidingDuration = 1f;
		[BoxGroup("Sliding")]
		[SerializeField] [Min(0f)] private float slidingSpeed = 10f;
		[BoxGroup("Sliding")]
		[SerializeField] [Min(0f)] private float slidingCooldown = 1f;
		

		public float DefaultPlayerHeight => defaultPlayerHeight;
		public float PlayerHighChangeDumping => playerHighChangeDumping;

		public float AccelerationSpeed => accelerationSpeed;
		public float FrictionDumping => frictionDumping;
		public float AccelerationDumping => accelerationDumping;
		public float JumpForce => jumpForce;
		public float GravityForce => gravityForce;

		public float DashDuration => dashDuration;
		public float DashSpeed => dashSpeed;
		public float DashCooldown => dashCooldown;

		public float PlayerHeightWhileSliding => playerHeightWhileSliding;
		public float SlidingDuration => slidingDuration;
		public float SlidingSpeed => slidingSpeed;
		public float SlidingCooldown => slidingCooldown;
	}
}