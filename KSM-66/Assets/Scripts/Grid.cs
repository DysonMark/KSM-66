using System;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private Node[] grid;
    [SerializeField] private int gridCountX;
    [SerializeField] private int gridCountZ;
    [SerializeField]private int nodeWidth;
    [SerializeField]private int nodeHeight;
    [SerializeField] private int totalNodes;

    private void Start()
    {
        totalNodes = gridCountX * gridCountZ;
        grid = new Node[totalNodes];

        for (int z = 0; z < gridCountZ; z++)
        {
            for (int x = 0; x < gridCountX; x++)
            {
                int i = x + z * gridCountX;

                Vector3 halfPoint = new Vector3((float)nodeWidth / 2.0f, (float)nodeHeight / 2.0f, 0);
                Vector3 worldPosition = new Vector3(x * nodeWidth + halfPoint.x, z * nodeHeight + halfPoint.z);
                Vector3Int gridPosition = new Vector3Int(x, z, 0);
                bool isWalkable = true;
                grid[i] = new Node(worldPosition, gridPosition, isWalkable);
            }
        }
    }
}
