using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dyson.GPG.GOAP
{
    public class Actions : MonoBehaviour
    {
        public List<Actions> action;
        public Actions buyGun;
        public Actions waitForBullets;
        public Actions waitForGun;
        public int Cost;
        private void Start()
        {
            action.Add(buyGun);
            action.Add(waitForBullets);
            action.Add(waitForGun);
        }
    }   
}
