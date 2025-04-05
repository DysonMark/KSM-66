using System.Collections;
using System.Collections.Generic;
using Dyson.GPG.Astar;
using UnityEngine;
using Grid = Dyson.GPG.Astar.Grid;

namespace Dyson.GPG.GOAP
{
    public class Patrol : Actions
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
        public Hydration _hydration;

        private bool IsCoroutineRunning = false;
        private bool playerPatrol = true;

        private Coroutine patrolRoutine;
        public void Start()
        {
            patrolIndexOne = Mathf.FloorToInt(patrolPoints[0].transform.position.y) * _gridPatrol.width +
                             Mathf.FloorToInt(patrolPoints[0].transform.position.x);
            patrolIndexTwo = Mathf.FloorToInt(patrolPoints[1].transform.position.y) * _gridPatrol.width +
                             Mathf.FloorToInt(patrolPoints[1].transform.position.x);
            patrolIndexThree = Mathf.FloorToInt(patrolPoints[2].transform.position.y) * _gridPatrol.width +
                             Mathf.FloorToInt(patrolPoints[2].transform.position.x);
        }

        public override bool CheckPrerequisites()
        {
            return _hydration.PlayerThirsty;
        }

        public override void ExecuteAction()
        {
            if (!IsCoroutineRunning)
            {
                StartCoroutine(whichPatrolIndex());
            }
            if (_hydration.PlayerNeedCriticalWater || _hydration.PlayerNotThirsty)
            {
                playerPatrol = false;
                _gridPatrol.player.transform.position = _gridPatrol.startPosition;
            }
        }
        IEnumerator whichPatrolIndex()
        {
            IsCoroutineRunning = true;
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

                if (playerPatrol)
                {
                    yield return StartCoroutine(MovePathCoroutine());
                    _patrolPath.pathIndex = 0;
                    IsCoroutineRunning = false;
                }
                yield return new WaitForSeconds(5f);
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
