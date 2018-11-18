using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIPanelMain : MonoBehaviour 
{
    [SerializeField] private Button _detectingButton;
    [SerializeField] private Button _limboButton;
    [SerializeField] private Button _scanningButton;

    [Inject] private ServiceFacade _serviceFacade;

    private void Awake()
    {
        _detectingButton.onClick.AddListener(OnDetectingButtonClicked);
        _limboButton.onClick.AddListener(OnLimboButtonClicked);
        _scanningButton.onClick.AddListener(OnScanningButtonClicked);
    }

    private void OnDetectingButtonClicked()
    {
        _serviceFacade.Logger.Log("OnDetectingButtonClicked");
    }

    private void OnLimboButtonClicked()
    {
        _serviceFacade.Logger.Log("OnLimboButtonClicked");
    }

    private void OnScanningButtonClicked()
    {
        _serviceFacade.Logger.Log("OnScanningButtonClicked");
    }
}
