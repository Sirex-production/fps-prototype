using System;
using Entitas;
using Ingame.Ai.FSM.State;
using UnityEngine.Serialization;

namespace Ingame.Ai.Cmp
{
    [Serializable]
    public struct AiStateWrapper  
    {
        public StateBase currentState;
        public bool wasStateChanged;
        public int actionIndex;
        public bool isActionStarted;
    }
}