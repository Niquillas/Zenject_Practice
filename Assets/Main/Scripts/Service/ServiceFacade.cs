using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceFacade
{
    public ServiceLogger Logger { get; private set; }

    public ServiceFacade(ServiceLogger inputLogger)
    {
        Logger = inputLogger;
    }
}
