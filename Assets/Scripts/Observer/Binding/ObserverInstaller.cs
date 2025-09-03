using Game.Scripts.Observer.Shared;
using Zenject;

namespace Game.Scripts.Observer.Binding
{
    public class ObserverInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind(typeof(IObserver<>))
                .To(typeof(Observer<>))
                .AsSingle();
        }
    }
}