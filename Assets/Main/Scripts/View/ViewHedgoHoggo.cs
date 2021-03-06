﻿using System;
using UnityEngine;
using Zenject;

public class ViewHedgoHoggo : MonoBehaviour, IPoolable<ObjectHedgoHoggo, IMemoryPool>, IDisposable
{
    public class Factory : PlaceholderFactory<ObjectHedgoHoggo, ViewHedgoHoggo> {}

    public Transform SelfTransform
    { 
        get
        {
            return _selfTransform;
        }
    }

    public Vector3 WorldPosition
    { 
        get
        {
            return _selfTransform.position;
        }
    }

    public float WorldHeight
    { 
        get
        {
            return 1;
        }
    }

    [SerializeField] private Transform _selfTransform;
    [SerializeField] private Renderer _cubeRenderer;

    private ObjectHedgoHoggo _hedgoHoggoObject;
    private IMemoryPool _pool;

    public void OnDespawned()
    {
        _hedgoHoggoObject.PropertiesUpdatesEvent -= OnPropertiesUpdated;
        _hedgoHoggoObject = null;
        _pool = null;
    }

    public void OnSpawned(ObjectHedgoHoggo inputHedgoHoggoObject, IMemoryPool inputPool)
    {
        _hedgoHoggoObject = inputHedgoHoggoObject;
        _hedgoHoggoObject.PropertiesUpdatesEvent += OnPropertiesUpdated;
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

    public void OnPropertiesUpdated()
    {
        SetPosition(_hedgoHoggoObject.CurrentPosition);
        SetColor(_hedgoHoggoObject.CurrentColor);
    }
}
