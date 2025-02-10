using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Takowalk
{
    public class GameSystemUpdater : MonoBehaviour
    {
        public UnityEvent UpdateEvent { get; private set; } = new();
        public UnityEvent FixedUpdateEvent { get; private set; } = new();


        private void Update()
        {
            UpdateEvent.Invoke();
        }

        private void FixedUpdate()
        {
            FixedUpdateEvent.Invoke();
        }

    }
}