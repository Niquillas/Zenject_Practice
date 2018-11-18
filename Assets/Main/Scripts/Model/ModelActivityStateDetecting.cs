using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ModelActivityStateDetecting : ModelActivityState
{
    [Inject] private ModelActivityStateLimbo _limboState;

    public override void Cleanup ()
    {
        _serviceFacade.Logger.Log("DetectingActivityState Cleanup()");
    }

    public override void Setup ()
    {
        _serviceFacade.Logger.Log("DetectingActivityState Setup()");
    }

    public override void Tick ()
    {
        //_serviceFacade.Logger.Log("DetectingActivityState Tick()");
    }

    public override void ConstructTransitions ()
    {
        AddTransitionableState(_limboState);
    }
}
