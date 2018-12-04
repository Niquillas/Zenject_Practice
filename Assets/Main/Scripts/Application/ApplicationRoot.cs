public class ApplicationRoot : Zenject.IInitializable
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
