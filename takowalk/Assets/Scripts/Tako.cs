using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Takowalk
{
    public class Tako : MonoBehaviour
    {
        public TestInputManager InputManager { get; private set; }

        private void Awake()
        {
            GameSystemHandler.GameSystemLoadEndEvent.AddListener(OnGameSystemLoadEnd);
        }

        private void OnGameSystemLoadEnd()
        {
            // 임시 코드
            InputManager = GameObject.FindObjectOfType<TestInputManager>();

            RegisterAction();
        }

        private void RegisterAction()
        {
            InputManager.Controls.Tako.Point.performed += OnTakoPointPerformed;
        }

        private void OnTakoPointPerformed(InputAction.CallbackContext context)
        {
            Vector2 value = context.ReadValue<Vector2>();
         
            Vector2 pos = Camera.main.ScreenToViewportPoint(value);
            Debug.Log(pos);
        }
    }
}