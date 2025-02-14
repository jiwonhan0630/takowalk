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
        private TestControls _controls;

        protected override UniTask LoadAsyncInternal()
        {
            _controls = new();

            _controls.Tako.Move.performed += OnTakoMovePerformed;
            return UniTask.CompletedTask;
        }

        private void OnTakoMovePerformed(InputAction.CallbackContext context)
        {

        }
    }
}