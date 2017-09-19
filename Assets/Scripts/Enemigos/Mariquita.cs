using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mariquita : Enemy {

	void Awake ()
	{
		life = 2;
		currentLife = life;	
	}

	void Start () {
		speed = 0.06f;
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
