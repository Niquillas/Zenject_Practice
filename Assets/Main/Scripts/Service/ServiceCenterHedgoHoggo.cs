using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ServiceCenterHedgoHoggo
{
    private CollectionHedgoHoggo _hedgoHoggoCollection;

    public ServiceCenterHedgoHoggo (CollectionHedgoHoggo inputHedgoHoggoCollection)
    {
        _hedgoHoggoCollection = inputHedgoHoggoCollection;
    }

    public ObjectHedgoHoggo CreateHedgoHoggo ()
    {
        return _hedgoHoggoCollection.CreateHedgoHoggo();
    }

    public ObjectHedgoHoggo FetchHedgoHoggo (ViewHedgoHoggo inputHedgoHoggoView)
    {
        return _hedgoHoggoCollection.FetchHedgoHoggo(inputHedgoHoggoView.Id);
    }

    public void DestroyHedgoHoggo (ViewHedgoHoggo inputHedgoHoggoView)
    {
        _hedgoHoggoCollection.DestroyHedgoHoggo(inputHedgoHoggoView.Id);
    }
}
