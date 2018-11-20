using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ApplicationInstallerMain : MonoInstaller
{
    [SerializeField] private bool _debugLogsEnabled;
    [SerializeField] private ServiceMonoRunner _monoRunner;
    [SerializeField] private ObjectHedgoHoggo _hedgoHoggoPrefab;
    [SerializeField] private ViewUIPanelMain _panelMain;
    
    public override void InstallBindings()
    {
        // Application Layer
        Container.BindInterfacesAndSelfTo<ApplicationRoot>().FromNew().AsSingle().Lazy();

        // View Layer
        Container.BindInterfacesAndSelfTo<ViewUIPanelMain>().FromInstance(_panelMain).AsSingle().Lazy();

        // Controller Layer
        Container.BindInterfacesAndSelfTo<ControllerUIPanelMain>().FromNew().AsSingle().Lazy();

        // Model Service Layer
        Container.BindInterfacesAndSelfTo<ServiceCenterHedgoHoggo>().FromNew().AsSingle().Lazy();
        Container.BindInterfacesAndSelfTo<ServiceCenterActivtyState>().FromNew().AsSingle().Lazy();
        Container.BindInterfacesAndSelfTo<ServiceLogger>().FromNew().AsSingle().WithArguments(_debugLogsEnabled).Lazy();
        Container.BindInterfacesAndSelfTo<ServiceMonoRunner>().FromInstance(_monoRunner).AsSingle().Lazy();

        // Model Collection Layer
        Container.BindInterfacesAndSelfTo<CollectionActivityState>().FromNew().AsSingle().Lazy();
        Container.BindInterfacesAndSelfTo<CollectionHedgoHoggo>().FromNew().AsSingle().Lazy();

        // Model Object Layer
        Container.BindInterfacesAndSelfTo<ObjectActivityStateLimbo>().FromNew().AsSingle().Lazy();
        Container.BindInterfacesAndSelfTo<ObjectActivityStateScanning>().FromNew().AsSingle().Lazy();
        Container.BindInterfacesAndSelfTo<ObjectActivityStateDetecting>().FromNew().AsSingle().Lazy();
        Container.BindFactory<ObjectHedgoHoggo, ObjectHedgoHoggo.Factory>().FromMonoPoolableMemoryPool<ObjectHedgoHoggo>(
            x => x.WithInitialSize(10).FromComponentInNewPrefab(_hedgoHoggoPrefab).UnderTransformGroup("HedgoHoggos"));
    }
}
