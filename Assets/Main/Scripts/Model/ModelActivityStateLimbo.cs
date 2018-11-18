using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ModelActivityStateLimbo : ModelActivityState
{
    [Inject] private ModelActivityStateScanning _scanningState;

    public override void Cleanup ()
    {
        _serviceFacade.Logger.Log("LimboActivityState Cleanup()");
    }

    public override void Setup ()
    {
        _serviceFacade.Logger.Log("LimboActivityState Setup()");
    }

    public override void Tick ()
    {
        //_serviceFacade.Logger.Log("LimboActivityState Tick()");
    }

    public override void ConstructTransitions ()
    {
        AddTransitionableState(_scanningState);
    }
}
