using System.Threading.Tasks;
using Game.Scripts.Observer.Extensions;
using Game.Scripts.Observer.Shared;
using GameLoop.Shared;
using UnityEngine;
using Zenject;

namespace GameLoop
{
    public class GameLoop : MonoBehaviour, IGameLoop
    {
        [Inject] private IObserver<IGameLoopListener> observer;

        private async void Start()
        {
            Run();
            await Task.Delay(1000);
            Stop();
        }

        public void Run()
        {
            observer.Broadcast(l => l.OnGameLoopStarted());
        }

        public void Stop()
        {
            observer.Broadcast(l => l.OnGameLoopFinished());
        }
    }
}