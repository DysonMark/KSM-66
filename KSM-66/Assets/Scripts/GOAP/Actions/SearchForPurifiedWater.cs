using System.Collections;
using System.Collections.Generic;
using Dyson.GPG.Astar;
using UnityEngine;

namespace Dyson.GPG.GOAP
{
    public class SearchForPurifiedWater : Hydration
    {
        public AstarPathfinding path;
        public override void Update()
        {
            base.Update();
        }

        public override void PlayerNotThirsty()
        {
            base.PlayerNotThirsty();
        }

        public void FindWaterSource()
        {
            Debug.Log("here here");
        }
    }
}
