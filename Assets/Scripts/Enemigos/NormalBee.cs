using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBee : Enemy {

	public override void LevelUp ()
	{
        //ERROR! maxLifeIncrease doesnt exist.
        
        /*
        if (life >= maxLifeIncrease)
			return;
        */

		life++;
		currentLife = life;
	}

    private void Awake()
    {
        life = 1;
        currentLife = life;
    }

    private void Start ()
    {
		speed = 0.06f;
		valuePoints = 10;
	}

	public override void LevelUpSpeed ()
	{
		if(speed<maxSpeed)
		{
			speed += 0.002f;
		}

	}

	private void Update ()
	{
        if (target != null && Time.timeScale > 0)
            FollowPlayer();
	}

	private void OnEnable ()
	{
		currentLife = life;
		ChangeLook ();
	}
}
