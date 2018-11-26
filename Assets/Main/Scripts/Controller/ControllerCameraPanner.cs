using UnityEngine;
using System.Collections;

public class ControllerCameraPanner : MonoBehaviour 
{
    public bool m_lerp = false;
    public Transform m_cameraTrans;
    public Transform m_focusTrans;
    public float startingDistance;
    public float maxDistance;
    public float minDistance;
    public float mousePanSpeed;
    public float fingerPanSpeed;
    public float yStartAngle = 30;
    public float yMaxAngle = 80f;
    public float yMinAngle = 0.8f;
	public float zoomRate = 40;
	public float zoomDampening = 5;

    private float distance = 0.0f;
    private float xSpeed;
    private float ySpeed;
	private float xDeg = 0.0f;
	private float yDeg = 0.0f;
    private float currentDistance;
    private float desiredDistance;
	private Quaternion currentRotation;
	private Quaternion desiredRotation;
	private Quaternion rotation;
	private Vector3 position;
	private Vector3 hitPoint = Vector3.zero;
	private bool dragging = false;
    private float scrollInputValue = 0f;
    private Vector3 targetPos;
    private bool canLerpResetAngle = true;

    void Awake()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            xSpeed = fingerPanSpeed;
            ySpeed = fingerPanSpeed;
        }
        else
        {
            xSpeed = mousePanSpeed;
            ySpeed = mousePanSpeed;
        }

        m_cameraTrans.position = new Vector3(m_cameraTrans.position.x, 1, m_cameraTrans.position.z);
        distance = startingDistance;
        currentDistance = Vector3.Distance(m_cameraTrans.position, m_focusTrans.position);
        desiredDistance = distance;
        m_cameraTrans.LookAt(m_focusTrans);
        position = m_cameraTrans.position;
        rotation = m_cameraTrans.rotation;
        currentRotation = m_cameraTrans.rotation;
        desiredRotation = m_cameraTrans.rotation;
        xDeg = 0;
        yDeg = yStartAngle;

        if (m_cameraTrans.position.y < m_focusTrans.position.y)
            yDeg *= -1;

        targetPos = m_focusTrans.position;
    }
    
    public void RunTurningLogic(float xMovement, float yMovement)
    {
        canLerpResetAngle = false;
        xDeg += xMovement * xSpeed * 0.02f;
        yDeg -= yMovement * ySpeed * 0.02f;
    }

    public void FinishTurningLogic()
    {
        canLerpResetAngle = true;
    }

    public void RunZoomLogic(float inputVal)
    {
        scrollInputValue = inputVal;
    }

    void LateUpdate()
	{
        if (m_focusTrans != null)
		{
            yDeg = ClampAngle(yDeg, 0, 90);

            if (canLerpResetAngle)
            {
                if (yDeg > yMaxAngle)
                {
                    if(m_lerp)
                        yDeg = Mathf.Lerp(yDeg, yMaxAngle, Time.deltaTime * zoomDampening);
                    else
                        yDeg = yMaxAngle;
                }
                else if (yDeg < yMinAngle)
                {
                    if (m_lerp)
                        yDeg = Mathf.Lerp(yDeg, yMinAngle, Time.deltaTime * zoomDampening);
                    else
                        yDeg = yMinAngle;
                }
            }

            // set camera rotation 
            desiredRotation = Quaternion.Euler(yDeg, xDeg, 0);
            currentRotation = m_cameraTrans.rotation;

            if (m_lerp)
                rotation = Quaternion.Lerp(currentRotation, desiredRotation, Time.deltaTime * zoomDampening);
            else
                rotation = desiredRotation;

            m_cameraTrans.rotation = rotation;

            ////////Orbit Position
            // affect the desired Zoom distance if we roll the scrollwheel
            desiredDistance -= scrollInputValue * Time.deltaTime * zoomRate * Mathf.Abs(desiredDistance);
            //clamp the zoom min/max

            desiredDistance = Mathf.Clamp(desiredDistance, minDistance, maxDistance);
            // For smoothing of the zoom, lerp distance
            if (m_lerp)
                currentDistance = Mathf.Lerp(currentDistance, desiredDistance, Time.deltaTime * zoomDampening);
            else
                currentDistance =desiredDistance;

            if (m_lerp)
                targetPos = Vector3.Lerp(targetPos, m_focusTrans.position, Time.deltaTime * zoomDampening);
            else
                targetPos = m_focusTrans.position;
            position = targetPos - (rotation * Vector3.forward * currentDistance);

            m_cameraTrans.position = position;
		}
	}

    public void SetZoomDistanceToStarting()
    {
        desiredDistance = startingDistance;
    }

    public void SetDesiredZoomDistance(float dist)
    {
        desiredDistance = dist;
    }

	private static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;
		return Mathf.Clamp(angle, min, max);
	}
		
	IEnumerator DragObject (Vector3 startingHit)
	{
		while (Input.GetMouseButton (0) && dragging)
		{	
			var translation = startingHit - hitPoint;
			//translation.x = Mathf.Clamp(translation.x,-0.1f,0.1f);
			//translation.z = Mathf.Clamp(translation.z,-0.1f,0.1f);
			Camera.main.transform.position = Camera.main.transform.position + translation;
            m_focusTrans.position = m_focusTrans.position + translation;
			yield return null;
		}
		dragging = false;
	}

    public void SetTarget(Transform inputFocusTransform)
	{
        m_focusTrans = inputFocusTransform;
    }
}