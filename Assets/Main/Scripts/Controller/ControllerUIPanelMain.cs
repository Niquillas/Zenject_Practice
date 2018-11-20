using System.Collections;
using System.Collections.Generic;
using Zenject;

public class ControllerUIPanelMain : IInitializable
{
    private readonly ServiceCenterActivtyState _activityStateCenter;
    private readonly ServiceCenterHedgoHoggo _hedgoHoggoCenter;
    private readonly ViewUIPanelMain _panelMain;

    public ControllerUIPanelMain (ViewUIPanelMain inputPanelMain, ServiceCenterActivtyState inputActivityStateCenter, ServiceCenterHedgoHoggo inputHedgoHoggoCenter)
    {
        _panelMain = inputPanelMain;
        _activityStateCenter = inputActivityStateCenter;
        _hedgoHoggoCenter = inputHedgoHoggoCenter;
    }

    public void Initialize()
    {
        _panelMain.DetectingButton.onClick.AddListener(OnDetectingButtonClicked);
        _panelMain.LimboButton.onClick.AddListener(OnLimboButtonClicked);
        _panelMain.ScanningButton.onClick.AddListener(OnScanningButtonClicked);
        _panelMain.CreateHedgoHoggoButton.onClick.AddListener(OnCreateHedgoHoggoButtonClicked);
        _panelMain.DisposeAllHedgoHoggosButton.onClick.AddListener(OnDisposeAllHedgoHoggosButtonClicked);
    }

    private void OnDetectingButtonClicked()
    {
        _activityStateCenter.TransitionCurrentState(CollectionActivityState.ActivityStateId.Detecting);
    }

    private void OnLimboButtonClicked()
    {
        _activityStateCenter.TransitionCurrentState(CollectionActivityState.ActivityStateId.Limbo);
    }

    private void OnScanningButtonClicked()
    {
        _activityStateCenter.TransitionCurrentState(CollectionActivityState.ActivityStateId.Scanning);
    }

    private void OnCreateHedgoHoggoButtonClicked()
    {
        _hedgoHoggoCenter.CreateHedgoHoggo("Hedgos Rule!!!");
    }

    private void OnDisposeAllHedgoHoggosButtonClicked()
    {
        _hedgoHoggoCenter.DisposeAllHedgoHoggos();
    }
}
