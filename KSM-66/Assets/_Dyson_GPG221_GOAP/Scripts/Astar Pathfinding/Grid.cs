using System.Collections.Generic;
using Dyson.GPG.GOAP;
using Unity.Mathematics;
using UnityEngine;

namespace Dyson.GPG.Astar
{
    public class Grid : MonoBehaviour
    {
        [Header("Grid")]
        [SerializeField] public int height;
        [SerializeField] public int width;
        [SerializeField] private GameObject nodePrefab;
        public Vector3 currentPosition;
        public Vector3 goalPosition;
        public Vector3 startPosition;
        [SerializeField] public Node[] grid;
        [SerializeField] private int totalNodes;
        [SerializeField] public int startPositionIndex;
        [SerializeField] private int currentPositionIndex;
        [SerializeField] public int goalPositionIndex;
        public Patrol _patrol;
        [Header("Camera")]
        [SerializeField] private Transform cam;

        [Header("Player")] 
        public GameObject player;
        public float playerSpeed = 2f;

        private void Start()
        {
         //   player = Instantiate(player);
            player.transform.position = startPosition;
            startPositionIndex = Mathf.FloorToInt(startPosition.y) * width + Mathf.FloorToInt(startPosition.x);
            currentPositionIndex = Mathf.FloorToInt(currentPosition.y) * width + Mathf.FloorToInt(currentPosition.x);
            goalPositionIndex = Mathf.FloorToInt(goalPosition.y) * width + Mathf.FloorToInt(goalPosition.x);
            //goalPositionIndex = _patrol.patrolIndexOfficial;
            CreateGrid();
            CenterGridCamera();
        }

        private void CreateGrid()
        {
            totalNodes = width * height;
            grid = new Node[totalNodes];

            for (int y = 0; y < height; y++)
            { 
                for (int x = 0; x < width; x++)
                {
                    int index = y * width + x;
                    var spawnGrid = Instantiate(nodePrefab, new Vector3(x, y), Quaternion.identity);
                    grid[index] = spawnGrid.GetComponent<Node>();

                    if (spawnGrid.transform.position == startPosition)
                    {
                        spawnGrid.GetComponent<SpriteRenderer>().color = Color.cyan;
                    }

                    spawnGrid.name = $"Node {x} {y}";
                }
            }
        }

        private void CenterGridCamera()
        {
            cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
        }
    }
}