using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dyson.GPG.GOAP
{
    public class Prerequisite : MonoBehaviour
    {
        public List<bool> prequisite;
    
        // Buy a PC
        public bool hasMoney; 
        private void Start()
        {
            prequisite.Add(hasMoney);
        }
    }    
}

