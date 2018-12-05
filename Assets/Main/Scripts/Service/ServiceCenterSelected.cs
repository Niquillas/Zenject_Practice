using System.Collections.Generic;

public class ServiceCenterSelected
{
    public delegate void ViewSelectedDelegate(int inputCount);
    public event ViewSelectedDelegate ViewSelectedEvent;

    private ServiceCenterHedgoHoggo _hedgoHoggoCenter;
    private CollectionSelected _selectedCollection;
    private ObjectPointer.Factory _pointerObjectFactory;
    private ViewPointer.Factory _pointerViewFactory;

    public ServiceCenterSelected (ServiceCenterHedgoHoggo inputHedgoHoggoCenter, CollectionSelected inputSelectedCollection, ObjectPointer.Factory inputPointerObjectFactory, ViewPointer.Factory inputPointerViewFactory)
    {
        _hedgoHoggoCenter = inputHedgoHoggoCenter;
        _selectedCollection = inputSelectedCollection;
        _pointerObjectFactory = inputPointerObjectFactory;
        _pointerViewFactory = inputPointerViewFactory;
    }

    public bool CheckViewSelected(ViewHedgoHoggo inputHedgHoggoView)
    {
        return _selectedCollection.CheckIsRegistered(inputHedgHoggoView);
    }

    public ObjectPointer SelectView(ViewHedgoHoggo inputHedgHoggoView)
    {
        ObjectPointer pointerObject = _pointerObjectFactory.Create();
        ViewPointer pointerView = _pointerViewFactory.Create(pointerObject);

        _selectedCollection.Register(inputHedgHoggoView, pointerObject, pointerView);

        if (ViewSelectedEvent != null)
        {
            ViewSelectedEvent(_selectedCollection.Count);
        }
        return pointerObject;
    }

    public void SynchronizePointers()
    {
        List<ObjectPointer> pointerObjects = _selectedCollection.PointerObjects;
        for (int i = 0; i < pointerObjects.Count; i++)
        {
            pointerObjects[i].SignalAnimationRestart();
        }
    }

    public void ColorAllSelected()
    {
        List<ViewHedgoHoggo> hedgoHoggoViews = _selectedCollection.Registered;
        for (int i = 0; i < hedgoHoggoViews.Count; i++)
        {
            _hedgoHoggoCenter.ColorHedgoHoggoToRandom(hedgoHoggoViews[i]);
        }
    }

    public void DeleteAllSelected()
    {
        List<ViewHedgoHoggo> hedgoHoggoViews = _selectedCollection.Registered;
        for (int i = 0; i < hedgoHoggoViews.Count; i++)
        {
            DeselectView(hedgoHoggoViews[i]);
            _hedgoHoggoCenter.DestroyHedgoHoggo(hedgoHoggoViews[i]);
        }
    }

    public void DeselectView(ViewHedgoHoggo inputHedgHoggoView)
    {
        ViewPointer pointerView = _selectedCollection.FetchPointerView(inputHedgHoggoView);
        if (pointerView != null)
        {
            pointerView.Dispose();
        }
        _selectedCollection.Unregister(inputHedgHoggoView);
        if (ViewSelectedEvent != null)
        {
            ViewSelectedEvent(_selectedCollection.Count);
        }
    }

    public void DeselectAllViews ()
    {
        List<ViewHedgoHoggo> selected = _selectedCollection.Registered;
        for (int i = 0; i < selected.Count; i++)
        {
            DeselectView(selected[i]);
        }
    }
}
