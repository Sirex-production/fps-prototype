using UnityEngine;

namespace EcsSupport.UnityIntegration.Physics
{
	[RequireComponent(typeof(Collider))]
	public sealed class EcsPhysicsEventChecker : MonoBehaviour
	{
		[SerializeField] private bool sendOnTriggerEnterEvents;
		[SerializeField] private bool sendOnTriggerStayEvents;
		[SerializeField] private bool sendOnTriggerExitEvents;
		[Space]
		[SerializeField] private bool sendOnCollisionEnterEvents;
		[SerializeField] private bool sendOnCollisionStayEvents;
		[SerializeField] private bool sendOnCollisionExitEvents;

		private Collider _attachedCollider;
		
		private void Awake()
		{
			_attachedCollider = GetComponent<Collider>();
		}

		private void OnTriggerEnter(Collider other)
		{
			if(sendOnTriggerEnterEvents)
				Contexts.sharedInstance.gameplay.CreateEntity().AddOnTriggerEnterEvent(other, _attachedCollider);
		}

		private void OnTriggerStay(Collider other)
		{
			if(sendOnTriggerStayEvents)
				Contexts.sharedInstance.gameplay.CreateEntity().AddOnTriggerStayEvent(other, _attachedCollider);
		}

		private void OnTriggerExit(Collider other)
		{
			if(sendOnTriggerExitEvents)
				Contexts.sharedInstance.gameplay.CreateEntity().AddOnTriggerExitEvent(other, _attachedCollider);
		}

		private void OnCollisionEnter(Collision other)
		{
			if(sendOnCollisionEnterEvents)
				Contexts.sharedInstance.gameplay.CreateEntity().AddOnCollisionEnterEvent(other, _attachedCollider);
		}
		
		private void OnCollisionStay(Collision other)
		{
			if(sendOnCollisionStayEvents)
				Contexts.sharedInstance.gameplay.CreateEntity().AddOnCollisionStayEvent(other, _attachedCollider);
		}
		
		private void OnCollisionExit(Collision other)
		{
			if(sendOnCollisionExitEvents)
				Contexts.sharedInstance.gameplay.CreateEntity().AddOnCollisionExitEvent(other, _attachedCollider);
		}
	}
}