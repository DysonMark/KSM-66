using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Dyson.GPG.GOAP
{
    public class Hydration : MonoBehaviour
    {
        public float hydrationLevel = 100;
        public bool playerNeedCriticalWater = false;
        public bool playerThirsty = false;
        public bool playerNotThirsty = false;
        public DrinkPoisonedWater _drinkPoisonedWater;
        public Patrol _patrol;
        public Idle _idle;
        private bool isPoisonedWaterConsumed;
        public PlayerVision _canSeeWater;
        public PlaySound _isPlayerScared;
        public TextMeshProUGUI timerText;
        public Actions _actions;
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
        }

        private void Sweat()
        {
            hydrationLevel -= 5;
        }
        public virtual void Update()
        {
            Dehydration();
            for (int i = 0; i < _actions.actionsList.Count; i++)
            {
                if (_actions.actionsList.Contains(_drinkPoisonedWater.playerPoisoned))
                {
                    playerThirsty = false;
                }
            }
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
            timerText.text = hydrationLevel.ToString();
            
            if (hydrationLevel <= 100 && hydrationLevel >= 50)
            {
                thirstyLevel = ThirstyLevel.NotThirsty;
                playerNotThirsty = true;
                playerThirsty = false;
                playerNeedCriticalWater = false;
                PlayerIsNotThirsty();
            }

            else if (hydrationLevel <= 50 && hydrationLevel >= 0)
            {
                thirstyLevel = ThirstyLevel.Thirsty;
                playerThirsty = true;
                playerNeedCriticalWater = false;
                playerNotThirsty = false;
                PlayerIsThirsty();
            }
            else
            {
                thirstyLevel = ThirstyLevel.NeedWaterNow;
                playerNeedCriticalWater = true;
                playerThirsty = false;
                playerNotThirsty = false;
                PlayerNeedWater();
            }
        }
    }
}