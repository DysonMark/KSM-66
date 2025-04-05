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
        public bool PlayerThirsty = false;
        public bool PlayerNotThirsty = false;
        public DrinkPoisonedWater _drinkPoisonedWater;
        public Patrol _patrol;
        public Idle _idle;
        private bool isPoisonedWaterConsumed;
        public PlayerVision _canSeeWater;
        public PlaySound _isPlayerScared;
        public enum ThirstyLevel
        {
            NotThirsty = 100,
            Thirsty = 50,
            NeedWaterNow = 0
        }
        public ThirstyLevel thirstyLevel;

        private void Awake()
        {
            _canSeeWater.OnWaterSeen += DrinkWater;
            _isPlayerScared.onPlayerScared += Sweat;
        }

        private void DrinkWater()
        {
            hydrationLevel += 5;
            Debug.Log("Water has been seen and drinked");
        }

        private void Sweat()
        {
            hydrationLevel -= 5;
            Debug.Log("Player got scared and lost -5 hydrationLevel");
        }
        public virtual void Update()
        {
            Dehydration();
        }

        private int EnumToIntConverter(Enum enumIntValue)
        {
            return Convert.ToInt32(enumIntValue);
        }
        private void PlayerNeedWater()
        {
            if (_drinkPoisonedWater != null && _drinkPoisonedWater.CheckPrerequisites())
            {
                _drinkPoisonedWater.ExecuteAction();
            }
        }

        private void PlayerIsThirsty()
        {
            if (_patrol != null & _patrol.CheckPrerequisites())
            {
                _patrol.ExecuteAction();
            }
        }

        private void PlayerIsNotThirsty()
        {
            if (_idle != null & _idle.CheckPrerequisites())
            {
                _idle.ExecuteAction();
            }
        }
        private void Dehydration()
        {
            hydrationLevel -= 1 * Time.deltaTime;
            
            if (hydrationLevel <= 100 && hydrationLevel >= 50)
            {
                thirstyLevel = ThirstyLevel.NotThirsty;
                PlayerNotThirsty = true;
                PlayerThirsty = false;
                PlayerNeedCriticalWater = false;
                PlayerIsNotThirsty();
            }

            else if (hydrationLevel <= 50 && hydrationLevel >= 0)
            {
                thirstyLevel = ThirstyLevel.Thirsty;
                PlayerThirsty = true;
                PlayerNeedCriticalWater = false;
                PlayerNotThirsty = false;
                PlayerIsThirsty();
            }
            else
            {
                thirstyLevel = ThirstyLevel.NeedWaterNow;
                PlayerNeedCriticalWater = true;
                PlayerThirsty = false;
                PlayerNotThirsty = false;
                PlayerNeedWater();
            }
        }
    }
}