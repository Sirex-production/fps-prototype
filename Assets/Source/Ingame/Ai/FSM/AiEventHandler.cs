using NaughtyAttributes;
using UnityEngine;

namespace Ingame.Ai.FSM
{
    public class AiEventHandler : MonoBehaviour
    {
        [Required] [SerializeField] private Animator animator;
        private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
        private static readonly int IsDodging = Animator.StringToHash("IsDodging");

        private void ReleaseAttackAnimation()
        {
            animator.SetBool(IsAttacking, false);
        }

        private void Attack()
        {
            
        }
        
        private void ReleaseDodgeAnimation()
        {
            animator.SetBool(IsDodging, false);
        }
    }
}