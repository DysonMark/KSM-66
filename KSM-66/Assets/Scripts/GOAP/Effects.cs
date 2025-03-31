using System;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public List<bool> effects;
    
    // Buy a PC effect

    public bool getPoisoned;
    public bool getHydrated;
    private void Start()
    {
        effects = new List<bool>();
        effects.Add(getPoisoned);
        effects.Add(getHydrated);
    }
}
