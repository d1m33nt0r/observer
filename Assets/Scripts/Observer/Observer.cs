using System.Collections.Generic;
using Game.Scripts.Observer.Shared;
using UnityEngine;

namespace Game.Scripts.Observer
{
    public class Observer<TListener> : IObserver<TListener> where TListener : IListener
    {
        public IReadOnlyCollection<TListener> Listeners => _listeners;
        
        private readonly HashSet<TListener> _listeners = new();

        public void AddListener(TListener listener)
        {
            if (!_listeners.Contains(listener))
            {
                _listeners.Add(listener);
            }
            else
            {
                Debug.LogWarning($"Observer already contains listener {typeof(TListener).Name}");
            }   
        }

        public void RemoveListener(TListener listener)
        {
            if (_listeners.Contains(listener))
            {
                _listeners.Remove(listener);
            }
            else
            {
                Debug.LogWarning($"Observer does not contains listener {typeof(TListener).Name}");
            }
        }
    }
}