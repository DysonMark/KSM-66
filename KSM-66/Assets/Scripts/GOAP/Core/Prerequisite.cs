using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

namespace Dyson.GPG.GOAP
{
    public class Prerequisite : MonoBehaviour
    {
        public Dictionary<string, bool> prerequisites;
        
        public bool waterIsNearby;
        public bool noConditions;
    }    
}

