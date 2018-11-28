using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CollectionSelected
{
    public List<int> AllSelected
    {
        get
        {
            return _selectedIds.ToList<int>();
        }
    }

    private ServiceLogger _logger;
    private HashSet<int> _selectedIds;

    public CollectionSelected(ServiceLogger inputServiceLogger)
    {
        _logger = inputServiceLogger;
        _selectedIds = new HashSet<int>();
    }

    public bool CheckIfRegistered(int inputId)
    {
        return _selectedIds.Contains(inputId);
    }

    public void RegisterSelected(int inputId)
    {
        if (!_selectedIds.Contains(inputId))
        {
            _selectedIds.Add(inputId);
            _logger.Log(string.Format("Registered ID: {0} as selected.", inputId));
        }
        else
        {
            _logger.LogError(string.Format("Cannot Register ID: {0} as selected since it already exists in hashset!", inputId));
        }
    }

    public void UnregisterSelected(int inputId)
    {
        if (_selectedIds.Contains(inputId))
        {
            _logger.Log(string.Format("UnRegistered ID: {0} as deselected.", inputId));
            _selectedIds.Remove(inputId);
        }
        else
        {
            _logger.LogError(string.Format("Cannot UnRegister ID: {0} as deselected since it doesn't exist in hashset!", inputId));
        }
    }
}
