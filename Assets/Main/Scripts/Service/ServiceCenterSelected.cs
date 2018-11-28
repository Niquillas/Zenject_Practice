using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceCenterSelected
{
    private CollectionSelected _selectedCollection;

    public ServiceCenterSelected (CollectionSelected inputSelectedCollection)
    {
        _selectedCollection = inputSelectedCollection;
    }

    public bool CheckIfHedgoHoggoSelected(ViewHedgoHoggo inputHedgoHoggoView)
    {
        return _selectedCollection.CheckIfRegistered(inputHedgoHoggoView.Id);
    }

    public void SelectHedgoHoggo(ViewHedgoHoggo inputHedgoHoggoView)
    {
        _selectedCollection.RegisterSelected(inputHedgoHoggoView.Id);
    }

    public void DeSelectHedgoHoggo(ViewHedgoHoggo inputHedgoHoggoView)
    {
        _selectedCollection.UnregisterSelected(inputHedgoHoggoView.Id);
    }

    public void DeSelectAllHedgoHoggos ()
    {
        List<int> hedgoHoggoIds = _selectedCollection.AllSelected;
        for (int i = 0; i < hedgoHoggoIds.Count; i++)
        {
            _selectedCollection.UnregisterSelected(hedgoHoggoIds[i]);
        }
    }
}
