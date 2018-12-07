using Zenject;
using System;
using UnityEngine;

[Serializable()]
public class ObjectHedgoHoggo
{
    public class Factory : PlaceholderFactory<ObjectHedgoHoggo> { };

    public delegate void PropertiesUpdatedDelegate();
    [field: NonSerialized()]
    public event PropertiesUpdatedDelegate PropertiesUpdatesEvent;

    public Color CurrentColor 
    { 
        get
        {
            return new Color(_currentColorR, _currentColorG, _currentColorB, _currentColorA);
        }
    }

    public Vector3 CurrentPosition
    {
        get
        {
            return new Vector3(_currentPositionX, _currentPositionY, _currentPositionZ);
        }
    }

    private float _currentColorR;
    private float _currentColorG;
    private float _currentColorB;
    private float _currentColorA;
    private float _currentPositionX;
    private float _currentPositionY;
    private float _currentPositionZ;

    public ObjectHedgoHoggo ()
    {
        _currentColorR = 255;
        _currentColorG = 255;
        _currentColorB = 255;
        _currentColorA = 1;
        _currentPositionX = 0;
        _currentPositionY = 0;
        _currentPositionZ = 0;
    }

    public void UpdateCurrentColorToRandomColor()
    {
        UpdateCurrentColor(UnityEngine.Random.ColorHSV());
    }

    public void UpdateCurrentColor(Color inputColor)
    {
        _currentColorR = inputColor.r;
        _currentColorG = inputColor.g;
        _currentColorB = inputColor.b;
        _currentColorA = inputColor.a;
        if(PropertiesUpdatesEvent != null)
        {
            PropertiesUpdatesEvent();
        }
    }

    public void UpdateCurrentPosition(Vector3 inputPosition)
    {
        _currentPositionX = inputPosition.x;
        _currentPositionY = inputPosition.y;
        _currentPositionZ = inputPosition.z;
        if (PropertiesUpdatesEvent != null)
        {
            PropertiesUpdatesEvent();
        }
    }
}
