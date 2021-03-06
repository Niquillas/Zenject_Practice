﻿using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectActivityStateColoring : ObjectActivityState
{
    private ServiceInput _inputService;
    private ServiceUtility _utilityService;
    private ServiceCenterHedgoHoggo _hedgoHoggoCenter;
    private LayerMask _viewCollisionMapLayerMask;

    public ObjectActivityStateColoring (
        ServiceInput inputInputService,
        ServiceUtility inputUtilityService, 
        ServiceCenterHedgoHoggo inputHedgoHoggoCenter,
        LayerMask inputViewCollisionMapLayerMask)
    {
        Name = "Coloring";
        _inputService = inputInputService;
        _utilityService = inputUtilityService;
        _hedgoHoggoCenter = inputHedgoHoggoCenter;
        _viewCollisionMapLayerMask = inputViewCollisionMapLayerMask;
    }

    public override void Cleanup()
    {
        _inputService.MouseClickedEvent -= OnMouseClicked;
    }

    public override void Setup()
    {
        _inputService.AllowTouchRaycasts = true;
        _inputService.MouseClickedEvent += OnMouseClicked;
    }

    public override void Tick()
    {

    }

    public void OnMouseClicked(Vector3 mousePosition)
    {
        RaycastHit hit = _inputService.RaycastFromMousePosition(mousePosition);

        if (hit.transform != null)
        {
            if (_utilityService.CalculateLayerInLayermask(_viewCollisionMapLayerMask, hit.transform.gameObject.layer))
            {
                ViewCollisionMap collisionMap = hit.transform.gameObject.GetComponent<ViewCollisionMap>();
                if (collisionMap != null && collisionMap.HedgoHoggoView != null)
                {
                    _hedgoHoggoCenter.ColorHedgoHoggoToRandom(collisionMap.HedgoHoggoView);
                }
            }
        }
    }
}
