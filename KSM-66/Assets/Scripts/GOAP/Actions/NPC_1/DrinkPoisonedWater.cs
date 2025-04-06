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
        [SerializeField] private bool isPlayerPoisoned;
        public Actions _action;
        public Actions playerPoisoned;
        public void Start()
        {
            random = Random.Range(0, 2);
        }

        public override bool CheckPrerequisites()
        {
            return _hydration.playerNeedCriticalWater;
        }

        public override int CalculateCost()
        {
            return 2;
        }

        public override void ExecuteAction()
        {
            if (random == 0)
            {
                isPlayerPoisoned = true;
                _action.actionsList.Add(playerPoisoned);
            }
            else
            {
               _hydration.hydrationLevel += 50;
            }
            
        }
    }
}
