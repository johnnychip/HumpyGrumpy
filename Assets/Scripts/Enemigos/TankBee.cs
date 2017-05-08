using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBee : Enemy {

	// Use this for initialization
	void Start () {
		life = 3;
		currentLife = life;	
		speed = 0.03f;
		valuePoints = 30;
	}

	void Update ()
	{
		if(target != null && Time.timeScale > 0)
			FollowPlayer ();


	}

}
