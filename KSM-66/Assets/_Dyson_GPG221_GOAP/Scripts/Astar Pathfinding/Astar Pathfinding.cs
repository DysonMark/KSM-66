using System;
using System.Collections.Generic;
using Dyson.GPG.GOAP;
using UnityEngine;

namespace Dyson.GPG.Astar
{
    public class AstarPathfinding : MonoBehaviour
    {
        [SerializeField] private Grid gridSystem;
        public Node startNode;
        public Node goalNode;
        private Node current;
        public float pathIndex = 0;
        public List<Node> currentPath = new List<Node>();
        public bool isPlayerMoving;
        public Patrol _patrol;
        public void InitializePathfinding(Grid grid, int startIndex, int goalIndex)
        {
            goalIndex = _patrol.patrolIndexOfficial;
            gridSystem = grid;
            startNode = gridSystem.grid[startIndex];
            goalNode = gridSystem.grid[goalIndex];
            
            FindPath(startNode, goalNode);
        }
        public void FindPath(Node startNode, Node goalNode)
        {
            List<Node> openList = new List<Node>();
            List<Node> closedList = new List<Node>();

            openList.Add(startNode);

            while (openList.Count > 0)
            {
                current = openList[0];
                for (int i = 1; i < openList.Count; i++)
                {
                    if (openList[i].Fcost < current.Fcost || openList[i].Fcost == current.Fcost && openList[i].Hcost < current.Hcost)
                    {
                        current = openList[i];
                    }
                }

                openList.Remove(current);
                closedList.Add(current);

                if (current == goalNode)
                {
                    currentPath = GoBackToStart(startNode, goalNode);
                    return;
                }

                foreach (Node newNeighbour in FindNeighbour(current, gridSystem.grid))
                {
                    if (newNeighbour.isBlocked || closedList.Contains(newNeighbour))
                    {
                        continue;
                    }

                    int neighbourCost = current.Gcost + Cost(current, newNeighbour);
                    if (neighbourCost < newNeighbour.Gcost || !openList.Contains(newNeighbour))
                    {
                        newNeighbour.Gcost = neighbourCost;
                        newNeighbour.Hcost = Cost(newNeighbour, goalNode);
                        newNeighbour.parent = current;

                        if (!openList.Contains(newNeighbour))
                        {
                            openList.Add(newNeighbour);
                        }
                    }

                    newNeighbour.neighbourList.Add(newNeighbour);
                    newNeighbour.GetComponent<SpriteRenderer>().color = Color.black;
                }
            }
        }
        public List<Node> GoBackToStart(Node startNode, Node goalNode)
        {
            List<Node> path = new List<Node>();
            Node currentNode = goalNode;

            while (currentNode != startNode)
            {
                path.Add(currentNode);
                currentNode = currentNode.parent;

                foreach (Node goodPath in path)
                {
                    goodPath.GetComponent<SpriteRenderer>().color = Color.green;
                }
            }
            path.Reverse();
            
            return path;
        }
        public void MoveToPath()
        {
            if (currentPath.Count == 0)
            {
                return;
            }
            if (pathIndex < currentPath.Count)
            {
                gridSystem.player.transform.position = Vector3.MoveTowards(gridSystem.player.transform.position, currentPath[(int)pathIndex].transform.position, gridSystem.playerSpeed * Time.deltaTime);
                var distance = Vector3.Distance(gridSystem.player.transform.position, currentPath[(int)pathIndex].transform.position);
                isPlayerMoving = true;

                if (distance <= 0.05f)
                {
                    pathIndex++;
                    isPlayerMoving = false;
                }
            }
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
        private List<Node> FindNeighbour(Node node, Node[] grid)
        {
            node.X = Mathf.FloorToInt(node.transform.position.x);
            node.Y = Mathf.FloorToInt(node.transform.position.y);

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                        continue;

                    int checkX = node.X + x;
                    int checkY = node.Y + y;

                    if (checkX >= 0 && checkX < gridSystem.width && checkY >= 0 && checkY < gridSystem.height)
                    {
                        node.neighbourList.Add(grid[checkY * gridSystem.width + checkX]);
                    }
                }
            }
            return node.neighbourList;
        }
    }
}