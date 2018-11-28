using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceCenterSelected
{
    private CollectionSelected _selectedCollection;
    private ObjectPointer.Factory _pointerObjectFactory;
    private ViewPointer.Factory _pointerViewFactory;

    public ServiceCenterSelected (CollectionSelected inputSelectedCollection, ObjectPointer.Factory inputPointerObjectFactory, ViewPointer.Factory inputPointerViewFactory)
    {
        _selectedCollection = inputSelectedCollection;
        _pointerObjectFactory = inputPointerObjectFactory;
        _pointerViewFactory = inputPointerViewFactory;
    }

    public bool CheckIfHedgoHoggoSelected(ViewHedgoHoggo inputHedgoHoggoView)
    {
        return _selectedCollection.CheckIfRegistered(inputHedgoHoggoView.Id);
    }

    public ObjectPointer SelectHedgoHoggo(ViewHedgoHoggo inputHedgoHoggoView)
    {
        ObjectPointer pointerObject = _pointerObjectFactory.Create();
        ViewPointer pointerView = _pointerViewFactory.Create(pointerObject);
        _selectedCollection.RegisterHedgoHoggoPointer(inputHedgoHoggoView.Id, pointerObject, pointerView);
        return pointerObject;
    }

    public void SynchronizeHedgoHoggoPointers()
    {
        List<ObjectPointer> hedgoHoggoPointerObjects = _selectedCollection.AllHedgoHoggoPointerObjects;
        for (int i = 0; i < hedgoHoggoPointerObjects.Count; i++)
        {
            hedgoHoggoPointerObjects[i].SignalAnimationRestart();
        }
    }

    public void DeSelectHedgoHoggo(ViewHedgoHoggo inputHedgoHoggoView)
    {
        DeselectHedgoHoggo(inputHedgoHoggoView.Id);
    }

    private void DeselectHedgoHoggo(int inputHedgoHoggoId)
    {
        ViewPointer pointerView = _selectedCollection.FetchHedgoHoggoPointerView(inputHedgoHoggoId);
        if (pointerView != null)
        {
            pointerView.Dispose();
        }
        _selectedCollection.UnregisterHedgoHoggoPointer(inputHedgoHoggoId);
    }

    public void DeSelectAllHedgoHoggos ()
    {
        List<int> hedgoHoggoIds = _selectedCollection.AllSelectedHedgoHoggos;
        for (int i = 0; i < hedgoHoggoIds.Count; i++)
        {
            DeselectHedgoHoggo(hedgoHoggoIds[i]);
        }
    }
}
