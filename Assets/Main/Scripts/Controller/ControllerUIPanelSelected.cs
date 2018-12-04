public class ControllerUIPanelSelected
{
    private readonly ServiceCenterSelected _selectedCenter;
    private readonly ViewUIPanelSelected _panelSelected;

    public ControllerUIPanelSelected (ViewUIPanelSelected inputPanelSelected, ServiceCenterSelected inputSelectedCenter)
    {
        _panelSelected = inputPanelSelected;
        _selectedCenter = inputSelectedCenter;
    }

    [Zenject.Inject]
    public void Initialize()
    {
        _panelSelected.SetActive(false);
        _selectedCenter.HedgoHoggoSelectedEvent += OnHedgoHoggoSelected;
    }

    public void OnHedgoHoggoSelected(int inputCount)
    {
        _panelSelected.SetActive(inputCount > 0);
    }
}
