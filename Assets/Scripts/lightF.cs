using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightF : MonoBehaviour
{
	Light flashLight;
	public bool flashlightActive = true;
	void Start()
	{
		flashLight = gameObject.GetComponent<Light>();
		flashLight.enabled = true;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			if (flashlightActive == false)
			{
				flashlightActive = true;
				flashLight.enabled = true;	
			}
			else
			{
				flashlightActive = false;
				flashLight.enabled = false;	
			}
		}
	}
}
