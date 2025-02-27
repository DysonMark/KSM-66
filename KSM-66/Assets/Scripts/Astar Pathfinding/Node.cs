using System;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public List<Node> open;
    public List<Node> closed;
    public Vector2 currentPosition;

    
    public struct GHF
    {
        public int Gcost;
        public int Hcost;
        public int Fcost;
        
        public GHF(int g, int h)
        {
            Gcost = g;
            Hcost = h;
            Fcost = g + h;
        }
    }
    private void Start()
    {
        
    }
}
