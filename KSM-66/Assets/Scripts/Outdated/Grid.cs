using System;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private GameObject nodePrefab;
    private Node[] grid;
    [SerializeField] private int gridCountX;
    [SerializeField] private int gridCountY;
    [SerializeField]private int nodeWidth;
    [SerializeField]private int nodeHeight;
    [SerializeField] private int totalNodes;

    private void Start()
    {
        totalNodes = gridCountX * gridCountY;
        grid = new Node[totalNodes];

        for (int y = 0; y < gridCountY; y++)
        {
            for (int x = 0; x < gridCountX; x++)
            {
                int i = x + y * gridCountX;

                Vector3 halfPoint = new Vector3((float)nodeWidth / 2.0f, (float)nodeHeight / 2.0f, 0);
                Vector3 worldPosition = new Vector3(x * nodeWidth + halfPoint.x, y * nodeHeight + halfPoint.z);
                Vector3Int gridPosition = new Vector3Int(x, y, 0);
                bool isWalkable = true;
                grid[i] = new Node(worldPosition, gridPosition, isWalkable);
                grid[i].NodeGO = Instantiate(nodePrefab, worldPosition, nodePrefab.transform.rotation);
            }
        }
    }
}
