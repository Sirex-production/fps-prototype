using NaughtyAttributes;
using UnityEngine;

namespace Ingame.Ai.SpecialActions
{
    public abstract class SpecialActionBase : MonoBehaviour
    {
        [SerializeField] [Required] protected AiBaker aiBaker;

        protected abstract void Act();
        
    }
}