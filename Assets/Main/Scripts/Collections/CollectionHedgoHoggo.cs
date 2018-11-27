using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionHedgoHoggo 
{
    private Dictionary<int, ObjectHedgoHoggo> _hedgoHoggoObjectsMap;
    private Dictionary<int, ViewHedgoHoggo> _hedgoHoggoViewsMap;

    private readonly ObjectHedgoHoggo.Factory _hedgoHoggoObjectFactory;
    private readonly ViewHedgoHoggo.Factory _hedgoHoggoViewFactory;

    private Stack<int> _reusableIds;
    private int _lastCreatedId;

    public CollectionHedgoHoggo (ObjectHedgoHoggo.Factory inputHedgoHoggoObjectFactory, ViewHedgoHoggo.Factory inputHedgoHoggoViewFactory)
    {
        _hedgoHoggoObjectsMap = new Dictionary<int, ObjectHedgoHoggo>();
        _hedgoHoggoViewsMap = new Dictionary<int, ViewHedgoHoggo>();
        _hedgoHoggoObjectFactory = inputHedgoHoggoObjectFactory;
        _hedgoHoggoViewFactory = inputHedgoHoggoViewFactory;
        _lastCreatedId = -1;
        _reusableIds = new Stack<int>();
    }

    public ObjectHedgoHoggo CreateHedgoHoggo()
    {
        int id = DetermineNextAvailableId();
        ObjectHedgoHoggo hedgoHoggoObject = _hedgoHoggoObjectFactory.Create(id);
        _hedgoHoggoObjectsMap.Add(id, hedgoHoggoObject);
        ViewHedgoHoggo hedgoHoggoView = _hedgoHoggoViewFactory.Create(hedgoHoggoObject);
        _hedgoHoggoViewsMap.Add(id, hedgoHoggoView);
        return hedgoHoggoObject;
    }

    public void DestroyHedgoHoggo(int inputId)
    {
        if (_hedgoHoggoObjectsMap.Remove(inputId))
        {
            _hedgoHoggoViewsMap[inputId].Dispose();
            _hedgoHoggoViewsMap.Remove(inputId);
            _reusableIds.Push(inputId);
        }
    }

    public ObjectHedgoHoggo FetchHedgoHoggo(int inputId)
    {
        if (_hedgoHoggoObjectsMap.ContainsKey(inputId))
        {
            return _hedgoHoggoObjectsMap[inputId];
        }
        return null;
    }

    private int DetermineNextAvailableId()
    {
        if (_reusableIds.Count == 0)
        {
            return ++_lastCreatedId;
        }
        else
        {
            return _reusableIds.Pop();
        }
    }
}
