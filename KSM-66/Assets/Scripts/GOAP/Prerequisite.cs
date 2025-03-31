using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

namespace Dyson.GPG.GOAP
{
    public class Prerequisite : MonoBehaviour
    {
        public List<bool> prerequisites;

        public int Cost;    
        // Buy a PC
        public bool waterIsNearby;
        public bool noConditions;
        
        private void Start()
        {
            prerequisites = new List<bool>();
            prerequisites.Add(waterIsNearby);
            prerequisites.Add(noConditions);
        }

        private void Update()
        {
            
        }
    }    
}

