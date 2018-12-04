using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewUIPanel : MonoBehaviour 
{
	public void SetActive(bool inputActive)
    {
        this.gameObject.SetActive(inputActive);
    }
}
