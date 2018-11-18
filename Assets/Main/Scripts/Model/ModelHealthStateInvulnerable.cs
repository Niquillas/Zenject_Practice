using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ModelHealthStateInvulnerable : ModelHealthState
{
    [Inject]
    private ModelHealthStateNormal _normalHealthState;

    public override void Setup ()
    {
        Debug.Log("InvulnerableHealthState Setup()");
    }

    public override void Tick ()
    {
        Debug.Log("InvulnerableHealthState Tick()");
    }

    public override void Cleanup ()
    {
        Debug.Log("InvulnerableHealthState Cleanup()");
    }

    protected override void ConstructTransitions ()
    {
        AddTransitionableState(_normalHealthState);
    }
}
