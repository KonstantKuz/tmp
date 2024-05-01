using UnityEngine;
using Zenject;

namespace Service.Factory
{
    [CreateAssetMenu(
        menuName = GlobalSettings.InstallersPath + nameof(FactoriesInstaller),
        fileName = nameof(FactoriesInstaller)
    )]
    public class FactoriesInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<DefaultFactory>()
                .AsSingle();
        }
    }
}
