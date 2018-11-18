using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ModelHealthStateNormal : ModelHealthState
{
    [Inject]
    private ModelHealthStateInvulnerable _invulnerableHealthState;

    public override void Setup ()
    {
        Debug.Log("NormalHealthState Setup()");
    }

    public override void Tick ()
    {
        Debug.Log("NormalHealthState Setup()");
    }

    public override void Cleanup ()
    {
        Debug.Log("NormalHealthState Setup()");
    }

    protected override void ConstructTransitions ()
    {
        AddTransitionableState(_invulnerableHealthState);
    }
}
