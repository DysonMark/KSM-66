using System;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public List<Node> openList;
    public List<Node> closedList;
    public List<Node> neighbourList;
    public Vector2 worldPosition;
    public bool isBlocked;

    public Node(Vector2 WorldPosition)
    {
        WorldPosition = worldPosition;
    }
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
}
