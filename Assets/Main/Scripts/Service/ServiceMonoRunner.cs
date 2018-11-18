using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceMonoRunner : MonoBehaviour 
{
    public delegate void TickDelegate();
    public event TickDelegate TickEvent;

    public delegate void StartDelegate();
    public event TickDelegate StartEvent;

    private void Start () 
    {
        if (StartEvent != null)
        {
            StartEvent();
        }
	}
	
	private void Update () 
    {
        if (TickEvent != null)
        {
            TickEvent();
        }
    }
}
