using System;
using System.Collections;
using System.Collections.Generic;
using Dyson.GPG.GOAP;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Dyson.GPG.GOAP
{
    public class DrinkPoisonedWater : Actions
    {
        [SerializeField] private int random;
        public Hydration _hydration;
        private bool isPlayerPoisoned;
        public void Start()
        {
            random = Random.Range(0, 2);
        }
        public override bool CheckPrerequisites()
        {
            return _hydration.PlayerNeedCriticalWater;
        }

        private void Update()
        {
            if (_hydration.PlayerNeedCriticalWater)
            {
                ExecuteAction();
            }
        }

        public override void ExecuteAction()
        {
            Debug.Log("*Consume water*, you need it or you will die!");
            Debug.Log("There is 50% chance of you getting poisoned");
            
            if (random == 0)
            {
                Debug.Log("You got poisoned");
                isPlayerPoisoned = true;
            }
            else
            {
                Debug.Log("You drinked water and you are not poisoned");
               _hydration.hydrationLevel += 50;
            }
        }
    }
}
