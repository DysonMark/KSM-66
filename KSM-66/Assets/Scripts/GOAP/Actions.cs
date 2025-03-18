using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dyson.GPG.GOAP
{
    public class Actions : MonoBehaviour
    {
        public List<Actions> action;
        public Actions buyPC;
        public int Cost;
        private void Start()
        {
            action.Add(buyPC);
        }
    }   
}
