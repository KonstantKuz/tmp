using StaticData;
using UnityEngine;
using Zenject;

namespace Service.SessionService
{
    [CreateAssetMenu(
        menuName = SettingsPath.Installers + nameof(SessionServiceInstaller),
        fileName = nameof(SessionServiceInstaller)
    )]
    public class SessionServiceInstaller : ScriptableObjectInstaller
    {
        [field:SerializeField]
        public GameObject SessionContextPrefab { get; private set; }

        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<SessionService>()
                .AsSingle()
                .WithArguments(this);

            Container
                .Bind<SessionBuilder>()
                .AsSingle()
                .WithArguments(SessionContextPrefab);
        }
    }
}
