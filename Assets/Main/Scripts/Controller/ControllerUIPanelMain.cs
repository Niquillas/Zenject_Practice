using Zenject;

public class ControllerUIPanelMain
{
    private readonly ServiceCenterHedgoHoggo _hedgoHoggoCenter;
    private readonly ServiceCenterActivtyState _activityStateCenter;
    private readonly ViewUIPanelMain _panelMain;

    public ControllerUIPanelMain (ViewUIPanelMain inputPanelMain, ServiceCenterHedgoHoggo inputHedgoHoggoService, ServiceCenterActivtyState inputActivityStateCenter)
    {
        _panelMain = inputPanelMain;
        _hedgoHoggoCenter = inputHedgoHoggoService;
        _activityStateCenter = inputActivityStateCenter;
    }

    [Inject]
    public void Initialize()
    {
        _activityStateCenter.CurrentStateChangedEvent += OnActivityStateChanged;
        _panelMain.SetCreatingButtonOnClick(OnCreatingButtonClicked);
        _panelMain.SetSelectingButtonOnClick(OnSelectingButtonClicked);
        _panelMain.SetDeletingButtonOnClick(OnDeletingButtonClicked);
        _panelMain.SetColoringButtonOnClick(OnColoringButtonClicked);
        _panelMain.SetSavingButtonOnClick(OnSavingButtonClicked);
        _panelMain.SetLoadingButtonOnClick(OnLoadingButtonClicked);
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

    private void OnSavingButtonClicked()
    {
        _hedgoHoggoCenter.Save();
    }

    private void OnLoadingButtonClicked()
    {
        _hedgoHoggoCenter.Load();
    }

    public void OnActivityStateChanged(string inputStateName)
    {
        _panelMain.SetCurrentActivityStateText(inputStateName);
    }
}
