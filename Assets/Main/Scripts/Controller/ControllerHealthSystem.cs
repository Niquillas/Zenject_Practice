using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ControllerHealthSystem : ITickable {

	public float CurrentHealth { get; private set; }

    public ObjectHealthState CurrentState { get; private set; }

    [Inject]
    public void Initialize (ObjectHealthStateNormal inputStartingState)
    {
        // test
        CurrentHealth -= Random.Range(0, 500);
        Debug.Log("Current health : " + CurrentHealth);

        TransitionCurrentState(inputStartingState);
    }

    public void Tick ()
    {
        CurrentState.Tick();
    }

    public void TransitionCurrentState (ObjectHealthState inputNextState)
    {
        if (CurrentState == null || CurrentState.ValidateNextState(inputNextState)) {
            if (CurrentState != null)
                CurrentState.Cleanup();

            CurrentState = inputNextState;
            inputNextState.Setup();
        }
    }
}
