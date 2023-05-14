using NaughtyAttributes;
using UnityEngine;

namespace Ingame.Ai.FSM
{
    public class AiFlyingBombEventHandler : MonoBehaviour
    {
     
        [SerializeField] 
        [Required]
        private ParticleSystem fire;
        
        [SerializeField] 
        [Required]
        private ParticleSystem explosion;
        
        [Required]
        [SerializeField]
        private AiBaker aiBaker;
        public void Explode()
        {
            var meshes = GetComponentsInChildren<MeshRenderer>();
            foreach (var mesh in meshes)
            {
                mesh.enabled = false;
            }
            
            explosion.gameObject.SetActive(true);
        }
        
       
        private void StopFireIfOutOfRange( )
        {
            var distance = Vector3.Distance(aiBaker.NavMeshAgent.transform.position, aiBaker.Entity.aiContextMdl.player.position);
            if (distance < aiBaker.AIConfig.AttackVisionRange)
                return;

            StopFire();
        }

        private void StopFire( )
        {
            fire.gameObject.SetActive(false);
        }
        
        private void StartFire()
        {
            fire.gameObject.SetActive(true);
        }
        
    }
}