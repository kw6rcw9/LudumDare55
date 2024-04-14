using Core.RoomSystem;
using UISystem;
using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    [SerializeField] private Menu menu;
    [SerializeField] private GeneratorController controller;
    public override void InstallBindings()
    {
        Container.Bind<GeneratorController>().FromInstance(controller).NonLazy();
        Container.Bind<RoomsPool>().AsTransient().NonLazy();
        Container.Bind<PlayerInput>().AsSingle().NonLazy();
        Container.Bind<Menu>().FromInstance(menu).NonLazy();
    }
}