using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dyson.GPG.GOAP
{
    public class SpawnText : Actions
    {
        public Camera camera;
        public bool noPrequisites;

        public override bool CheckPrerequisites()
        {
            return noPrequisites = true;
        }

        public override void ExecuteAction()
        {
            camera.fieldOfView = 130f;
        }
    }
}
