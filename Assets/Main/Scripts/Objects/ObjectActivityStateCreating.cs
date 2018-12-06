using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectActivityStateCreating : ObjectActivityState
{
    private ServiceInput _inputService;
    private ServiceUtility _utilityService;
    private ServiceCenterHedgoHoggo _hedgoHoggoCenter;
    private LayerMask _viewCollisionMapLayerMask;

    public ObjectActivityStateCreating(
        ServiceInput inputInputService, 
        ServiceUtility inputUtilityService,
        ServiceCenterHedgoHoggo inputHedgoHoggoCenter,
        LayerMask inputViewCollisionMapLayerMask)
    {
        Name = "Creating";
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

        if(hit.transform != null)
        {
            if (_utilityService.CalculateLayerInLayermask(_viewCollisionMapLayerMask, hit.transform.gameObject.layer))
            {
                ViewCollisionMap collisionMap = hit.transform.gameObject.GetComponent<ViewCollisionMap>();
                if (collisionMap != null && collisionMap.FloorTransform != null)
                {
                    ViewHedgoHoggo hedgoHoggoView = _hedgoHoggoCenter.CreateHedgoHoggo();
                    _hedgoHoggoCenter.PositionHedgoHoggoViaFloor(hedgoHoggoView, hit.point);
                }
            }
        }
    }
}
