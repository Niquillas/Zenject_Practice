using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLogger
{
    private readonly bool _debugLogsEnabled;

    public ServiceLogger (bool inputDebugLogsEnabled)
    {
        _debugLogsEnabled = inputDebugLogsEnabled;
    }

    public void Log (string inputString)
    {
        if (_debugLogsEnabled)
        {
            Debug.Log(inputString);
        }
    }

    public void LogError (string inputString)
    {
        if (_debugLogsEnabled)
        {
            Debug.LogError(inputString);
        }
    }
}
