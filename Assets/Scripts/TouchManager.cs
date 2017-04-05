using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour {

	private Vector3 startPosition;
	private Vector3 endPosition;
	private float startTime;
	private float endTime;

	[SerializeField]
	private float maxTime;

	[SerializeField]
	private float minDistance;

	[SerializeField]
	private Flower myFlower;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		CheckTouch ();

	}

	void CheckTouch ()
	{
		if (Input.touchCount > 0) 
		{
			
			Touch swipeTouch = Input.GetTouch (0);

			if (swipeTouch.phase == TouchPhase.Began) 
			{
				startPosition = swipeTouch.position;
				startTime = Time.time;

			}

			if (swipeTouch.phase == TouchPhase.Ended) 
			{
				endPosition = swipeTouch.position;
				endTime = Time.time;

				float swipeMagnitude = (endPosition - startPosition).magnitude;

				if (swipeMagnitude > minDistance) 
				{
					
					Vector3 swipeDirection = (endPosition - startPosition).normalized;
					swipeDirection.z = 0f;
					myFlower.ShootBullet (swipeDirection, endPosition);

				}
			}

		}
	}
}
