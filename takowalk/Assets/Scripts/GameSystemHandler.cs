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
        public static GameSystemHandler Instance;

        public GameSystemUpdater Updater;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(Instance.gameObject);
            }
            
            Instance = this;
        }

        public List<GameSystemBase> GameSystemList;

        private void Start()
        {
            LoadEndEvent.AddListener(OnLoadEnd);
            LoadAsync().Forget();
        }

        private void OnLoadEnd()
        {
            Updater.gameObject.SetActive(true);
        }

        protected override async UniTask LoadAsyncInternal()
        {
            foreach (var item in GameSystemList)
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