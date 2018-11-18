using UnityEngine;
using Zenject;

public class ActivityInstallerHealthSystem : MonoInstaller<ActivityInstallerHealthSystem>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<ControllerHealthSystem>().FromNew().AsSingle().NonLazy();

        Container.Bind<ModelHealthStateNormal>().FromNew().AsSingle().Lazy();
        Container.Bind<ModelHealthStateInvulnerable>().FromNew().AsSingle().Lazy();
    }
}