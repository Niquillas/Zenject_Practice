using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ServiceInput : ITickable
{
    public delegate void MouseClickedDelegate (Vector3 mousePosition);
    public event MouseClickedDelegate MouseClickedEvent;

    public bool AllowTouchRaycasts { get; set; }

    private const float RAYCAST_DISTANCE = 100f;
    private const float MAX_CLICK_DURATION = .25f;

    private float _mouseDownTimer;
    private Camera _mainCamera;

    public ServiceInput(Camera inputMainCamera)
    {
        _mainCamera = inputMainCamera;
        _mouseDownTimer = 0f;
        AllowTouchRaycasts = true;
    }

    public void Tick()
    {
        if (AllowTouchRaycasts)
        {
            if(Input.GetMouseButton(0))
            {
                _mouseDownTimer += Time.deltaTime;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() && _mouseDownTimer < MAX_CLICK_DURATION)
                {
                    if (MouseClickedEvent != null)
                    {
                        MouseClickedEvent(Input.mousePosition);
                    }
                }
                _mouseDownTimer = 0f;
            }
        }
    }

    public RaycastHit RaycastFromMousePosition(Vector3 inputMousePoint)
    {
        Transform mainCameraTransform = _mainCamera.transform;
        Ray cameraRay = _mainCamera.ScreenPointToRay(inputMousePoint);
        RaycastHit hitInfo;
        Physics.Raycast(cameraRay.origin, cameraRay.direction, out hitInfo, RAYCAST_DISTANCE);
        return hitInfo;
    }
}
