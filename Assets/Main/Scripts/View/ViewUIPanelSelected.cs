using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ViewUIPanelSelected : ViewUIPanel
{
    [SerializeField] private Button _colorButton;
    [SerializeField] private Button _deleteButton;

    public void SetColorButtonOnClick(UnityAction inputCallback)
    {
        _colorButton.onClick.AddListener(inputCallback);
    }

    public void SetDeleteButtonOnClick(UnityAction inputCallback)
    {
        _deleteButton.onClick.AddListener(inputCallback);
    }
}

