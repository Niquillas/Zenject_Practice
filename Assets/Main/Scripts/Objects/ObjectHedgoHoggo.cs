using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

public class ObjectHedgoHoggo : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable
{
    public string CatchPhrase { get; private set; }

    [Inject] private ServiceLogger _logger;

    private IMemoryPool _pool;

    public class Factory : PlaceholderFactory<ObjectHedgoHoggo>
    {
        public ObjectHedgoHoggo GetInstance(string inputCatchPhrase)
        {
            ObjectHedgoHoggo hedgoHoggoInstance = base.Create();
            hedgoHoggoInstance.CatchPhrase = inputCatchPhrase;
            return hedgoHoggoInstance;
        }
    }

    public void Dispose()
    {
        if (_logger != null)
        {
            _logger.Log("ObjectHedgoHoggo GetInstance() called");
        }

        _pool.Despawn(this);
    }

    public void OnDespawned()
    {
        if (_logger != null)
        {
            _logger.Log("OnDespawned GetInstance() called");
        }

        _pool = null;
        // Other Cleanup that needs to happen
    }

    public void OnSpawned(IMemoryPool inputPool)
    {
        if (_logger != null)
        {
            _logger.Log("OnDespawned OnSpawned() called");
        }

        _pool = inputPool;
        // Other Initializations needs to happen
    }
}
