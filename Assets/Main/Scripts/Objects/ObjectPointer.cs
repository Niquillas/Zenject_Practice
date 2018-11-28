using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectPointer
{
    public class Factory : PlaceholderFactory<ObjectPointer> { }

    public delegate void PropertiesUpdatedDelegate();
    public event PropertiesUpdatedDelegate PropertiesUpdatedEvent;
    public delegate void AnimationRestartDelegate();
    public event AnimationRestartDelegate AnimationRestartEvent;

    public Vector3 Position { get; set; }

    public void UpdatePosition (Vector3 inputPosition)
    {
        Position = inputPosition;
        if (PropertiesUpdatedEvent != null)
        {
            PropertiesUpdatedEvent();
        }
    }

    public void SignalAnimationRestart()
    { 
        if (AnimationRestartEvent != null)
        {
            AnimationRestartEvent(); 
        }
    }
}
