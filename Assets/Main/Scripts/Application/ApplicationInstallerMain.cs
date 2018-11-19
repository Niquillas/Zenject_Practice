using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ApplicationInstallerMain : MonoInstaller
{
    [SerializeField] private bool _debugLogsEnabled;
    [SerializeField] private ServiceMonoRunner _monoRunner;
    [SerializeField] private ViewUIPanelMain _panelMain;
    
    public override void InstallBindings()
    {
        // Application Layer
        Container.BindInterfacesAndSelfTo<ApplicationRoot>().FromNew().AsSingle().Lazy();

        // Model Object Layer
        Container.BindInterfacesAndSelfTo<ObjectActivityStateLimbo>().FromNew().AsSingle().Lazy();
        Container.BindInterfacesAndSelfTo<ObjectActivityStateScanning>().FromNew().AsSingle().Lazy();
        Container.BindInterfacesAndSelfTo<ObjectActivityStateDetecting>().FromNew().AsSingle().Lazy();

        // Model Service Layer
        Container.BindInterfacesAndSelfTo<CollectionActivityState>().FromNew().AsSingle().Lazy();
        Container.BindInterfacesAndSelfTo<ServiceCenterActivty>().FromNew().AsSingle().Lazy();
        Container.BindInterfacesAndSelfTo<ServiceLogger>().FromNew().AsSingle().WithArguments(_debugLogsEnabled).Lazy();
        Container.BindInterfacesAndSelfTo<ServiceMonoRunner>().FromInstance(_monoRunner).AsSingle().Lazy();

        // Controller UI Layer
        Container.BindInterfacesAndSelfTo<ControllerUIPanelMain>().FromNew().AsSingle().WithArguments(_panelMain).Lazy();
    }
}
