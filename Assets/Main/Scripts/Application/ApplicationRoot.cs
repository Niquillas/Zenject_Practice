using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ApplicationRoot : IInitializable
{
    private ServiceCenterActivtyState _activityStateCenter;

    public ApplicationRoot(ServiceCenterActivtyState inputActivityStateCenter)
    {
        _activityStateCenter = inputActivityStateCenter;
    }

    public void Initialize()
    {
        _activityStateCenter.Init(CollectionActivityState.ActivityStateId.Creating);
    }
}
