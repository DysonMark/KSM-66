using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dyson.GPG.GOAP
{
    public class Effects : MonoBehaviour
    {
        public Dictionary<string, bool> effects;
        
        // Hydration action effects
        public bool getPoisoned = false;
        public bool getHydrated = false;

        public void PoisonEffect()
        {
            getPoisoned = true;
            Debug.Log("You just got poisoned after drinking bad water");
        }

        public void WellHydrated()
        {
            getHydrated = true;
            Debug.Log("Your body is no longer dehydrated after drinking this water wow so good");
        }
    }
}
