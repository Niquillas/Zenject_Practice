using UnityEngine;
using Zenject;

public class ActivityInstallerHealthSystem : MonoInstaller<ActivityInstallerHealthSystem>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<ControllerHealthSystem>().FromNew().AsSingle().NonLazy();

        Container.Bind<ObjectHealthStateNormal>().FromNew().AsSingle().Lazy();
        Container.Bind<ObjectHealthStateInvulnerable>().FromNew().AsSingle().Lazy();
    }
}