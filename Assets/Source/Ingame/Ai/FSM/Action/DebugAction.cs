using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Action
{
    [CreateAssetMenu(fileName = "DebugAction", menuName = "Ai/Action/Debug")]
    public sealed class DebugAction : ActionBase
    {
        [SerializeReference] private string message = "Hello World!!!";
        public override ActionStatus Run(AiContextMdl aiContextMdl)
        {
             Debug.Log(message);
             return ActionStatus.Done;
        }
    }
}