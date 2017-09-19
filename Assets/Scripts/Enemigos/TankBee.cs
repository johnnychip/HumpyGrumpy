using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBee : Enemy {

	// Use this for initialization
	void Awake ()
	{
		life = 5;
		currentLife = life;	
	}

	void Start () {
		speed = 0.01f;
		valuePoints = 30;
	}

	void Update ()
	{
		if(target != null && Time.timeScale > 0)
			FollowPlayer ();


	}

	void OnEnable ()
	{

		currentLife = life;
		ChangeLook ();


	}

}
