using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectActivityStateDetecting : ObjectActivityState
{
    public override void Cleanup()
    {
        if (_serviceLogger != null)
        {
            _serviceLogger.Log("DetectingActivityState Cleanup()");
        }
    }

    public override void Setup()
    {
        if (_serviceLogger != null)
        {
            _serviceLogger.Log("DetectingActivityState Setup()");
        }
    }

    public override void Tick()
    {
        /*
        if (_serviceLogger != null)
        {
            _serviceLogger.Log("DetectingActivityState Tick()");
        }
        */
    }
}
