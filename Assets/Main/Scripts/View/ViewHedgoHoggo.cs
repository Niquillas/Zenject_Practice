using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

public class ViewHedgoHoggo : MonoBehaviour, IPoolable<ObjectHedgoHoggo, IMemoryPool>, IDisposable
{
    public class Factory : PlaceholderFactory<ObjectHedgoHoggo, ViewHedgoHoggo> {}

    [SerializeField] private Transform _selfTransform;
    [SerializeField] private Renderer _cubeRenderer;

    private ObjectHedgoHoggo _hedgoHoggoObject;
    private IMemoryPool _pool;

    public void OnDespawned()
    {
        _hedgoHoggoObject = null;
        _pool = null;
    }

    public void OnSpawned(ObjectHedgoHoggo inputHedgoHoggoObject, IMemoryPool inputPool)
    {
        _hedgoHoggoObject = inputHedgoHoggoObject;
        _pool = inputPool;
    }

    public void Dispose ()
    {
        _pool.Despawn(this);
    }

    public void SetPosition(Vector3 inputPosition)
    {
        _selfTransform.position = inputPosition;
    }

    public void SetColor(Color inputColor)
    {
        Material[] mats = _cubeRenderer.materials;
        for (int i = 0; i < mats.Length; i++)
        {
            mats[i].color = inputColor;
        }
    }
}
