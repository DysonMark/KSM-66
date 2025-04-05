using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grid = Dyson.GPG.Astar.Grid;

namespace Dyson.GPG.GOAP
{
    public class Idle : Actions
    {
        public Grid _gridIdle;
        public Hydration _hydration;

        public override bool CheckPrerequisites()
        {
            return _hydration.PlayerNotThirsty;
        }

        public override void ExecuteAction()
        {
            _gridIdle.player.transform.position = _gridIdle.startPosition;
        }
    }
}
