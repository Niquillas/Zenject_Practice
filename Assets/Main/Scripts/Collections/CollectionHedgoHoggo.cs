using System.Collections.Generic;

public class CollectionHedgoHoggo 
{
    private ServiceLogger _logger;
    private Dictionary<int, ObjectHedgoHoggo> _hedgoHoggoObjectsMap;
    private Dictionary<int, ViewHedgoHoggo> _hedgoHoggoViewsMap;
    private readonly Stack<int> _reusableIds;
    private int _lastCreatedId;

    public CollectionHedgoHoggo (ServiceLogger inputLogger)
    {
        _logger = inputLogger;
        _hedgoHoggoObjectsMap = new Dictionary<int, ObjectHedgoHoggo>();
        _hedgoHoggoViewsMap = new Dictionary<int, ViewHedgoHoggo>();
        _lastCreatedId = -1;
        _reusableIds = new Stack<int>();
    }

    public void RegisterHedgoHoggo(ObjectHedgoHoggo inputHedgoHoggoObject, ViewHedgoHoggo inputHedgoHoggoView)
    {
        if (!_hedgoHoggoObjectsMap.ContainsKey(inputHedgoHoggoObject.Id))
        {
            _hedgoHoggoObjectsMap.Add(inputHedgoHoggoObject.Id, inputHedgoHoggoObject);
            _logger.Log(string.Format("Registered Hedgo Hoggo Object with ID : {0}.!", inputHedgoHoggoObject.Id));
        }
        else
        {
            _logger.LogError(string.Format("Cannot register Hedgo Hoggo Object with ID : {0} since it already exists in object dictionary!", inputHedgoHoggoObject.Id));
        }

        if (!_hedgoHoggoViewsMap.ContainsKey(inputHedgoHoggoView.Id))
        {
            _hedgoHoggoViewsMap.Add(inputHedgoHoggoView.Id, inputHedgoHoggoView);
            _logger.Log(string.Format("Registered Hedgo Hoggo View with ID : {0}.", inputHedgoHoggoView.Id));
        }
        else
        {
            _logger.LogError(string.Format("Cannot register Hedgo Hoggo View with ID : {0} since it already exists in view dictionary!", inputHedgoHoggoView.Id));
        }
    }

    public void UnRegisterHedgoHoggo(int inputId)
    {
        if (_hedgoHoggoObjectsMap.Remove(inputId))
        {
            _hedgoHoggoViewsMap.Remove(inputId);
            _reusableIds.Push(inputId);
            _logger.Log(string.Format("Unregistered Hedgo Hoggo Object with ID : {0}.", inputId));
        }
        else 
        {
            _logger.LogError(string.Format("Cannot unregister Hedgo Hoggo Object with ID : {0} since it doesnt exist in object dictionary!", inputId));
        }
    }

    public ObjectHedgoHoggo FetchHedgoHoggoObject(int inputId)
    {
        if (_hedgoHoggoObjectsMap.ContainsKey(inputId))
        {
            return _hedgoHoggoObjectsMap[inputId];
        }
        return null;
    }

    public ViewHedgoHoggo FetchHedgoHoggoView(int inputId)
    {
        if (_hedgoHoggoViewsMap.ContainsKey(inputId))
        {
            return _hedgoHoggoViewsMap[inputId];
        }
        return null;
    }

    public int DetermineNextAvailableId()
    {
        if (_reusableIds.Count == 0)
        {
            return ++_lastCreatedId;
        }
        else
        {
            return _reusableIds.Pop();
        }
    }
}
