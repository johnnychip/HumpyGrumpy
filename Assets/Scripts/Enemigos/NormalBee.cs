using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBee : Enemy {


	void Start () {
		life = 1;
		currentLife = life;	
		speed = 0.1f;
		valuePoints = 10;
	}

	void Update ()
	{
		if(target != null && Time.timeScale > 0)
			FollowPlayer ();
	}
}
