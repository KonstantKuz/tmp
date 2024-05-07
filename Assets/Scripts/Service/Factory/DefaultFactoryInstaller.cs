using UnityEngine;
using Zenject;

namespace Service.Factory
{
    [CreateAssetMenu(
        menuName = GlobalSettings.InstallersPath + nameof(DefaultFactoryInstaller),
        fileName = nameof(DefaultFactoryInstaller)
    )]
    public class DefaultFactoryInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<DefaultFactory>()
                .AsSingle();
        }
    }
}
