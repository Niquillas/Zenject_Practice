using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CollectionSelected
{
    public List<int> AllSelectedHedgoHoggos
    {
        get
        {
            return _hedgoHoggoPointerObjectMap.Keys.ToList<int>();
        }
    }

    public int SelectedHedgoHoggosCount
    { 
        get
        {
            return _hedgoHoggoPointerViewMap.Keys.Count;
        }
    }

    public List<ObjectPointer> AllHedgoHoggoPointerObjects
    { 
        get
        {
            return _hedgoHoggoPointerObjectMap.Values.ToList<ObjectPointer>();
        }
    }

    private ServiceLogger _logger;
    private Dictionary<int, ObjectPointer> _hedgoHoggoPointerObjectMap;
    private Dictionary<int, ViewPointer> _hedgoHoggoPointerViewMap;

    public CollectionSelected(ServiceLogger inputServiceLogger)
    {
        _logger = inputServiceLogger;
        _hedgoHoggoPointerObjectMap = new Dictionary<int, ObjectPointer>();
        _hedgoHoggoPointerViewMap = new Dictionary<int, ViewPointer>();
    }

    public bool CheckIfRegistered(int inputId)
    {
        return _hedgoHoggoPointerObjectMap.ContainsKey(inputId);
    }

    public void RegisterHedgoHoggoPointer(int inputId, ObjectPointer inputPointerObject, ViewPointer inputPointerView)
    {
        if (!_hedgoHoggoPointerObjectMap.ContainsKey(inputId))
        {
            _hedgoHoggoPointerObjectMap.Add(inputId, inputPointerObject);
            _hedgoHoggoPointerViewMap.Add(inputId, inputPointerView);
            _logger.Log(string.Format("Registered ID: {0} as selected.", inputId));
        }
        else
        {
            _logger.LogError(string.Format("Cannot Register ID: {0} as selected since it already exists in dictionary!", inputId));
        }
    }

    public void UnregisterHedgoHoggoPointer(int inputId)
    {
        if (_hedgoHoggoPointerObjectMap.ContainsKey(inputId))
        {
            _hedgoHoggoPointerObjectMap.Remove(inputId);
            _hedgoHoggoPointerViewMap.Remove(inputId);
            _logger.Log(string.Format("UnRegistered ID: {0} as deselected.", inputId));
        }
        else
        {
            _logger.LogError(string.Format("Cannot UnRegister ID: {0} as deselected since it doesn't exist in dictionary!", inputId));
        }
    }

    public ViewPointer FetchHedgoHoggoPointerView(int inputId)
    {
        if (_hedgoHoggoPointerViewMap.ContainsKey(inputId))
        {
            return _hedgoHoggoPointerViewMap[inputId];
        }
        else
        {
            _logger.LogError(string.Format("Cannot fetch ID: {0} since it doesn't exist in dictionary!", inputId));
        }
        return null;
    }
}
