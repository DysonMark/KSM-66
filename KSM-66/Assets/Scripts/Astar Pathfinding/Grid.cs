using System;
using Unity.VisualScripting;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [Header("Grid")]
    [SerializeField] private int height;
    [SerializeField] private int width;
    [SerializeField] private Node nodePrefab;
    
    [Header("Camera")]
    [SerializeField] private Transform cam;
    private void Start()
    {
        CreateGrid();
        CenterGridCamera();
    }

    private void CreateGrid()
    {
        for (int x = 0; x < width; x++)
        { 
            for (int y = 0; y < height; y++)
            {
                var spawnGrid = Instantiate(nodePrefab, new Vector3(x, y), Quaternion.identity);
                // String interpolation to show which Node in inspector
                spawnGrid.name = $"Node {x} {y}";
            }
        }
    }
    
    // Center the camera at the middle of the grid by dividing the grid in width and height
    private void CenterGridCamera()
    {
        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);   
    }
}
