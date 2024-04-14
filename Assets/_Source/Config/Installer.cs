using UISystem;
using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    [SerializeField] private Menu menu;
    public override void InstallBindings()
    {
        Container.Bind<PlayerInput>().AsSingle().NonLazy();
        Container.Bind<Menu>().FromInstance(menu).NonLazy();
    }
}