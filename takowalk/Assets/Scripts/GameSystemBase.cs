using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Takowalk
{
    public class GameSystemBase : MonoBehaviour
    {
        public bool IsLoaded { get; protected set; }

        public UnityEvent LoadEndEvent { get; protected set; } = new();

        public async UniTask LoadAsync()
        {
            await LoadAsyncInternal();
            LoadEndEvent.Invoke();
        }

        protected virtual UniTask LoadAsyncInternal()
        {
            IsLoaded = true;
            return UniTask.CompletedTask;
        }

        public virtual void OnUpdateGameSystem()
        {

        }

        public virtual void OnFixedUpdateGameSystem()
        {

        }
    }
}