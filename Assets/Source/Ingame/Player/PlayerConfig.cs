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
		[FormerlySerializedAs("accelerationDumping")]
		[BoxGroup("Movement")]
		[SerializeField] [Range(0f, 1f)] private float frictionDumping = .2f;
		[BoxGroup("Movement")]
		[SerializeField] [Min(0f)] private float jumpForce = 10f;
		[BoxGroup("Movement")]
		[SerializeField] [Min(0f)] private float gravityForce = 10f;

		public float AccelerationSpeed => accelerationSpeed;
		public float FrictionDumping => frictionDumping;
		public float JumpForce => jumpForce;
		public float GravityForce => gravityForce;
	}
}