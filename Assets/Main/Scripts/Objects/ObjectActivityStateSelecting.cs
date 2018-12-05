using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectActivityStateSelecting : ObjectActivityState
{
    private ServiceInput _inputService;
    private ServiceUtility _utilityService;
    private ServiceCenterSelected _selectedCenter;
    private LayerMask _viewCollisionMapLayerMask;

    public ObjectActivityStateSelecting(
        ServiceInput inputInputService,
        ServiceUtility inputUtilityService,
        ServiceCenterSelected inputSelectedCenter,
        LayerMask inputViewCollisionMapLayerMask)
    {
        Name = "Selecting";
        _inputService = inputInputService;
        _utilityService = inputUtilityService;
        _selectedCenter = inputSelectedCenter;
        _viewCollisionMapLayerMask = inputViewCollisionMapLayerMask;
    }

    public override void Cleanup()
    {
        _inputService.MouseClickedEvent -= OnMouseClicked;
        _selectedCenter.DeselectAllViews();
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

                if (collisionMap != null)
                {
                    ViewHedgoHoggo hedgoHoggoView = collisionMap.HedgoHoggoView;

                    if (hedgoHoggoView != null)
                    {
                        if (_selectedCenter.CheckViewSelected(hedgoHoggoView))
                        {
                            _selectedCenter.DeselectView(hedgoHoggoView);
                        }
                        else
                        { 
                            ObjectPointer pointerObject = _selectedCenter.SelectView(hedgoHoggoView);
                            Vector3 spawnPosition = hedgoHoggoView.WorldPosition;
                            spawnPosition.y += hedgoHoggoView.WorldHeight / 2 + 3;
                            pointerObject.UpdatePosition(spawnPosition);                                                      
                            _selectedCenter.SynchronizePointers();
                        }
                    }
                }
            }
        }
    }
}
