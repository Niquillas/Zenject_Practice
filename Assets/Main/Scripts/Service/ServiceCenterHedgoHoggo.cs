using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ServiceCenterHedgoHoggo
{
    private CollectionHedgoHoggo _hedgoHoggoCollection;
    private readonly ObjectHedgoHoggo.Factory _hedgoHoggoObjectFactory;
    private readonly ViewHedgoHoggo.Factory _hedgoHoggoViewFactory;

    public ServiceCenterHedgoHoggo (CollectionHedgoHoggo inputHedgoHoggoCollection, ObjectHedgoHoggo.Factory inputHedgoHoggoObjectFactory, ViewHedgoHoggo.Factory inputHedgoHoggoViewFactory)
    {
        _hedgoHoggoCollection = inputHedgoHoggoCollection;
        _hedgoHoggoObjectFactory = inputHedgoHoggoObjectFactory;
        _hedgoHoggoViewFactory = inputHedgoHoggoViewFactory;
    }

    public ObjectHedgoHoggo CreateHedgoHoggo ()
    {
        int id = _hedgoHoggoCollection.DetermineNextAvailableId();
        ObjectHedgoHoggo hedgoHoggoObject = _hedgoHoggoObjectFactory.Create(id);
        ViewHedgoHoggo hedgoHoggoView = _hedgoHoggoViewFactory.Create(hedgoHoggoObject);
        _hedgoHoggoCollection.RegisterHedgoHoggo(hedgoHoggoObject, hedgoHoggoView);
        return hedgoHoggoObject;
    }

    public ObjectHedgoHoggo FetchHedgoHoggo (ViewHedgoHoggo inputHedgoHoggoView)
    {
        return _hedgoHoggoCollection.FetchHedgoHoggoObject(inputHedgoHoggoView.Id);
    }

    public void DestroyHedgoHoggo (ViewHedgoHoggo inputHedgoHoggoView)
    {
        _hedgoHoggoCollection.UnRegisterHedgoHoggo(inputHedgoHoggoView.Id);
        inputHedgoHoggoView.Dispose();
    }
}
