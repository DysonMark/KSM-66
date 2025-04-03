using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dyson.GPG.GOAP
{
    public class GOAP : MonoBehaviour
    {
        public Actions actions;
        public Effects effects;
        public Prerequisite prerequisites;
        
        private void Start()
        {
            effects.effects = new Dictionary<string, bool>();
            prerequisites.prerequisites = new Dictionary<string, bool>();
        }
    }   
}