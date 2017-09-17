using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthRecuperator : PowerUp {


	public event Action OnTouch;

	// Use this for initialization
	void OnMouseDown ()
	{
		if (OnTouch != null)
			OnTouch ();
		gameObject.SetActive(false);
	}

	void Update()
	{
		ClockDeactivation();
	}
}
