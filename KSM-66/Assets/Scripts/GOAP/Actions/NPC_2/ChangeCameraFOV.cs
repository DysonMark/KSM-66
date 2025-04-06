using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dyson.GPG.GOAP
{
    public class ChangeCameraFOV : Actions
    {
        public Camera camera;
        public bool noPrequisites;

        public override bool CheckPrerequisites()
        {
            return noPrequisites = true;
        }

        public override void ExecuteAction()
        {
            camera.fieldOfView = 100f;
        }

        public override int CalculateCost()
        {
            return 0;
        }
    }
}
