using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionHedgoHoggo 
{
    public List<ObjectHedgoHoggo> AllHedgoHoggos { get; private set; }
    
    private readonly ObjectHedgoHoggo.Factory _hedgoHoggoFactory;
    
    public CollectionHedgoHoggo (ObjectHedgoHoggo.Factory inputHedgoHoggoFactory)
    {
        AllHedgoHoggos = new List<ObjectHedgoHoggo>();
        _hedgoHoggoFactory = inputHedgoHoggoFactory;
    }

    public ObjectHedgoHoggo CreateHedgoHoggo(string inputCatchPhrase)
    {
        ObjectHedgoHoggo hedgoHoggoInstance = _hedgoHoggoFactory.GetInstance(inputCatchPhrase);
        AllHedgoHoggos.Add(hedgoHoggoInstance);
        return hedgoHoggoInstance;
    }

    public void DisposeHedgoHoggo(ObjectHedgoHoggo inputHedgoHoggo)
    {
        if (AllHedgoHoggos.Remove(inputHedgoHoggo))
        {
            inputHedgoHoggo.Dispose();
        }
    }
}
