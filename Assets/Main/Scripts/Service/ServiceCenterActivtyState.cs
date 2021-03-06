﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ServiceCenterActivtyState : ITickable
{
    public delegate void CurrentStateChangedDelegate(string inputStateName);
    public event CurrentStateChangedDelegate CurrentStateChangedEvent;

    public ObjectActivityState CurrentState { get; private set; }

    private CollectionActivityState _collectionActivityState;

    public ServiceCenterActivtyState(CollectionActivityState inputActivityStateCollection)
    {
        _collectionActivityState = inputActivityStateCollection;
    }

    public void Init(CollectionActivityState.ActivityStateId inputActivityStateId)
    {
        for (int i = 0; i < _collectionActivityState.AllActivityStates.Count; i++)
        {
            _collectionActivityState.AllActivityStates[i].Cleanup();
        }

        TransitionCurrentState(inputActivityStateId);
    }

    public void Tick()
    {
        if (CurrentState != null)
        {
            CurrentState.Tick();
        }
    }

    public void TransitionCurrentState(CollectionActivityState.ActivityStateId inputActivityStateId)
    {
        ObjectActivityState transitionToState = _collectionActivityState.GetActivityState(inputActivityStateId);
        if (transitionToState != null)
        {
            TransitionCurrentState(transitionToState);
        }
    }

    private void TransitionCurrentState(ObjectActivityState inputNextState)
    {
        if (CurrentState == null || CurrentState.ValidateNextState(inputNextState)) 
        {
            if (CurrentState != null) 
                CurrentState.Cleanup();

            CurrentState = inputNextState;
            inputNextState.Setup();

            if (CurrentStateChangedEvent != null)
            {
                CurrentStateChangedEvent(inputNextState.Name);
            }
        }
    }
}
