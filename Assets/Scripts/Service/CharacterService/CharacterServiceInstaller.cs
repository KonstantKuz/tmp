using StaticData;
using UnityEngine;
using Zenject;

namespace Service.CharacterService
{
    [CreateAssetMenu(
        menuName = SettingsPath.Installers + nameof(CharacterServiceInstaller),
        fileName = nameof(CharacterServiceInstaller)
    )]
    public class CharacterServiceInstaller : ScriptableObjectInstaller
    {
        [field:SerializeField]
        public GameObject PlayerPrefab { get; private set; }

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CharacterService>().AsSingle().WithArguments(this);
        }
    }
}
