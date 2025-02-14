using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Takowalk
{
    public class TestInputManager : GameSystemBase
    {
        public TestControls Controls { get; private set; }

        protected override UniTask LoadAsyncInternal()
        {
            Controls = new();
            GameSystemHandler.GameSystemLoadEndEvent.AddListener(OnGameSystemLoadEnd);

            return UniTask.CompletedTask;
        }

        private void OnGameSystemLoadEnd()
        {
            Controls?.Enable();
        }
        private void OnDisable()
        {
            Controls?.Disable();
        }
    }
}