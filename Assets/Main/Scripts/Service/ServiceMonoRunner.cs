using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceMonoRunner : MonoBehaviour 
{
    public Coroutine BeginCoroutine(IEnumerator inputRoutine)
    {
        return StartCoroutine(inputRoutine);
    }

    public void EndCoroutine(IEnumerator inputRoutine)
    {
        StopCoroutine(inputRoutine);
    }
}
