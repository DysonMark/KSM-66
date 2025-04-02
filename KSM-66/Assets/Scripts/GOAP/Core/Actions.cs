using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dyson.GPG.GOAP
{
    public class Actions : MonoBehaviour
    {
        public List<Actions> action;
        public Actions drinkPoisonedWater;
        public Actions searchWaterSource;
        public float cost;

        public enum Priority
        {
            Low = 25,
            Medium = 50,
            High = 100
        }

        public Priority priority;
        private void Start()
        {
            action = new List<Actions>();
        }

        public void ExecuteLowPriorityAction(int priority)
        {
            
        }
        
        public void ExecuteMidPriorityAction(int priority)
        {
            
        }
        
        public void ExecuteHighPriorityAction(int priority)
        {
            
        }

        public virtual void CheckPrerequisites()
        {
            
        }
    }   
}
