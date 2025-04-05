using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dyson.GPG.GOAP
{
    public class GOAP : MonoBehaviour
    {
        public List<Actions> goapActions;
        //public Effects effects;
        //public Prerequisite prerequisites;
        
        private void Start()
        {
 //           effects.effects = new Dictionary<string, bool>();
        }

        private void Update()
        {
            foreach (var action in goapActions)
            {
                if (action.CheckPrerequisites())
                {
                    action.TryExecuteAction();
                    break;
                }
            }
        }
    }   
}