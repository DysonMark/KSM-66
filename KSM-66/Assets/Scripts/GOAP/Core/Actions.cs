using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dyson.GPG.GOAP
{
    public abstract class Actions : MonoBehaviour
    {
        public float cost;
        private bool hasActionBeenExecuted = false;
        public abstract void ExecuteAction();
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
