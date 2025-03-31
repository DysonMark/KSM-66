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
        public int Cost;
        private void Start()
        {
            action = new List<Actions>();
            action.Add(drinkPoisonedWater);
            action.Add(searchWaterSource);
        }
    }   
}
