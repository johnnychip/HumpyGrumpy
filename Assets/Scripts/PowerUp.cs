using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp: MonoBehaviour {

	public float timeToDeactivate;

	private float elapsedTime;

	public void ClockDeactivation()
	{
		if(elapsedTime<timeToDeactivate)
		{
			elapsedTime += Time.deltaTime;
		}
		else
		{
			elapsedTime = 0;
			gameObject.SetActive(false);
		}

	}

}
