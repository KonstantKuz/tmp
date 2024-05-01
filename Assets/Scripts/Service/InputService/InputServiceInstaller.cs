using UnityEngine;
using Zenject;

namespace Service.InputService
{
    [CreateAssetMenu(
        menuName = GlobalSettings.InstallersPath + nameof(InputServiceInstaller),
        fileName = nameof(InputServiceInstaller)
    )]
    public class InputServiceInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private GameObject inputPrefab;

        public override void InstallBindings()
        {
            Container.InstantiatePrefab(inputPrefab, Container.DefaultParent);
            Container
                .BindInterfacesAndSelfTo<InputService>()
                .AsSingle();
        }
    }
}
