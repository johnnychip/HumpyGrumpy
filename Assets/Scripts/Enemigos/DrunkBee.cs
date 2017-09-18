﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DrunkBee : Enemy {

	private float elapsedTime;

	private float drunkSpeed;

	// Use this for initialization
	void Awake ()
	{
		life = 3;
		currentLife = life;	
	}

	void Start () {
		speed = 0.06f;
		valuePoints = 10;
		drunkSpeed = 0.1f;
	}

	void Update ()
	{
		if (target != null && Time.timeScale > 0) 
		{
			FollowPlayer ();
			elapsedTime += Time.deltaTime;

			if (elapsedTime < 0.5f)
				transform.position = new Vector3 (transform.position.x, transform.position.y + drunkSpeed, transform.position.z);
			else {
				elapsedTime = 0;
				drunkSpeed *= -1;
			}
		}

	
		
	}

	void OnEnable ()
	{

		currentLife = life;
		ChangeLook ();


	}
	

}
