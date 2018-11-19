using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectActivityStateLimbo : ObjectActivityState
{
    public override void Cleanup()
    {
        if (_serviceLogger != null)
        {
            _serviceLogger.Log("LimboActivityState Cleanup()");
        }
    }

    public override void Setup()
    {
        if (_serviceLogger != null)
        {
            _serviceLogger.Log("LimboActivityState Setup()");
        }
    }

    public override void Tick()
    {
        /*
        if (_serviceLogger != null)
        {
            _serviceLogger.Log("LimboActivityState Tick()");
        }
        */
    }
}
