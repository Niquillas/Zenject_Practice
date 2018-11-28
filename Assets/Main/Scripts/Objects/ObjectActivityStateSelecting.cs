using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivityStateSelecting : ObjectActivityState
{
    private ViewUIPanelMain _mainPanelView;
    private ServiceInput _inputService;
    private ServiceUtility _utilityService;
    private ServiceCenterSelected _selectedCenter;
    private LayerMask _viewCollisionMapLayerMask;

    public ObjectActivityStateSelecting(ViewUIPanelMain inputMainPanelView,
                                        ServiceInput inputInputService,
                                        ServiceUtility inputUtilityService,
                                        ServiceCenterSelected inputSelectedCenter,
                                        LayerMask inputViewCollisionMapLayerMask)
    {
        _mainPanelView = inputMainPanelView;
        _inputService = inputInputService;
        _utilityService = inputUtilityService;
        _selectedCenter = inputSelectedCenter;
        _viewCollisionMapLayerMask = inputViewCollisionMapLayerMask;
    }

    public override void Cleanup()
    {
        _inputService.MouseClickedEvent -= OnMouseClicked;
        _selectedCenter.DeSelectAllHedgoHoggos();
    }

    public override void Setup()
    {
        _inputService.AllowTouchRaycasts = true;
        _mainPanelView.SetCurrentActivityStateText("Selecting State");
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
                        if (_selectedCenter.CheckIfHedgoHoggoSelected(hedgoHoggoView))
                        {
                            _selectedCenter.DeSelectHedgoHoggo(hedgoHoggoView);
                        }
                        else
                        { 
                            ObjectPointer pointerObject = _selectedCenter.SelectHedgoHoggo(hedgoHoggoView);
                            Vector3 spawnPosition = hedgoHoggoView.SelfTransform.position;
                            spawnPosition.y += 5;
                            pointerObject.UpdatePosition(spawnPosition);
                            _selectedCenter.SynchronizeHedgoHoggoPointers();
                        }
                    }
                }
            }
        }
    }
}
