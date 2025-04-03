using System.Collections;
using System.Collections.Generic;
using Dyson.GPG.GOAP;
using UnityEngine;

namespace Dyson.GPG.GOAP
{
    public class DrinkPoisonedWater : Hydration
    {
        [SerializeField] private int random;
        public override void Start()
        {
            base.Start();
            random = Random.Range(0, 2);

        }

        public override void Update()
        {
            base.Update();
        }

        public override void PlayerNeedCriticalWater()
        {
            base.PlayerNeedCriticalWater();
            
            //TODO: If water is nearby and player is really thirsty, consume water
            
            Debug.Log("*Consume water*, you need it or you will die!");
            Debug.Log("There is 50% chance of you getting poisoned");

            if (random == 0)
            {
                Debug.Log("You got poisoned");
            }
           if (random == 1)
            {
                Debug.Log("You drinked water and you are not poisoned");
                hydrationLevel += 50;
            }
            
        }
    }
}
