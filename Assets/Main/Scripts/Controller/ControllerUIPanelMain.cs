using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ControllerUIPanelMain : IInitializable
{
    [Inject] private ServiceLogger _serviceLogger;

    private readonly ServiceCenterActivty _activityCenter;
    private readonly ViewUIPanelMain _panelMain;

    public ControllerUIPanelMain (ViewUIPanelMain inputPanelMain, ServiceCenterActivty inputActivityCenter)
    {
        _panelMain = inputPanelMain;
        _activityCenter = inputActivityCenter;
    }

    public void Initialize()
    {
        _panelMain.DetectingButton.onClick.AddListener(OnDetectingButtonClicked);
        _panelMain.LimboButton.onClick.AddListener(OnLimboButtonClicked);
        _panelMain.ScanningButton.onClick.AddListener(OnScanningButtonClicked);
    }

    private void OnDetectingButtonClicked()
    {
        _activityCenter.TransitionCurrentState(CollectionActivityState.ActivityStateId.Detecting);
    }

    private void OnLimboButtonClicked()
    {
        _activityCenter.TransitionCurrentState(CollectionActivityState.ActivityStateId.Limbo);
    }

    private void OnScanningButtonClicked()
    {
        _activityCenter.TransitionCurrentState(CollectionActivityState.ActivityStateId.Scanning);
    }
}
