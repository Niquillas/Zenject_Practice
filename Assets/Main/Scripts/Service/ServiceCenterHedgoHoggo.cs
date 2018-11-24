using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ServiceCenterHedgoHoggo
{
    [Inject] private ServiceLogger _logger;

    private CollectionHedgoHoggo _hedgoHoggoCollection;

    public ServiceCenterHedgoHoggo (CollectionHedgoHoggo inputHedgoHoggoCollection)
    {
        _hedgoHoggoCollection = inputHedgoHoggoCollection;
    }

    public ObjectHedgoHoggo CreateHedgoHoggo (Vector3 inputStartPosition)
    {
        return _hedgoHoggoCollection.CreateHedgoHoggo(inputStartPosition);
    }
}
