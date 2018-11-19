using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectActivityStateScanning : ObjectActivityState
{
    public override void Cleanup()
    {
        if (_serviceLogger != null)
        {
            _serviceLogger.Log("ScanningActivityState Cleanup()");
        }
    }

    public override void Setup()
    {
        if (_serviceLogger != null)
        {
            _serviceLogger.Log("ScanningActivityState Setup()");
        }
    }

    public override void Tick()
    {
        /*
        if (_serviceLogger != null)
        {
            _serviceLogger.Log("ScanningActivityState Tick()");
        }
        */
    }
}
