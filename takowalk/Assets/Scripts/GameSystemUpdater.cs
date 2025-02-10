using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Takowalk
{
    public class GameSystemUpdater : MonoBehaviour
    {
        private List<GameSystemBase> _updateList = new();
        private List<GameSystemBase> _fixedUpdateList = new();

        private void Update()
        {
            foreach (var item in _updateList)
            {
                item.OnUpdateGameSystem();
            }
        }

        private void FixedUpdate()
        {
            foreach (var item in _fixedUpdateList)
            {
                item.OnFixedUpdateGameSystem();
            }
        }
    }
}