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
        public static GameSystemUpdater Updater => Instance._updater;

        private GameSystemUpdater _updater;

        public List<GameSystemBase> gameSystemList;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(Instance.gameObject);
            }

            Instance = this;
            CreateUpdater();
        }

        private void CreateUpdater()
        {
            GameObject updaterObject = new GameObject(nameof(GameSystemUpdater));
            updaterObject.SetActive(false);
            updaterObject.transform.parent = transform;

            _updater = updaterObject.AddComponent<GameSystemUpdater>();
        }


        private void Start()
        {
            LoadEndEvent.AddListener(OnLoadEnd);
            LoadAsync().Forget();
        }

        private void OnLoadEnd()
        {
            _updater.gameObject.SetActive(true);
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