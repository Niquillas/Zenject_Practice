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

    public ObjectHedgoHoggo CreateHedgoHoggo (string inputCatchPhrase)
    {
        return _hedgoHoggoCollection.CreateHedgoHoggo(inputCatchPhrase);
    }

    public void DisposeAllHedgoHoggos ()
    {
        while (_hedgoHoggoCollection.AllHedgoHoggos.Count > 0)
        {
            _hedgoHoggoCollection.DisposeHedgoHoggo(_hedgoHoggoCollection.AllHedgoHoggos[0]);
        }
    }
}
