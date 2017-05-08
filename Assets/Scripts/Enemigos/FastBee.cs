using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBee : Enemy {

	// Use this for initialization
	void Start () {
		life = 1;
		currentLife = life;	
		speed = 0.2f;
		valuePoints = 30;
	}

	void Update ()
	{
		if(target != null && Time.timeScale > 0)
			FollowPlayer ();
	}
	

}
