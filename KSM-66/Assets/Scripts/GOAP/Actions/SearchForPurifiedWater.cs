using System.Collections;
using System.Collections.Generic;
using Dyson.GPG.Astar;
using UnityEngine;
using Grid = Dyson.GPG.Astar.Grid;

namespace Dyson.GPG.GOAP
{
    public class SearchForPurifiedWater : Hydration
    {
        public AstarPathfinding _path;
        public Grid _grid;
        
 /*       public override void PlayerThirsty()
        {
            base.PlayerThirsty();
            FindWaterSource();
        } */
        public void FindWaterSource()
        {
           _path.InitializePathfinding(_grid, _grid.startPositionIndex, _grid.goalPositionIndex);
           _path.MoveToPath();
        }
    }
}