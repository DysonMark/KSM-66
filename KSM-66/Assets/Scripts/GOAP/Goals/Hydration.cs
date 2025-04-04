using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dyson.GPG.GOAP
{
    public class Hydration : MonoBehaviour
    {
        public float hydrationLevel = 100;
        public bool PlayerNeedCriticalWater = false;
        public enum ThirstyLevel
        {
            NotThirsty = 100,
            Thirsty = 50,
            NeedWaterNow = 0
        }
        public ThirstyLevel thirstyLevel;
        
        public virtual void Update()
        {
            Dehydration();
        }

        private int EnumToIntConverter(Enum enumIntValue)
        {
            return Convert.ToInt32(enumIntValue);
        }

        private void Dehydration()
        {
            hydrationLevel -= 1 * Time.deltaTime;

            if (hydrationLevel <= 100 && hydrationLevel >= 50)
            {
                thirstyLevel = ThirstyLevel.NotThirsty;
            }

            if (hydrationLevel <= 50 && hydrationLevel >= 0)
            {
                thirstyLevel = ThirstyLevel.Thirsty;
            }

            if (hydrationLevel <= 0)
            {
                thirstyLevel = ThirstyLevel.NeedWaterNow;
                PlayerNeedCriticalWater = true;
            }
        }
    }
}