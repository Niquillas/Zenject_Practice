using System.Collections.Generic;

public class CollectionHedgoHoggo 
{
    private ServiceLogger _logger;
    private Dictionary<ViewHedgoHoggo, ObjectHedgoHoggo> _hedgoHoggoMap;

    public CollectionHedgoHoggo (ServiceLogger inputLogger)
    {
        _logger = inputLogger;
        _hedgoHoggoMap = new Dictionary<ViewHedgoHoggo, ObjectHedgoHoggo>();
    }

    public void RegisterHedgoHoggo(ObjectHedgoHoggo inputHedgoHoggoObject, ViewHedgoHoggo inputHedgoHoggoView)
    {
        if (!_hedgoHoggoMap.ContainsKey(inputHedgoHoggoView))
        {
            _hedgoHoggoMap.Add(inputHedgoHoggoView, inputHedgoHoggoObject);
            _logger.Log("Registered Hedgo Hoggo");
        }
        else
        {
            _logger.LogError("Cannot register Hedgo Hoggo since it already exists in object dictionary!");
        }
    }

    public void UnRegisterHedgoHoggo(ViewHedgoHoggo inputHedgoHoggoView)
    {
        if (_hedgoHoggoMap.Remove(inputHedgoHoggoView))
        {
            _logger.Log("Unregistered Hedgo Hoggo");
        }
        else 
        {
            _logger.LogError("Cannot unregister Hedgo Hoggo since it doesnt exist in object dictionary!");
        }
    }

    public ObjectHedgoHoggo FetchHedgoHoggoObject(ViewHedgoHoggo inputHedgoHoggoView)
    {
        if (_hedgoHoggoMap.ContainsKey(inputHedgoHoggoView))
        {
            return _hedgoHoggoMap[inputHedgoHoggoView];
        }
        return null;
    }
}
