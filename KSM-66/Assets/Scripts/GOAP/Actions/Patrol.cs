using System.Collections;
using System.Collections.Generic;
using Dyson.GPG.Astar;
using UnityEngine;
using Grid = Dyson.GPG.Astar.Grid;

namespace Dyson.GPG.GOAP
{
    public class Patrol : Hydration
    {
        public AstarPathfinding _patrolPath;
        public Node _node;
        public List<Transform> patrolPoints;
        private int patrolIndexOne;
        private int patrolIndexTwo;
        private int patrolIndexThree;
        private int lastPatrolNumber;
        [SerializeField] public int patrolIndexOfficial;
        public List<int> randomPatrolCheck;
        public Grid _gridPatrol;
        [SerializeField] private int randomPatrol;

        public void Start()
        {
            patrolIndexOne = Mathf.FloorToInt(patrolPoints[0].transform.position.y) * _gridPatrol.width +
                             Mathf.FloorToInt(patrolPoints[0].transform.position.x);
            patrolIndexTwo = Mathf.FloorToInt(patrolPoints[1].transform.position.y) * _gridPatrol.width +
                             Mathf.FloorToInt(patrolPoints[1].transform.position.x);
            patrolIndexThree = Mathf.FloorToInt(patrolPoints[2].transform.position.y) * _gridPatrol.width +
                             Mathf.FloorToInt(patrolPoints[2].transform.position.x);
            StartCoroutine(whichPatrolIndex());
        }

        private void Patrolling()
        { 
            _patrolPath.InitializePathfinding(_gridPatrol, _gridPatrol.startPositionIndex, patrolIndexOfficial);
            _patrolPath.MoveToPath();
        }
        
        IEnumerator whichPatrolIndex()
        {
            while (true)
            {
                do
                { 
                    randomPatrol = Random.Range(0, 3);
                } while (randomPatrol == lastPatrolNumber);

                lastPatrolNumber = randomPatrol;
                if (randomPatrol == 0)
                {
                    patrolIndexOfficial = patrolIndexOne;
                }
                else if (randomPatrol == 1)
                {
                    patrolIndexOfficial = patrolIndexTwo;
                }
                else if (randomPatrol == 2)
                {
                    patrolIndexOfficial = patrolIndexThree;
                }
                _gridPatrol.player.transform.position = _gridPatrol.startPosition;
                _patrolPath.InitializePathfinding(_gridPatrol, _gridPatrol.startPositionIndex, patrolIndexOfficial);

                yield return StartCoroutine(MovePathCoroutine());
                _patrolPath.pathIndex = 0;
                yield return new WaitForSeconds(2f);
            }
        }
        private IEnumerator MovePathCoroutine()
        {
            while (_patrolPath.pathIndex < _patrolPath.currentPath.Count)
            {
                _patrolPath.MoveToPath();
                yield return null;
            }
        }
    }
}
