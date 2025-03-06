using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEditor.Timeline;
using UnityEngine;
using System.Linq;

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
    [SerializeField] private int currentPositionIndex;
    [SerializeField] private int goalPositionIndex;
    [SerializeField] private Node current;
    private Node startNode;
    private Node neighbour;
    private Node goalNode;
    private int cellSize;
    
    [Header("Camera")]
    [SerializeField] private Transform cam;
    
    private void Start()
    {
        startPositionIndex = Mathf.FloorToInt(startPosition.y ) * width + Mathf.FloorToInt(startPosition.x);
        currentPositionIndex = Mathf.FloorToInt(currentPosition.y) * width + Mathf.FloorToInt(currentPosition.x);
        goalPositionIndex = Mathf.FloorToInt(goalPosition.y) * width + Mathf.FloorToInt(goalPosition.x);
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
        startNode = grid[startPositionIndex]; // Grid 8x8: startNode = 2 0
        goalNode = grid[goalPositionIndex]; // Grid 8x8: goalNode = 5 7 
        node.openList.Add(startNode);
        
        //Infinite loop (will get out after I find the path)
        while (node.openList.Count > 0)
        {
            //Pathfinding
            
            // Cost(node.Fcost);
            // Debug.Log(node.Fcost);

            current = startNode;
            for (int i = 1; i < node.openList.Count; i++)
            {
                if (node.openList[i].Fcost < current.Fcost || node.openList[i].Fcost == current.Fcost && node.openList[i].Hcost < current.Hcost)
                {
                    current = node.openList[i];
                }
            }
            node.openList.Remove(current);
            node.closedList.Add(current);
            
            Debug.Log("F COST TEST: " + Cost(startNode, goalNode));
            
            if (current == goalNode)
            {
                Debug.Log("Found the path, good job!");
                return;
            }

            for (int i = 0; i < node.neighbourList.Count; i++)
            {
                if (node.closedList.Contains(current) || node.isBlocked)
                {
                    continue;
                }
                
            }
            
            // currentPositionIndex += 1;
            // current = grid[currentPositionIndex];
            // Debug.Log("current 1: " + current);
            // node.neighbourList.Add(current);
            // currentPositionIndex -= 1;
            // current = grid[currentPositionIndex];
            // Debug.Log("current 2: " + current);
            
            
            var test = grid[startPositionIndex + 2];
            var test2 = grid[startPositionIndex - 1];
            node.openList.Add(test);
            node.openList.Add(test2);
            //node.openList.Sort();
            Debug.Log("Before sorting: ");
            foreach (var node in node.openList)
            {
                Debug.Log($"Node: {node.name}, Fcost: {node.Fcost}");
            }
            node.openList.Sort();
            Debug.Log("After sorting: ");
            foreach (var node in node.openList)
            {
                Debug.Log($"Node: {node.name}, Fcost: {node.Fcost}");
            }
            break;
        }
    }
    
    // Center the camera at the middle of the grid by dividing the grid in width and height
    private void CenterGridCamera()
    {
        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);   
    }

    private int Cost(Node a, Node b)
    {
        a.X = Mathf.FloorToInt(a.transform.position.x);
        b.X = Mathf.FloorToInt(b.transform.position.x);
        a.Y = Mathf.FloorToInt(a.transform.position.y);
        b.Y = Mathf.FloorToInt(b.transform.position.y);
        
        int distanceX = Mathf.Abs(a.X - b.X);
        int distanceY = Mathf.Abs(a.Y - b.Y);

        return distanceX + distanceY;
    }

    List<Node> FindNeighbour(Node node)
    {
        node.X =  Mathf.FloorToInt(node.transform.position.x);
        node.Y = Mathf.FloorToInt(node.transform.position.y);
        
        node.X += 1; // Right neighbour
        node.X -= 1; // Left neighbour

        node.Y += 1; // Up neighbour
        node.Y -= 1; // Down neighbour

        return node.neighbourList;
    }
    
}
