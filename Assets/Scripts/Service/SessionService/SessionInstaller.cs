using Zenject;

namespace Service.SessionService
{
    public class SessionInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ISession>().FromInstance(GetComponent<ISession>()).AsSingle();
        }
    }
}
