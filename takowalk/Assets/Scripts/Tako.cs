using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Takowalk
{
    public class Tako : MonoBehaviour
    {
        public PhysicsSystem PhysicsSystem;
        public TestInputManager InputManager { get; private set; }

        private void Awake()
        {
            GameSystemHandler.GameSystemLoadEndEvent.AddListener(OnGameSystemLoadEnd);
        }

        private void OnGameSystemLoadEnd()
        {
            // 임시 코드
            InputManager = GameObject.FindObjectOfType<TestInputManager>();
            GameSystemHandler.Updater.RegisterFixedUpdate(PhysicsSystem);

            RegisterAction();
        }

        private void RegisterAction()
        {
            InputManager.Controls.Tako.Point.started += OnTakoPointStarted;
            InputManager.Controls.Tako.Point.performed += OnTakoPointPerformed;
        }

        private void OnTakoPointStarted(InputAction.CallbackContext context)
        {
            Vector2 value = context.ReadValue<Vector2>();
            Debug.Log(value);
        }

        private void OnTakoPointPerformed(InputAction.CallbackContext context)
        {
            Vector2 value = context.ReadValue<Vector2>();
            Debug.Log(value);
        }
    }
}