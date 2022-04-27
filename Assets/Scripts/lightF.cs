using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightF : MonoBehaviour
{
	[SerializeField] AudioClip clickingTheFL;
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
			SFX.instance.PlayClip(clickingTheFL, 1f);
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
