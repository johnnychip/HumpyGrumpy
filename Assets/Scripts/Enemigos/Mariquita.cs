using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

	public override void LevelUpSpeed ()
	{
		if(speed<maxSpeed)
		{
			speed += 0.002f;
		}

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

	public override void TouchBullet(int damage)
	{
		currentLife -= damage;
		myBloodPool.ActivateBloodParticlesPool(transform);
		myOnomatopella.ActivatePowerUpsPool(transform);
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);

		float tempFloat =  Mathf.Sign(transform.position.x - target.position.x);
		


		StatisticsManager.Instance.IncreaseCombo();

		//anim.SetBool("isInjured",true);

        if (currentLife <= 0) {
			deadSound.Play ();
			anim.SetTrigger ("Die");
            StatisticsManager.Instance.IncreaseKills();
            Invoke ("DeactivateEnemy", 0.2f);
		}
		else
		{
			transform.DOMove((new Vector3((transform.position.x+(0.5f*tempFloat)),transform.position.y,transform.position.z)),1f, false);
		}
	}
}
