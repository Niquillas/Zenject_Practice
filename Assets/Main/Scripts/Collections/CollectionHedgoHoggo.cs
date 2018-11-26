using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionHedgoHoggo 
{
    public List<ObjectHedgoHoggo> AllHedgoHoggosObjects { get; private set; }

    private Dictionary<ObjectHedgoHoggo, ViewHedgoHoggo> _hedgoHoggoViewsMap;

    private readonly ObjectHedgoHoggo.Factory _hedgoHoggoObjectFactory;
    private readonly ViewHedgoHoggo.Factory _hedgoHoggoViewFactory;

    public CollectionHedgoHoggo (ObjectHedgoHoggo.Factory inputHedgoHoggoObjectFactory, ViewHedgoHoggo.Factory inputHedgoHoggoViewFactory)
    {
        AllHedgoHoggosObjects = new List<ObjectHedgoHoggo>();
        _hedgoHoggoViewsMap = new Dictionary<ObjectHedgoHoggo, ViewHedgoHoggo>();
        _hedgoHoggoObjectFactory = inputHedgoHoggoObjectFactory;
        _hedgoHoggoViewFactory = inputHedgoHoggoViewFactory;
    }

    public ObjectHedgoHoggo CreateHedgoHoggo()
    {
        ObjectHedgoHoggo hedgoHoggoObject = _hedgoHoggoObjectFactory.Create();
        AllHedgoHoggosObjects.Add(hedgoHoggoObject);
        ViewHedgoHoggo hedgoHoggoView = _hedgoHoggoViewFactory.Create(hedgoHoggoObject);
        _hedgoHoggoViewsMap.Add(hedgoHoggoObject, hedgoHoggoView);
        return hedgoHoggoObject;
    }

    public void DisposeHedgoHoggo(ObjectHedgoHoggo inputHedgoHoggoObject)
    {
        int hedgoHoggoObjectIndex = AllHedgoHoggosObjects.IndexOf(inputHedgoHoggoObject);

        if (hedgoHoggoObjectIndex >= 0)
        {
            ObjectHedgoHoggo hedgoHoggoObject = AllHedgoHoggosObjects[hedgoHoggoObjectIndex];

            if (_hedgoHoggoViewsMap.ContainsKey(hedgoHoggoObject))
            {
                _hedgoHoggoViewsMap[hedgoHoggoObject].Dispose();
                _hedgoHoggoViewsMap.Remove(hedgoHoggoObject);
            }
        }
    }
}
