using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

public class ViewPointer : MonoBehaviour, IPoolable<ObjectPointer, IMemoryPool>, IDisposable
{
    public class Factory : PlaceholderFactory<ObjectPointer, ViewPointer> { }

    [SerializeField] private Animator _animator;
    [SerializeField] private Renderer[] _renderers;
    [SerializeField] private Transform _selfTransform;

    private IMemoryPool _pool;
    private ObjectPointer _pointerObject;

    public void PlayAnimation()
    {
        _animator.StartPlayback();
    }

    public void PauseAnimation()
    {
        _animator.StopPlayback();
    }

    public void SetPosition (Vector3 inputPosition)
    {
        _selfTransform.position = inputPosition;
    }

    public void SetColor(Color inputColor)
    {
        for (int i = 0; i < _renderers.Length; i++)
        {
            for (int j = 0; j < _renderers[i].materials.Length; i++)
            {
                _renderers[i].materials[j].color = inputColor;
            }
        }
    }

    public void OnDespawned()
    {
        _pool = null;
        _pointerObject.PropertiesUpdatedEvent -= OnPropertiesUpdated;
        _pointerObject.AnimationRestartEvent -= OnAnimationRestart;
    }

    public void OnSpawned(ObjectPointer inputPointerObject, IMemoryPool inputPool)
    {
        _pointerObject = inputPointerObject;
        _pointerObject.PropertiesUpdatedEvent += OnPropertiesUpdated;
        _pointerObject.AnimationRestartEvent += OnAnimationRestart;
        _pool = inputPool;
    }

    public void OnPropertiesUpdated()
    {
        SetPosition(_pointerObject.Position);
    }

    public void OnAnimationRestart()
    {
        _animator.Rebind();
    }

    public void Dispose()
    {
        _pool.Despawn(this);
    }
}