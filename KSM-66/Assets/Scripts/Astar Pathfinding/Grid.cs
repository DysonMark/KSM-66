using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [Header("Grid")]
    [SerializeField] private int height;
    [SerializeField] private int width;
    [SerializeField] private GameObject nodePrefab;
    [SerializeField] public Node node;
    public Vector3 currentPosition;
    public Vector3 goalPosition;
    public Vector3 startPosition;
    [SerializeField] public Node[] grid;
    [SerializeField] int totalNodes;
    [SerializeField] private int startPositionIndex;
    [Header("Camera")]
    [SerializeField] private Transform cam;
    private void Start()
    {
       /* node = new Node(new Vector2(0, 0))
        {               
            openList = new List<Node>(),
            closedList = new List<Node>(),
        };*/
        startPositionIndex = (int)(startPosition.y * width + startPosition.x);
        CreateGrid();
        CenterGridCamera();
    }

    private void CreateGrid()
    {
        // Get the number of nodes in the map
        totalNodes = width * height;
        grid = new Node[totalNodes];
        
        // Loops through y first for better access to memory
        
        for (int y = 0; y < height; y++)
        { 
            for (int x = 0; x < width; x++)
            {
               var index = y * width + x;
                var spawnGrid = Instantiate(nodePrefab, new Vector3(x, y), Quaternion.identity);
                grid[index] = spawnGrid.GetComponent<Node>();
                
                if (goalPosition.x > width || goalPosition.x < 0 || goalPosition.y > height || goalPosition.y < 0)
                {
                    Debug.LogError("Out of grid");
                }

                if (startPosition.x > width || startPosition.x < 0 || startPosition.y > height || startPosition.y < 0)
                {
                    Debug.LogError("Out of grid");
                }

                #region Colors
                
                if (spawnGrid.transform.position == startPosition)
                {
                    spawnGrid.GetComponent<SpriteRenderer>().color = Color.cyan;
                }
                if (spawnGrid.transform.position == goalPosition)
                {
                    spawnGrid.GetComponent<SpriteRenderer>().color = Color.red;
                }
                #endregion
                // String interpolation to show which Node in inspector
                spawnGrid.name = $"Node {x} {y}";
            }
        }
        
        // Initialize two empty open and closed list
        node.openList = new List<Node>();
        node.closedList = new List<Node>();
        
        // Start node on the open list
        Node startNode = grid[startPositionIndex];
        Debug.Log("start node: " + startNode);
        Debug.Log("startPosIndex: " + startPositionIndex);
        node.openList.Add(startNode);
        Debug.Log("node list: " + node.openList.Contains(startNode));
        //Infinite loop (will get out after I find the path)
        while (node.openList.Count > 0)
        {
            //Pathfinding
            var hCost = Vector3.Distance(currentPosition, goalPosition);
            var gCost = Vector3.Distance(currentPosition, startPosition);
            
            Node.GHF cost = new Node.GHF((int)gCost, ((int)hCost));
            
            cost.Fcost = (int)gCost + (int)hCost;
            node.openList.Sort();
            foreach (var item in node.openList)
            {
                Debug.Log("item: " + item);
            }
            Debug.Log("G cost: " + cost.Gcost);
            Debug.Log("H cost: " + cost.Hcost);
            Debug.Log("F cost: " + cost.Fcost);
            Debug.Log(cost.Fcost);
            if (currentPosition == goalPosition)
            {
                Debug.Log("Found the goal");
                break;
            }
            break;
        }
    }
    
    // Center the camera at the middle of the grid by dividing the grid in width and height
    private void CenterGridCamera()
    {
        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);   
    }
}
