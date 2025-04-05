using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dyson.GPG.GOAP
{
    public class WorldState : MonoBehaviour
    {
        private Dictionary<string, bool> state = new Dictionary<string, bool>();

        public void SetState(string key, bool value)
        {
            state[key] = value;
        }

        public bool GetState(string key)
        {
            return state.ContainsKey(key) && state[key];
        }
    }
}
