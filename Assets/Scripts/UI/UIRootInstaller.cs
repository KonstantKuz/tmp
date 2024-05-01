using UnityEngine;
using Zenject;

namespace UI
{
    [CreateAssetMenu(
        menuName = GlobalSettings.InstallersPath + nameof(UIRootInstaller),
        fileName = nameof(UIRootInstaller)
    )]
    public class UIRootInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private UIRoot uiRootPrefab;

        public override void InstallBindings()
        {
            Container
                .Bind<UIRoot>()
                .FromComponentInNewPrefab(uiRootPrefab.gameObject)
                .AsSingle()
                .NonLazy();
        }
    }
}
