using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Takowalk
{
    public class GameSystemHandler : GameSystemBase
    {
        public static GameSystemHandler Instance { get; private set; }

        public GameSystemUpdater updater;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(Instance.gameObject);
            }
            
            Instance = this;
        }

        public List<GameSystemBase> gameSystemList;

        private void Start()
        {
            LoadEndEvent.AddListener(OnLoadEnd);
            LoadAsync().Forget();
        }

        private void OnLoadEnd()
        {
            updater.gameObject.SetActive(true);
        }

        protected override async UniTask LoadAsyncInternal()
        {
            foreach (var item in gameSystemList)
            {
                if (item.IsLoaded)
                {
                    continue;
                }

                await item.LoadAsync();
            }
            IsLoaded = true;
        }
    }
}