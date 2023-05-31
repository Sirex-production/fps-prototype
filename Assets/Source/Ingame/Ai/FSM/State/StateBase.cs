using System;
using System.Collections.Generic;
using Ingame.Ai.Cmp;
using Ingame.Ai.FSM.Action;
using Ingame.Ai.FSM.Cond;
using UnityEngine;

namespace Ingame.Ai.FSM.State
{
    public abstract class StateBase : ScriptableObject
    {
        [SerializeField] 
        List<StateTransformerChecker> stateTransformerCheckers = new ();
        
        [SerializeReference] 
        List<ActionBase> actions = new ();

        [SerializeField] 
        private bool isRepeatable;
        protected abstract void OnEnter(AiContextMdl aiContextMdl);
        protected abstract void OnExit(AiContextMdl aiContextMdl);

        protected virtual void OnTick(AiContextMdl aiContextMdl)
        {
            var actionSize = actions.Count;
            ref var stateWrapper = ref aiContextMdl.aiStateWrapper;
            
            if(isRepeatable && !stateWrapper.isActionStarted )
                stateWrapper.isActionStarted = true; 
            
            for (int i = stateWrapper.actionIndex; i < actionSize; i++)
            {
                var status = actions[i].Run(aiContextMdl);
                stateWrapper.actionIndex = i;
                
                if (status == ActionStatus.Running)
                    return;
            }
            
            stateWrapper.actionIndex = actions.Count;
            stateWrapper.isActionStarted = false; 
            
            if (isRepeatable)
            {
                stateWrapper.actionIndex = 0;
            }
           
        }

        private StateBase GetState(AiContextMdl aiContextMdl)
        {
            foreach (var stateTransformer in stateTransformerCheckers)
            {
                if (stateTransformer.ShouldChangeState(aiContextMdl))
                {
                    
                    return stateTransformer.State;
                }
            }
            
            return this;
        }

        public StateBase Tick(AiContextMdl aiContextMdl)
        {
            ref var stateWrapper = ref aiContextMdl.aiStateWrapper;
            if (stateWrapper.wasStateChanged)
            {
                OnEnter(aiContextMdl);
                stateWrapper.wasStateChanged = false;
                stateWrapper.isActionStarted = true; 
            }
            
            OnTick(aiContextMdl);
            
            var state = GetState(aiContextMdl);
            
            if (state == this) 
                return this;
            
            OnExit(aiContextMdl);
            
            stateWrapper.wasStateChanged = true;
            stateWrapper.isActionStarted = false; 
            stateWrapper.actionIndex = 0;
            
            return state;
        }
    }

    [Serializable]
    public sealed class StateTransformerChecker
    {
        public enum Operator
        {
            And,
            Or
        }
        
        [SerializeField]
        private StateBase state;
        
        [SerializeField]
        private List<ConditionBase> conditions = new ();

        [SerializeField]
        private Operator logicalOperator = Operator.And;

        public StateBase State => state;

        public bool ShouldChangeState(AiContextMdl aiContextMdl)
        {
            var conditionSize = conditions.Count;

            if (conditionSize <= 0)
                return false;
            
            bool result = conditions[0].Predicate(aiContextMdl);
            for (int i = 1; i < conditionSize; i++)
            {
                if (!conditions[i].Predicate(aiContextMdl) && logicalOperator == Operator.And)
                    return false;
                
                if (conditions[i].Predicate(aiContextMdl) && logicalOperator == Operator.Or)
                    return true;

                result = logicalOperator == Operator.Or
                    ? (result || conditions[i].Predicate(aiContextMdl))
                    : (result && conditions[i].Predicate(aiContextMdl));
            }

            return result;
        }
        
    }
}