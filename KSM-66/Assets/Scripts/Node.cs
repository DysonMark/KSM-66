using UnityEngine;

public class Node : MonoBehaviour
{
    public Node Parent { get; set; }
    public Vector3 WorldPosition { get; set; }
    public Vector3Int GridPosition { get; set; }
    public bool IsWalkable { get; private set; }
    private int hCost;
    private GameObject nodeGO;

    public GameObject NodeGO
    {
        get
        {
            return NodeGO;
        }
        set
        {
            
        }
    }

    public int HCost
    {
        get
        {
            return hCost;
        }
        set
        {
            hCost = value;
        }
    }

    private int gCost;

    public int GCost
    {
        get
        {
            return gCost;
        }
        set
        {
            gCost = value;
        }
    }

    private int fCost;
    
    public int FCost
    {
        get
        {
            return gCost + hCost;
        }
    }
}
