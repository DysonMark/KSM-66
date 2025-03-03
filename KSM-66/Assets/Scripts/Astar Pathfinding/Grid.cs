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
    [SerializeField] private Node current;
    private int cellSize;
    
    [Header("Camera")]
    [SerializeField] private Transform cam;
    
    private void Start()
    {
       /* node = new Node(new Vector2(0, 0))
        {               
            openList = new List<Node>(),
            closedList = new List<Node>(),
        };*/
       
        startPositionIndex = Mathf.FloorToInt(startPosition.y ) * width + Mathf.FloorToInt(startPosition.x);
        currentPositionIndex = Mathf.FloorToInt(currentPosition.y) * width + Mathf.FloorToInt(currentPosition.x);
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
               Debug.Log("index: " + index);
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
            
            
            Debug.Log("current pos : " + currentPosition);
            Debug.Log("start pos : " + startPosition);
            Debug.Log("goal pos : " + goalPosition);

            Cost(node.Fcost);
            Debug.Log(node.Fcost);

            /*current = startNode;
            startPositionIndex = currentPositionIndex;
            node.openList.Remove(current);
            node.closedList.Add(current);
            
            if (currentPosition == goalPosition)
            {
                Debug.Log("Found the path");
                break;
            }

            for (int i = 0; i < node.neighbourList.Count; i++)
            {
                if (node.closedList.Contains(current))
                {
                    i++;
                }
            }
            currentPositionIndex += 1;
            current = grid[currentPositionIndex];
            Debug.Log("current 1: " + current);
            node.neighbourList.Add(current);
            currentPositionIndex -= 1;
            current = grid[currentPositionIndex];
            Debug.Log("current 2: " + current);*/
            
            
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

    private int Cost(int f)
    {
        var hCost = Vector3.Distance(currentPosition, goalPosition);
        var gCost = Vector3.Distance(currentPosition, startPosition);
        var fCost = Mathf.FloorToInt(gCost + hCost);

        fCost = node.Fcost;
        return fCost;
    }
}
