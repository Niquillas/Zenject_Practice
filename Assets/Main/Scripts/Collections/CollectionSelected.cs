using System.Collections.Generic;
using System.Linq;

public class CollectionSelected
{
    public struct SelectableComponent
    {
        public ObjectPointer PointerObject { get; set; }
        public ViewPointer PointerView { get; set; }
    }

    public int Count
    { 
        get
        {
            return _selectedMap.Count;
        }
    }

    public List<ViewHedgoHoggo> Registered
    {
        get
        {
            return _selectedMap.Keys.ToList();
        }
    }

    public List<ObjectPointer> PointerObjects
    {
        get
        {
            List<ObjectPointer> pointerObjects = new List<ObjectPointer>();
            foreach(SelectableComponent selectableComponent in _selectedMap.Values)
            {
                pointerObjects.Add(selectableComponent.PointerObject);
            }
            return pointerObjects;
        }
    }

    public List<ViewPointer> PointerViews
    {
        get
        {
            List<ViewPointer> pointerViews = new List<ViewPointer>();
            foreach (SelectableComponent selectableComponent in _selectedMap.Values)
            {
                pointerViews.Add(selectableComponent.PointerView);
            }
            return pointerViews;
        }
    }

    private ServiceLogger _logger;
    private Dictionary<ViewHedgoHoggo, SelectableComponent> _selectedMap;

    public CollectionSelected(ServiceLogger inputServiceLogger)
    {
        _logger = inputServiceLogger;
        _selectedMap = new Dictionary<ViewHedgoHoggo, SelectableComponent>();
    }

    public bool CheckIsRegistered(ViewHedgoHoggo inputHedgoHoggoView)
    {
        return _selectedMap.ContainsKey(inputHedgoHoggoView);
    }

    public void Register(ViewHedgoHoggo inputHedgoHoggoView, ObjectPointer inputPointerObject, ViewPointer inputPointerView)
    {
        if (!_selectedMap.ContainsKey(inputHedgoHoggoView))
        {
            SelectableComponent selectableComponent = new SelectableComponent() 
            {
                PointerView = inputPointerView,
                PointerObject = inputPointerObject
            };
            _selectedMap.Add(inputHedgoHoggoView, selectableComponent);
            _logger.Log("Registered seletable view");
        }
        else
        {
            _logger.LogError("Could not register selectable view since it already exists in dictionary!");
        }
    }

    public void Unregister(ViewHedgoHoggo inputHedgHoggoView)
    {
        if (_selectedMap.Remove(inputHedgHoggoView))
        {
            _logger.Log("UnRegistered selectable");
        }
        else
        {
            _logger.LogError("Could not unregister seletable view since it doesn't exist in dictionary!");
        }
    }

    public ViewPointer FetchPointerView(ViewHedgoHoggo inputHedgHoggoView)
    {
        if (_selectedMap.ContainsKey(inputHedgHoggoView))
        {
            return _selectedMap[inputHedgHoggoView].PointerView;
        }
        else
        {
            _logger.LogError("Could not fetch pointer view since it doesn't exist in dictionary!");
        }

        return null;
    }
}
