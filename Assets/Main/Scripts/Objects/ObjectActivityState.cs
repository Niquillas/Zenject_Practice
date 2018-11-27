using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class ObjectActivityState
{
    private HashSet<ObjectActivityState> _transitionableStates;
    
    public ObjectActivityState()
    {
        _transitionableStates = new HashSet<ObjectActivityState>();
    }

    public void AddTransitionableState (ObjectActivityState inputTransitionableState)
    {
        if (!_transitionableStates.Contains(inputTransitionableState))
            _transitionableStates.Add(inputTransitionableState);
    }

    public void RemoveTransitionableState(ObjectActivityState inputTransitionableState)
    {
        if (!_transitionableStates.Contains(inputTransitionableState))
            _transitionableStates.Remove(inputTransitionableState);
    }

    protected bool IsStateTransitionable (ObjectActivityState inputActivityState)
    {
        return inputActivityState != this && (_transitionableStates.Count == 0 || _transitionableStates.Contains(inputActivityState));
    }

    public virtual bool ValidateNextState (ObjectActivityState inputNextState)
    {
        return IsStateTransitionable(inputNextState);
    }

    public abstract void Setup ();
    public abstract void Tick ();
    public abstract void Cleanup ();
}
