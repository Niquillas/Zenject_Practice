using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceMonoRunner : MonoBehaviour 
{
    [SerializeField] private Transform _mainCameraTransform;

    public Coroutine BeginCoroutine(IEnumerator inputRoutine)
    {
        return StartCoroutine(inputRoutine);
    }

    public void EndCoroutine(IEnumerator inputRoutine)
    {
        StopCoroutine(inputRoutine);
    }

    public RaycastHit RaycastFromMainCamera (LayerMask inputLayerMask, float inputRaycastDistance)
    {
        Ray cameraRay = new Ray(_mainCameraTransform.position, _mainCameraTransform.forward);
        RaycastHit hitInfo;
        Physics.Raycast(_mainCameraTransform.position, _mainCameraTransform.forward, out hitInfo, inputRaycastDistance, inputLayerMask);
        return hitInfo;
    }
}
