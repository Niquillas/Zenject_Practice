using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CollectionActivityState
{
    public enum ActivityStateId
    {
        Scanning,
        Limbo,
        Detecting
    }

    public List<ObjectActivityState> AllActivityStates { get; private set; }

    private Dictionary<ActivityStateId, ObjectActivityState> _activityStateMap;

    public CollectionActivityState 
    (
        ObjectActivityStateLimbo inputLimboState,
        ObjectActivityStateScanning inputScanningState,
        ObjectActivityStateDetecting inputDetectingState
    )
    {
        _activityStateMap = new Dictionary<ActivityStateId, ObjectActivityState>
        {
            { ActivityStateId.Scanning, inputScanningState },
            { ActivityStateId.Limbo, inputLimboState },
            { ActivityStateId.Detecting, inputDetectingState }
        };

        inputScanningState.AddTransitionableState(inputLimboState);
        inputLimboState.AddTransitionableState(inputDetectingState);
        inputDetectingState.AddTransitionableState(inputScanningState);

        AllActivityStates = _activityStateMap.Values.ToList<ObjectActivityState>();
    }

    public ObjectActivityState GetActivityState(ActivityStateId inputActivityStateId)
    {
        if (_activityStateMap.ContainsKey(inputActivityStateId))
        {
            return _activityStateMap[inputActivityStateId];
        }

        return null;
    }
}
