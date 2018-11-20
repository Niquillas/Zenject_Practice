using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ViewUIPanelMain : MonoBehaviour
{
    [SerializeField] private Button _detectingButton;
    [SerializeField] private Button _limboButton;
    [SerializeField] private Button _scanningButton;
    [SerializeField] private Button _createHedgoHoggoButton;
    [SerializeField] private Button _disposeAllHedgoHoggosButton;

    public Button DetectingButton
    {
        get
        {
            return _detectingButton;
        }
    }

    public Button LimboButton
    {
        get
        {
            return _limboButton;
        }
    }

    public Button ScanningButton
    {
        get
        {
            return _scanningButton;
        }
    }

    public Button CreateHedgoHoggoButton
    {
        get
        {
            return _createHedgoHoggoButton;
        }
    }

    public Button DisposeAllHedgoHoggosButton
    {
        get
        {
            return _disposeAllHedgoHoggosButton;
        }
    }
}

