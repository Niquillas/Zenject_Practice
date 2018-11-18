using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class ModelHealthState {

    private HashSet<ModelHealthState> _transitionableStates;

    public ModelHealthState ()
    {
        _transitionableStates = new HashSet<ModelHealthState>();
    }

    [Inject]
    private void Initialize ()
    {
        ConstructTransitions();
        Cleanup();
    }

    protected void AddTransitionableState (ModelHealthState inputTransitionableState)
    {
        if (!_transitionableStates.Contains(inputTransitionableState))
            _transitionableStates.Add(inputTransitionableState);
    }

    protected bool IsStateTransitionable (ModelHealthState inputActivityState)
    {
        return _transitionableStates.Contains(inputActivityState);
    }

    public virtual bool ValidateNextState (ModelHealthState inputNextState)
    {
        return IsStateTransitionable(inputNextState);
    }

    public abstract void Setup ();
    public abstract void Tick ();
    public abstract void Cleanup ();

    protected abstract void ConstructTransitions ();
}
