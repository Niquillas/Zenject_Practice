using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectHealthStateNormal : ObjectHealthState
{
    [Inject]
    private ObjectHealthStateInvulnerable _invulnerableHealthState;

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
