using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dyson.GPG.GOAP
{
    public class Hydration : Actions
    {
        private float timer = 100;
        public Prerequisite prerequisitesHydration;
        public enum ThirstyLevel
        {
            NotThirsty = 100,
            Thirsty = 50,
            NeedWaterNow = 0
        }
        public ThirstyLevel thirstyLevel;
        private void Start()
        { 
            
        }

        // Update is called once per frame
        void Update()
        {
            HydrationLevel();
        }

        private int EnumToIntConverter(Enum enumIntValue)
        {
            return Convert.ToInt32(enumIntValue);
        }

        public void PlayerNotThirsty()
        {
            ExecuteLowPriorityAction(EnumToIntConverter(ThirstyLevel.NotThirsty));
        }
        
        public void PlayerThirsty()
        {
            ExecuteLowPriorityAction(EnumToIntConverter(ThirstyLevel.Thirsty));
        }
        
        public void PlayerNeedCriticalWater()
        {
            ExecuteLowPriorityAction(EnumToIntConverter(ThirstyLevel.NeedWaterNow));
        }
        public override void CheckPrerequisites()
        {
            base.CheckPrerequisites();
        }

        private void HydrationLevel()
        {
            timer -= 1 * Time.deltaTime;

            if (timer <= 100 && timer >= 50)
            {
                thirstyLevel = ThirstyLevel.NotThirsty;
            }

            if (timer <= 50 && timer >= 0)
            {
                thirstyLevel = ThirstyLevel.Thirsty;
            }

            if (timer <= 0)
            {
                thirstyLevel = ThirstyLevel.NeedWaterNow;
            }
        }
    }
}