using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dyson.GPG.GOAP
{
    public class GOAP : MonoBehaviour
    {
        public List<Actions> goapActions;
        public Actions _actions;
        private Actions bestAction;
        private float cost;
        private void WhichActions()
        {
            float lowestCost = float.MaxValue;
            
            foreach (var action in goapActions)
            {
                if (action.CheckPrerequisites())
                {
                    cost = _actions.CalculateCost();
                    if (cost < lowestCost)
                    {
                        lowestCost = cost;
                        bestAction = action;
                    }
                }
            }
            _actions = bestAction;
        }
        private void Update()
        {
            WhichActions();

            if (_actions != null)
            {
                _actions.TryExecuteAction();
            }
        }
    }   
}