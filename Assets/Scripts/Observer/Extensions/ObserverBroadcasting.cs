using System;
using System.Linq;
using Game.Scripts.Observer.Shared;
using UnityEngine;

namespace Game.Scripts.Observer.Extensions
{
    public static class ObserverBroadcasting
    {
        public static void Broadcast<T>(this Shared.IObserver<T> obs, Action<T> call) where T : IListener
        {
            var foundNull = false;
            
            foreach (var l in obs.Listeners)
            {
                if (l == null)
                {
                    var listenerTypeName = typeof(T).Name;
                    var warningMessage = $"ObserverBroadcasting.Broadcast: listener {listenerTypeName} is NULL";
                    Debug.LogWarning(warningMessage);
                    foundNull = true;
                    continue;
                }
                
                call(l);
            }

            if (foundNull)
            {
                RemoveNullListeners(obs);
            }
        }
        
        private static void RemoveNullListeners<T>(Shared.IObserver<T> obs) where T : IListener
        {
            var listenersField = obs.Listeners;
            var nullListeners = listenersField.Where(x => x == null).ToList();
            
            foreach (var l in nullListeners)
            {
                obs.RemoveListener(l);
            }

            Debug.Log($"ObserverBroadcasting: Removed {nullListeners.Count} null listeners from {typeof(T).Name} observer");
        }
    }
}