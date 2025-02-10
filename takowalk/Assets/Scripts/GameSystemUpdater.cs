using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Takowalk
{
    public class GameSystemUpdater : MonoBehaviour
    {
        private List<GameSystemBase> _updateList = new();
        private List<GameSystemBase> _fixedUpdateList = new();

        public void RegisterUpdate(GameSystemBase gameSystem)
        {
            var old = _updateList.FindIndex((item) => gameSystem.GetType() == item.GetType());
            if (old >= 0)
            {
                _updateList.RemoveAt(old);
            }

            _updateList.Add(gameSystem);
        }

        public void RegisterFixedUpdate(GameSystemBase gameSystem)
        {
            var old = _fixedUpdateList.FindIndex((item) => gameSystem.GetType() == item.GetType());
            if (old >= 0)
            {
                _fixedUpdateList.RemoveAt(old);
            }

            _fixedUpdateList.Add(gameSystem);
        }

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