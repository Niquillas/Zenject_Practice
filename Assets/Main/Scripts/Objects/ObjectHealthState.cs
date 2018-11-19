using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class ObjectHealthState {

    private HashSet<ObjectHealthState> _transitionableStates;

    public ObjectHealthState ()
    {
        _transitionableStates = new HashSet<ObjectHealthState>();
    }

    [Inject]
    private void Initialize ()
    {
        ConstructTransitions();
        Cleanup();
    }

    protected void AddTransitionableState (ObjectHealthState inputTransitionableState)
    {
        if (!_transitionableStates.Contains(inputTransitionableState))
            _transitionableStates.Add(inputTransitionableState);
    }

    protected bool IsStateTransitionable (ObjectHealthState inputActivityState)
    {
        return _transitionableStates.Contains(inputActivityState);
    }

    public virtual bool ValidateNextState (ObjectHealthState inputNextState)
    {
        return IsStateTransitionable(inputNextState);
    }

    public abstract void Setup ();
    public abstract void Tick ();
    public abstract void Cleanup ();

    protected abstract void ConstructTransitions ();
}
