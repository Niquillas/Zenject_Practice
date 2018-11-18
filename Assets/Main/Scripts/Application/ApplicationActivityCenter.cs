using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ApplicationActivityCenter : IInitializable, ITickable
{
    public ModelActivityState CurrentState { get; private set; }

    public ModelActivityStateLimbo LimboState { get; private set; }
    public ModelActivityStateScanning ScanningState { get; private set; }
    public ModelActivityStateDetecting DetectingState { get; private set; }

    private List<ModelActivityState> _activityStates;

    public ApplicationActivityCenter (ModelActivityStateLimbo inputLimboState, 
                                      ModelActivityStateScanning inputScanningState, 
                                      ModelActivityStateDetecting inputDetectingState)
    {
        _activityStates = new List<ModelActivityState>()
        {
            inputLimboState,
            inputScanningState,
            inputDetectingState
        };

        LimboState = inputLimboState;
        ScanningState = inputScanningState;
        DetectingState = inputDetectingState;
    }

    public void Initialize ()
    {
        for (int i = 0; i < _activityStates.Count; i++)
        {
            _activityStates[i].ConstructTransitions();
            _activityStates[i].Cleanup();
        }

        TransitionCurrentState(ScanningState);
    }

    public void Tick ()
    {
        if (CurrentState != null)
            CurrentState.Tick();
    }

    public void TransitionCurrentState (ModelActivityState inputNextState)
    {
        if (CurrentState == null || CurrentState.ValidateNextState(inputNextState)) 
        {
            if (CurrentState != null) 
                CurrentState.Cleanup();

            CurrentState = inputNextState;
            inputNextState.Setup();
        }
    }
}
