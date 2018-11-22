using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CollectionActivityState
{
    public enum ActivityStateId
    {
        Creating,
        Coloring,
        Deleting
    }

    public List<ObjectActivityState> AllActivityStates { get; private set; }

    private Dictionary<ActivityStateId, ObjectActivityState> _activityStateMap;

    public CollectionActivityState 
    (
        ObjectActivityStateColoring inputColoringState,
        ObjectActivityStateCreating inputCreatingState,
        ObjectActivityStateDeleting inputDeletingState
    )
    {
        _activityStateMap = new Dictionary<ActivityStateId, ObjectActivityState>
        {
            { ActivityStateId.Creating, inputCreatingState },
            { ActivityStateId.Coloring, inputColoringState },
            { ActivityStateId.Deleting, inputDeletingState }
        };

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
