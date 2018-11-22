using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ApplicationRoot : IInitializable
{
    private ServiceCenterActivtyState _activityCenter;

    public ApplicationRoot(ServiceCenterActivtyState inputActivityState)
    {
        _activityCenter = inputActivityState;
    }

    public void Initialize()
    {
        _activityCenter.Init(CollectionActivityState.ActivityStateId.Creating);
    }
}
