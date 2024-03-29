﻿using System;
using System.Collections.Generic;
using Ingame.Ai.Cmp;
using NaughtyAttributes;
using UnityEngine;

namespace Ingame.Ai.FSM.Action
{
  
    public enum ActionStatus
    {
        Done,
        Running
    }
    
    public abstract class ActionBase : ScriptableObject
    {
        public abstract ActionStatus Run(AiContextMdl aiContextMdl);
    }
}