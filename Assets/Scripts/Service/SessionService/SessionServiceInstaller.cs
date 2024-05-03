using UnityEngine;
using Zenject;

namespace Service.SessionService
{
    [CreateAssetMenu(
        menuName = GlobalSettings.InstallersPath + nameof(SessionServiceInstaller),
        fileName = nameof(SessionServiceInstaller)
    )]
    public class SessionServiceInstaller : ScriptableObjectInstaller
    {
        [field:SerializeField]
        public GameObject NetworkPrefab { get; set; }

        [field:SerializeField]
        public GameObject PlayerPrefab { get; set; }

        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<SessionService>()
                .AsSingle()
                .WithArguments(this);

            Container
                .Bind<SessionBuilder>()
                .AsSingle()
                .WithArguments(NetworkPrefab);
        }
    }
}
