using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dyson.GPG.GOAP
{
    public abstract class Actions : MonoBehaviour
    {
        public float cost;
        public abstract void ExecuteAction();
        public virtual bool CheckPrerequisites()
        {
            return true;
        }
    }   
}
