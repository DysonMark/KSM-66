using System;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public List<bool> effects;
    
    // Buy a PC effect

    public bool getPC;
    private void Start()    
    {
        effects.Add(getPC);
    }
}
