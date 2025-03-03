using System;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

public class Node : MonoBehaviour, IComparable<Node>
{
    public List<Node> openList;
    public List<Node> closedList;
    public List<Node> neighbourList;
    public Vector2 worldPosition;
    public bool isBlocked;
    public int Gcost;
    public int Hcost;
    public int Fcost;

    public Node(Vector2 WorldPosition)
    {
        WorldPosition = worldPosition;
    }

    public int GettingGcost(int g)
    {
        Gcost = g;
        return g;
    }
    
    public int GettingHcost(int h)
    {
        Hcost = h;
        return h;
    }
    
    public void GettingFcost()
    {
        Fcost = Gcost + Hcost;
    }

    public int CompareTo(Node other)
    {
        if (other == null)
        {
            return 1;
        }
        else
        {
            return Fcost.CompareTo(other.Fcost);
        }
    }
}
