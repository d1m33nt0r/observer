
using Game.Scripts.Observer.Shared;
using GameLoop.Shared;
using UnityEngine;
using Zenject;

namespace GameLoopListeningExample
{
    public class GameLoopListener : MonoBehaviour, IGameLoopListener
    {
        [Inject] private IObserver<IGameLoopListener> observer;

        private void OnEnable()
        {
            observer.AddListener(this);
        }

        private void OnDisable()
        {
            observer.RemoveListener(this);
        }

        public void OnGameLoopStarted()
        {
            Debug.Log("Game Loop On Started!");
        }

        public void OnGameLoopFinished()
        {
            Debug.Log("Game Loop On Finished!");
        }
    }
}