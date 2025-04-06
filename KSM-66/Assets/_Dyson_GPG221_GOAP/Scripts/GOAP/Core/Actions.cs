using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dyson.GPG.GOAP
{
    public class Actions : MonoBehaviour
    {
        public float Cost { get; set; }
        private bool hasActionBeenExecuted = false;
        public List<Actions> actionsList;

        public virtual void ExecuteAction()
        {
            
        }

        public virtual int CalculateCost()
        {
            return -1;
        }
        private void Awake()
        {
            Cost = CalculateCost();
            actionsList = new List<Actions>();
        }

        public virtual bool CheckPrerequisites()
        {
            return true;
        }
        public void TryExecuteAction()
        {
            if (!hasActionBeenExecuted && CheckPrerequisites())
            {
                ExecuteAction();
                hasActionBeenExecuted = true;
            }
        }
    }   
}
