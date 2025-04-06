using System.Collections.Generic;
using UnityEngine;

namespace Dyson.GPG.Astar
{
    public class Node : MonoBehaviour
    {
        public List<Node> openList;
        public List<Node> closedList;
        public List<Node> neighbourList = new List<Node>();
        public bool isBlocked;
        public int Gcost;
        public int Hcost;
        public int Fcost { get { return Gcost + Hcost; } }
        public int X;
        public int Y;
        public Node parent;

        [Header("Obstacle")] 
        private RaycastHit hit;
        public LayerMask layerMask;

        public void BlockedNode()
        {
            isBlocked = false;
            layerMask = LayerMask.GetMask("Obstacle");
            Vector3 boxCenter = transform.position;
            Vector3 halfExtents = new Vector3(0.5f, 0.5f, 0.5f);

            bool hitBox = Physics.CheckBox(boxCenter, halfExtents, Quaternion.identity, layerMask, QueryTriggerInteraction.Ignore);

            if (hitBox)
            {
                GetComponent<SpriteRenderer>().color = Color.yellow;
                isBlocked = true;
            }
        }
        private void OnDrawGizmos()
        {
            Vector3 boxSize = new Vector3(0.6f, 0.8f, 1);
            Gizmos.color = Color.magenta;
            Matrix4x4 rotationMatrix = Matrix4x4.TRS(transform.position, Quaternion.Euler(0, 0, 0), Vector3.one);
            Gizmos.matrix = rotationMatrix;
            Gizmos.DrawWireCube(Vector3.zero, boxSize);
        }

        private void Awake()
        {
            BlockedNode();
        }
    }
}