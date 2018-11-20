using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ApplicationRoot : IInitializable
{
    [Inject] private ServiceCenterActivtyState _activityCenter;

    public void Initialize()
    {
        _activityCenter.Init(CollectionActivityState.ActivityStateId.Scanning);
    }
}
