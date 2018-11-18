using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ModelActivityStateScanning : ModelActivityState
{
    [Inject] private ModelActivityStateDetecting _detectingState;

    public override void Cleanup ()
    {
        _serviceFacade.Logger.Log("ScanningActivityState Cleanup()");
    }

    public override void Setup ()
    {
        _serviceFacade.Logger.Log("ScanningActivityState Setup()");
    }

    public override void Tick ()
    {
        //_serviceFacade.Logger.Log("ScanningActivityState Tick()");
    }

    public override void ConstructTransitions ()
    {
        AddTransitionableState(_detectingState);
    }
}
