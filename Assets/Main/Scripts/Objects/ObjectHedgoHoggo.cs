using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

public class ObjectHedgoHoggo
{
    public class Factory : PlaceholderFactory<Vector3, ObjectHedgoHoggo> {}

    public Color CurrentColor { get; private set; }
    public Vector3 CurrentPosition { get; private set; }

    public ObjectHedgoHoggo (Vector3 inputStartPosition)
    {
        CurrentPosition = inputStartPosition;
        CurrentColor = Color.white;
    }

    public void UpdateCurrentColor (Color inputColor)
    {
        if (inputColor == null)
        {
            inputColor = new Color();
        }
    }
}
