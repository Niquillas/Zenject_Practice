using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ApplicationInstallerMain : MonoInstaller
{
    [SerializeField] private bool _debugLogsEnabled;
    [SerializeField] private ServiceMonoRunner _monoRunner;
    [SerializeField] private ViewHedgoHoggo _hedgoHoggoViewPrefab;
    [SerializeField] private ViewPointer _pointerViewPrefab;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private ViewUIPanelMain _mainPanelView;
    [SerializeField] private ViewUIPanelSelected _selectedPanelView;
    [SerializeField] private LayerMask _viewCollisionLayerMask;

    public override void InstallBindings()
    {
        // Application Layer
        Container.BindInterfacesAndSelfTo<ApplicationRoot>().FromNew().AsSingle().Lazy();

        // View Layer
        Container.BindInterfacesAndSelfTo<ViewUIPanelMain>().FromInstance(_mainPanelView).AsSingle().Lazy();
        Container.BindInterfacesAndSelfTo<ViewUIPanelSelected>().FromInstance(_selectedPanelView).AsSingle().Lazy();
        Container.BindFactory<ObjectHedgoHoggo, ViewHedgoHoggo, ViewHedgoHoggo.Factory>().FromMonoPoolableMemoryPool(
            x => x.FromComponentInNewPrefab(_hedgoHoggoViewPrefab).UnderTransformGroup("HedgoHoggoViews"));
        Container.BindFactory<ObjectPointer, ViewPointer, ViewPointer.Factory>().FromMonoPoolableMemoryPool(
            x => x.FromComponentInNewPrefab(_pointerViewPrefab).UnderTransformGroup("Pointers"));

        // Controller Layer
        Container.BindInterfacesAndSelfTo<ControllerUIPanelMain>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<ControllerUIPanelSelected>().FromNew().AsSingle().NonLazy();

        // Model Service Layer
        Container.BindInterfacesAndSelfTo<ServiceCenterHedgoHoggo>().FromNew().AsSingle().Lazy();
        Container.BindInterfacesAndSelfTo<ServiceCenterActivtyState>().FromNew().AsSingle().Lazy();
        Container.BindInterfacesAndSelfTo<ServiceCenterSelected>().FromNew().AsSingle().Lazy();
        Container.BindInterfacesAndSelfTo<ServiceInput>().FromNew().AsSingle().WithArguments(_mainCamera).Lazy();
        Container.BindInterfacesAndSelfTo<ServiceUtility>().FromNew().AsSingle().Lazy();
        Container.BindInterfacesAndSelfTo<ServiceLogger>().FromNew().AsSingle().WithArguments(_debugLogsEnabled).Lazy();
        Container.BindInterfacesAndSelfTo<ServiceMonoRunner>().FromInstance(_monoRunner).AsSingle().Lazy();
        
        // Model Collection Layer
        Container.BindInterfacesAndSelfTo<CollectionActivityState>().FromNew().AsSingle().Lazy();
        Container.BindInterfacesAndSelfTo<CollectionHedgoHoggo>().FromNew().AsSingle().Lazy();
        Container.BindInterfacesAndSelfTo<CollectionSelected>().FromNew().AsSingle().Lazy();

        // Model Object Layer
        Container.BindInterfacesAndSelfTo<ObjectActivityStateCreating>().FromNew().AsSingle().WithArguments(_viewCollisionLayerMask).Lazy();
        Container.BindInterfacesAndSelfTo<ObjectActivityStateSelecting>().FromNew().AsSingle().WithArguments(_viewCollisionLayerMask).Lazy();
        Container.BindInterfacesAndSelfTo<ObjectActivityStateColoring>().FromNew().AsSingle().WithArguments(_viewCollisionLayerMask).Lazy();
        Container.BindInterfacesAndSelfTo<ObjectActivityStateDeleting>().FromNew().AsSingle().WithArguments(_viewCollisionLayerMask).Lazy();
        Container.BindFactory<ObjectHedgoHoggo, ObjectHedgoHoggo.Factory>();
        Container.BindFactory<ObjectPointer, ObjectPointer.Factory>();
    }
}
