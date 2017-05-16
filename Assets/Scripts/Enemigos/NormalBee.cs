using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBee : Enemy {


	void Awake ()
	{
		life = 1;
		currentLife = life;	
	}

	void Start () {
		speed = 0.1f;
		valuePoints = 10;
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
