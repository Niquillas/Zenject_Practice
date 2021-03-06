﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ViewUIPanelMain : ViewUIPanel
{
    [SerializeField] private Text _currentActivityStateText;
    [SerializeField] private Button _creatingButton;
    [SerializeField] private Button _selectingButton;
    [SerializeField] private Button _coloringButton;
    [SerializeField] private Button _deletingButton;
    [SerializeField] private Button _savingButton;
    [SerializeField] private Button _loadingButton;

    public void SetCreatingButtonOnClick(UnityAction inputCallback)
    {
        _creatingButton.onClick.AddListener(inputCallback);
    }

    public void SetSelectingButtonOnClick(UnityAction inputCallback)
    {
        _selectingButton.onClick.AddListener(inputCallback);
    }

    public void SetColoringButtonOnClick(UnityAction inputCallback)
    {
        _coloringButton.onClick.AddListener(inputCallback);
    }

    public void SetDeletingButtonOnClick(UnityAction inputCallback)
    {
        _deletingButton.onClick.AddListener(inputCallback);
    }

    public void SetSavingButtonOnClick(UnityAction inputCallback)
    {
        _savingButton.onClick.AddListener(inputCallback);
    }

    public void SetLoadingButtonOnClick(UnityAction inputCallback)
    {
        _loadingButton.onClick.AddListener(inputCallback);
    }

    public void SetCurrentActivityStateText (string inputText)
    {
        _currentActivityStateText.text = inputText;
    }
}

