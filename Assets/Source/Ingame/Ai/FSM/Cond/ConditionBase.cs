using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Cond
{
    public abstract class ConditionBase : ScriptableObject
    {
        public abstract bool Predicate(AiContextMdl aiContextMdl);
    }
}