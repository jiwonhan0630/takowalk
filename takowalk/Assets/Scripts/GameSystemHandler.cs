using Cysharp.Threading.Tasks;
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
            LoadAsync().Forget();
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