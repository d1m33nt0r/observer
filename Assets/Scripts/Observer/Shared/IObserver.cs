using System.Collections.Generic;

namespace Game.Scripts.Observer.Shared
{
    public interface IObserver<TListener> where TListener : IListener
    {
        IReadOnlyCollection<TListener> Listeners { get; }
        void AddListener(TListener listener);
        void RemoveListener(TListener listener);
    }
}