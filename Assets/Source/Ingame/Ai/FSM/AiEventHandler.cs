using UnityEngine;

namespace Ingame.Ai.FSM
{
    public sealed class AiEventHandler : MonoBehaviour
    {
        private void Attack()
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
            Debug.Log("Attack");
        }

        private void Dodge()
        {
            GetComponent<Animator>().SetBool("IsDodging", false);
            Debug.Log("Dodge");
        }
    }
}