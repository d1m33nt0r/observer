using Game.Scripts.Observer.Shared;

namespace GameLoop.Shared
{
    public interface IGameLoopListener : IListener
    {
        void OnGameLoopStarted();
        void OnGameLoopFinished();
    }
}