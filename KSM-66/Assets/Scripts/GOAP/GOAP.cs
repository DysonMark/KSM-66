using System;
using UnityEngine;

namespace Dyson.GPG.GOAP
{
    public class GOAP : MonoBehaviour
    {
        public Actions actions;
        public Effects effects;
        public Prerequisite prerequisite;

        private void BuyAPC()
        {
            if (prerequisite.hasGun)
            {
                effects.getGun = true;
            }
        }
    }   
}
