using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class ModelActivityState
{
    private HashSet<ModelActivityState> _transitionableStates;

    [Inject] protected ServiceFacade _serviceFacade;

    public ModelActivityState()
    {
        _transitionableStates = new HashSet<ModelActivityState>();
    }

    protected void AddTransitionableState (ModelActivityState inputTransitionableState)
    {
        if (!_transitionableStates.Contains(inputTransitionableState))
            _transitionableStates.Add(inputTransitionableState);
    }

    protected bool IsStateTransitionable (ModelActivityState inputActivityState)
    {
        return _transitionableStates.Contains(inputActivityState);
    }

    public virtual bool ValidateNextState (ModelActivityState inputNextState)
    {
        return IsStateTransitionable(inputNextState);
    }

    public abstract void Setup ();
    public abstract void Tick ();
    public abstract void Cleanup ();
    public abstract void ConstructTransitions ();
}
