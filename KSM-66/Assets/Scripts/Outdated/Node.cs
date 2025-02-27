using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Node : MonoBehaviour
{
    public Node Parent { get; set; }
    public Vector3 WorldPosition { get; set; }
    public Vector3Int GridPosition { get; set; }
    public bool IsWalkable { get; private set; }
    private int hCost;
    [SerializeField] private GameObject nodeGO;


    public Node(Vector3 worldPosition, Vector3Int gridPosition, bool isWalkable)
    {
        WorldPosition = worldPosition;
        GridPosition = gridPosition;
        IsWalkable = isWalkable;
    }
    public GameObject NodeGO
    {
        get
        {
            return nodeGO;
        }
        set
        {
            nodeGO = value;
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
