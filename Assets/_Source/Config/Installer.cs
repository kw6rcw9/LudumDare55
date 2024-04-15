using Core.RoomSystem;
using UISystem;
using UnityEngine;
using Zenject;

namespace Config
{
    public class Installer : MonoInstaller
    {
        [SerializeField] private Menu menu;
        [SerializeField] private GeneratorController controller;
        [SerializeField] private AgressBar bar;
        public override void InstallBindings()
        {
            Container.Bind<AgressBar>().FromInstance(bar).NonLazy();
            Container.Bind<GeneratorController>().FromInstance(controller).NonLazy();
            Container.Bind<TaskScore>().AsSingle().NonLazy();
            Container.Bind<RoomsPool>().AsTransient().NonLazy();
            Container.Bind<PlayerInput>().AsSingle().NonLazy();
            Container.Bind<Menu>().FromInstance(menu).NonLazy();
        }
    }
}