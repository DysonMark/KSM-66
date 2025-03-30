using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

namespace Dyson.GPG.GOAP
{
    public class Prerequisite : MonoBehaviour
    {
        public List<bool> prequisite;

        public int Cost;    
        // Buy a PC
        public bool hasGun; 
        private void Start()
        {
            prequisite.Add(hasGun);
            StartCoroutine(WaitForGun());
        }

        private void Update()
        {
            BuyGun();
        }

        private void BuyGun()
        {
            hasGun = false;
            if (Input.GetKeyDown(KeyCode.E))
            {
                hasGun = true;
                Cost += 5;
                Debug.Log("Bought gun");
                Debug.Log("Cost value: " + Cost);
            }
        }

        IEnumerator WaitForGun()
        {
            Debug.Log("Waiting for a gun...");
            yield return new WaitForSeconds(10);
            Debug.Log("Received gun");
            hasGun = true;
        }
    }    
}

