using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstarPathfinding : MonoBehaviour
{
    void Start()
    {

    }
}
/*
 // Initialize two empty open and closed list
 node.openList = new List<Node>();
 node.closedList = new List<Node>();

 // Start node on the open list
 startNode = grid[startPositionIndex]; // Grid 8x8: example: startNode = 2 0
 goalNode = grid[goalPositionIndex]; // Grid 8x8: example: goalNode = 5 7

 node.openList.Add(startNode);

 //Infinite loop (will get out after I find the path)
 while (node.openList.Count > 0)
 {
     //Pathfinding
     current = node.openList[0];
     for (int i = 1; i < node.openList.Count; i++)
     {
         if (node.openList[i].Fcost < current.Fcost || node.openList[i].Fcost == current.Fcost && node.openList[i].Hcost < current.Hcost)
         {
             current = node.openList[i];
         }
     }
     node.openList.Remove(current);
     node.closedList.Add(current);

     if (current == goalNode)
     {
         GoBackToStart(startNode, goalNode);
         return;
     }

     foreach (Node newNeighbour in FindNeighbour(current, grid))
     {
         if (newNeighbour.isBlocked || node.closedList.Contains(newNeighbour))
         {
             continue;
         }
         int neighbourCost = current.Gcost + Cost(current, newNeighbour);
         if (neighbourCost < neighbour.Gcost || !node.openList.Contains(newNeighbour))
         {
             newNeighbour.Gcost = neighbourCost;
             newNeighbour.Hcost = Cost(newNeighbour, goalNode);
             newNeighbour.parent = current;

             if (!node.openList.Contains(newNeighbour))
             {
                 node.openList.Add(newNeighbour);
             }
         }
         newNeighbour.neighbourList.Add(newNeighbour);
         newNeighbour.GetComponent<SpriteRenderer>().color = Color.black;
     }
 }
}

List<Node> GoBackToStart(Node startNode, Node goalNode)
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

 if (pathIndex < path.Count)
 {
     player.transform.position = Vector3.MoveTowards(player.transform.position, path[(int)pathIndex].transform.position, playerSpeed * Time.deltaTime);
     var distance = Vector3.Distance(player.transform.position, path[(int)pathIndex].transform.position);

     if (distance <= 0.05f)
     {
         pathIndex++;
     }
 }
 return path;
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
List<Node> FindNeighbour(Node node, Node[] grid)
{
 node.X =  Mathf.FloorToInt(node.transform.position.x);
 node.Y = Mathf.FloorToInt(node.transform.position.y);

 for (int x = -1; x <= 1; x++)
 {
     for (int y = -1; y <= 1; y++)
     {
         if (x == 0 && y == 0)
             continue;
         int checkX = node.X + x;
         int checkY = node.Y + y;
         if (checkX >= 0 && checkX < width && checkY >= 0 && checkY < height)
         {
             node.neighbourList.Add(grid[checkY * width + checkX]);
         }
     }
 }
 return node.neighbourList;
}

private void Update()
{
 GoBackToStart(startNode, goalNode);
}
}
} */
