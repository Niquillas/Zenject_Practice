using System.Collections;
using System.Collections.Generic;
using Zenject;

public class ControllerUIPanelMain : IInitializable
{
    private readonly ServiceCenterActivtyState _activityStateCenter;
    private readonly ViewUIPanelMain _panelMain;

    public ControllerUIPanelMain (ViewUIPanelMain inputPanelMain, ServiceCenterActivtyState inputActivityStateCenter)
    {
        _panelMain = inputPanelMain;
        _activityStateCenter = inputActivityStateCenter;
    }

    public void Initialize()
    {
        _panelMain.SetCreatingButtonOnClick(OnCreatingButtonClicked);
        _panelMain.SetSelectingButtonOnClick(OnSelectingButtonClicked);
        _panelMain.SetDeletingButtonOnClick(OnDeletingButtonClicked);
        _panelMain.SetColoringButtonOnClick(OnColoringButtonClicked);

    }

    private void OnCreatingButtonClicked()
    {
        _activityStateCenter.TransitionCurrentState(CollectionActivityState.ActivityStateId.Creating);
    }

    private void OnSelectingButtonClicked()
    {
        _activityStateCenter.TransitionCurrentState(CollectionActivityState.ActivityStateId.Selecting);
    }

    private void OnColoringButtonClicked()
    {
        _activityStateCenter.TransitionCurrentState(CollectionActivityState.ActivityStateId.Coloring);
    }

    private void OnDeletingButtonClicked()
    {
        _activityStateCenter.TransitionCurrentState(CollectionActivityState.ActivityStateId.Deleting);
    }
}
