using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dyson.GPG.GOAP
{
    public class Hydration : Actions
    {
        public float hydrationLevel = 100;
        public Prerequisite prerequisitesHydration;
        public enum ThirstyLevel
        {
            NotThirsty = 100,
            Thirsty = 50,
            NeedWaterNow = 0
        }
        public ThirstyLevel thirstyLevel;
        public virtual void Start()
        { 
            
        }

        // Update is called once per frame
        public virtual void Update()
        {
            Dehydration();
        }

        private int EnumToIntConverter(Enum enumIntValue)
        {
            return Convert.ToInt32(enumIntValue);
        }

        public virtual void PlayerNotThirsty()
        {
            ExecuteLowPriorityAction(EnumToIntConverter(ThirstyLevel.NotThirsty));
        }
        
        public virtual void PlayerThirsty()
        {
            ExecuteMidPriorityAction(EnumToIntConverter(ThirstyLevel.Thirsty));
        }
        
        public virtual void PlayerNeedCriticalWater()
        {
            ExecuteHighPriorityAction(EnumToIntConverter(ThirstyLevel.NeedWaterNow));
        }
        public override void CheckPrerequisites()
        {
            base.CheckPrerequisites();
        }

        private void Dehydration()
        {
            hydrationLevel -= 1 * Time.deltaTime;

            if (hydrationLevel <= 100 && hydrationLevel >= 50)
            {
                thirstyLevel = ThirstyLevel.NotThirsty;
                PlayerNotThirsty();
            }

            if (hydrationLevel <= 50 && hydrationLevel >= 0)
            {
                thirstyLevel = ThirstyLevel.Thirsty;
                PlayerThirsty();
            }

            if (hydrationLevel <= 0)
            {
                thirstyLevel = ThirstyLevel.NeedWaterNow;
                PlayerNeedCriticalWater();
            }
        }
    }
}