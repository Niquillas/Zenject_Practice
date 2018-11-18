using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ApplicationInstallerMain : MonoInstaller
{
    [SerializeField] private bool _debugLogsEnabled;
    [SerializeField] private ServiceMonoRunner _monoRunner;

    public override void InstallBindings()
    {
        // Service Layer
        Container.BindInterfacesAndSelfTo<ServiceFacade>().FromNew().AsSingle().Lazy();
        Container.BindInterfacesAndSelfTo<ServiceLogger>().FromNew().AsSingle().WithArguments(_debugLogsEnabled).Lazy();
        Container.BindInterfacesAndSelfTo<ServiceMonoRunner>().FromInstance(_monoRunner).AsSingle().Lazy();

        // Application Layer
        Container.BindInterfacesAndSelfTo<ApplicationActivityCenter>().FromNew().AsSingle().Lazy();

        // Model Layer Activity States
        Container.BindInterfacesAndSelfTo<ModelActivityStateScanning>().FromNew().AsSingle().Lazy();
        Container.BindInterfacesAndSelfTo<ModelActivityStateLimbo>().FromNew().AsSingle().Lazy();
        Container.BindInterfacesAndSelfTo<ModelActivityStateDetecting>().FromNew().AsSingle().Lazy();
    }
}
