using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceUtility
{
    public bool CalculateLayerInLayermask(LayerMask inputLayerMask, LayerMask inputLayer)
    {
        return (inputLayerMask == (inputLayerMask | (1 << inputLayer)));
    }
}
