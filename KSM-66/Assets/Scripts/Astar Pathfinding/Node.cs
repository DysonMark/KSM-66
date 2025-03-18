using System.Collections.Generic;
using UnityEngine;

namespace Dyson.GPG.Astar
{
    public class Node : MonoBehaviour
    {
        public List<Node> openList;
        public List<Node> closedList;
        public List<Node> neighbourList;
        public bool isBlocked;
        public int Gcost;
        public int Hcost;
        public int Fcost;
        public int X;
        public int Y;
        public Node parent;

        [Header("Obstacle")] private RaycastHit hit;

        public LayerMask layerMask;

        public void BlockedNode()
        {
            isBlocked = false;
            layerMask = LayerMask.GetMask("Obstacle");
            Vector3 boxCenter = transform.position;
            Vector3 halfExtents = new Vector3((float)0.5, (float)0.5, (float)0.5);
            Vector3 boxSize = new Vector3(1, 1, 1);
            float angle = 0f;
            Collider[] hits = Physics.OverlapBox(boxCenter, boxSize);

            bool hitBox = Physics.CheckBox(boxCenter, halfExtents, Quaternion.identity, layerMask,
                QueryTriggerInteraction.Ignore);

            if (hitBox)
            {
                GetComponent<SpriteRenderer>().color = Color.yellow;
                isBlocked = true;
            }
        }

        private void OnDrawGizmos()
        {
            Vector3 boxSize = new Vector3((float)0.6, (float)0.8, 1);
            // Set the color of the Gizmo
            Gizmos.color = Color.magenta;

            // Store current matrix and apply rotation
            Matrix4x4 rotationMatrix = Matrix4x4.TRS(transform.position, Quaternion.Euler(0, 0, 0), Vector3.one);
            Gizmos.matrix = rotationMatrix;

            // Draw the box (centered at the object's position)
            Gizmos.DrawWireCube(Vector3.zero, boxSize);
        }

        private void Awake()
        {
            BlockedNode();
        }
    }
}