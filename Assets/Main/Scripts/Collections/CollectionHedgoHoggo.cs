using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CollectionHedgoHoggo 
{
    [Serializable()]
    public class Data
    {
        public List<ObjectHedgoHoggo> HedgoHoggos { get; private set; }

        public Data (CollectionHedgoHoggo inputHedgoHoggoCollection)
        {
            HedgoHoggos = inputHedgoHoggoCollection._hedgoHoggoMap.Values.ToList();
        }
    }

    public List<ViewHedgoHoggo> RegisteredHedgoHoggoViews
    { 
        get
        {
            return _hedgoHoggoMap.Keys.ToList();
        }
    }

    public List<ObjectHedgoHoggo> RegisteredHedgoHoggoObjects
    {
        get
        {
            return _hedgoHoggoMap.Values.ToList();
        }
    }

    private string _savePath;
    private ServiceLogger _logger;
    private Dictionary<ViewHedgoHoggo, ObjectHedgoHoggo> _hedgoHoggoMap;

    public CollectionHedgoHoggo (ServiceLogger inputLogger)
    {
        _savePath = Path.Combine(UnityEngine.Application.persistentDataPath, "collectionHedgoHoggoData.xml");
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

    public Data Save()
    {
        Data saveData = null;

        try
        {
            Stream stream = File.Open(_savePath, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            saveData = new Data(this);
            formatter.Serialize(stream, saveData);
            stream.Close();
        }
        catch (Exception e)
        {
            _logger.LogError(String.Format("Couldn't save data because of exception : {0}", e.ToString()));
        }

        return saveData;
    }

    public Data Load()
    {
        Data saveData = null;

        try
        {
            Stream stream = File.Open(_savePath, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            saveData = (Data)formatter.Deserialize(stream);
            stream.Close();
        }
        catch (Exception e)
        {
            _logger.LogError(String.Format("Couldn't load data because of exception : {0}", e.ToString()));
        }

        return saveData;
    }
}
