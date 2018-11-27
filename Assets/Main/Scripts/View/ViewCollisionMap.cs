using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCollisionMap : MonoBehaviour 
{
    public Transform FloorTransform
    {
        get
        {
            return _floorTransform;
        }
    }

    public ViewHedgoHoggo HedgoHoggoView 
    {
        get
        {
            return _hedgoHoggoView;
        }
    }

    [SerializeField] private Transform _floorTransform;
    [SerializeField] private ViewHedgoHoggo _hedgoHoggoView;
}
