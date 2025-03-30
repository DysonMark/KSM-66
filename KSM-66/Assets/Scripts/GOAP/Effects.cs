using System;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public List<bool> effects;
    
    // Buy a PC effect

    public bool getGun;
    public bool getBullets;
    private void Start()    
    {
        effects.Add(getGun);
        effects.Add(getBullets);
    }
}
