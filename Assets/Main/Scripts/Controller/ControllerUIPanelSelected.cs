public class ControllerUIPanelSelected : System.IDisposable
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
        _selectedCenter.ViewSelectedEvent += OnViewSelected;
        _panelSelected.SetColorButtonOnClick(OnColorButtonClicked);
        _panelSelected.SetDeleteButtonOnClick(OnDeleteButtonClicked);
    }

    public void OnColorButtonClicked()
    {
        _selectedCenter.ColorAllSelected();
    }

    public void OnDeleteButtonClicked()
    {
        _selectedCenter.DeleteAllSelected();
    }

    public void OnViewSelected(int inputCount)
    {
        _panelSelected.SetActive(inputCount > 0);
    }

    public void Dispose()
    {
        _selectedCenter.ViewSelectedEvent -= OnViewSelected;
    }
}
