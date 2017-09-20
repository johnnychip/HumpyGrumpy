using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesapearWhenTouch : MonoBehaviour {

	[SerializeField]
	private int touchToKill;

	private int touchCount;

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			touchCount++;

			if(touchCount>=touchToKill)
			{
			Destroy (gameObject);
			}

		}
	}


}
