using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

public class ObjectHedgoHoggo
{
    public class Factory : PlaceholderFactory<int, ObjectHedgoHoggo> {}

    public delegate void PropertiesUpdatedDelegate();
    public event PropertiesUpdatedDelegate PropertiesUpdatesEvent;

    public int Id { get; private set; }
    public Color CurrentColor { get; private set; }
    public Vector3 CurrentPosition { get; private set; }
    
    public ObjectHedgoHoggo (int inputId)
    {
        Id = inputId;
        CurrentPosition = Vector3.zero;
        CurrentColor = Color.white;
    }

    public void UpdateCurrentColorToRandomColor()
    {
        UpdateCurrentColor(UnityEngine.Random.ColorHSV());
    }

    public void UpdateCurrentColor(Color inputColor)
    {
        CurrentColor = inputColor;
        if(PropertiesUpdatesEvent != null)
        {
            PropertiesUpdatesEvent();
        }
    }

    public void UpdateCurrentPosition(Vector3 inputPosition)
    {
        CurrentPosition = inputPosition;
        if (PropertiesUpdatesEvent != null)
        {
            PropertiesUpdatesEvent();
        }
    }
}
