using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

public class ViewHedgoHoggo : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable
{
    public class Factory : PlaceholderFactory<ViewHedgoHoggo> {}

    private IMemoryPool _pool;

    public void OnDespawned()
    {
        _pool = null;
    }

    public void OnSpawned(IMemoryPool inputPool)
    {
        _pool = inputPool;
    }

    public void Dispose ()
    {
        _pool.Despawn(this);
    }
}
