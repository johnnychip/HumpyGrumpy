﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class Enemy : MonoBehaviour {

	public int valuePoints;

	public int life;

	public float speed;

	public Transform target;

	public int currentLife;

	public Vector3 rScale;

	public Vector3 lScale;

	public AudioSource deadSound;

	public MoneyPool myMoneyPool;

	public HearthsPool myHearthsPool;

	public BloodPool myBloodPool;

	public PowerUpsPool[] myPetalsPool;

	[SerializeField]
	private Animator anim;

	public void ChangeLook()
	{
        if (target != null) 
		{
			float suma = target.position.x - transform.position.x;

            if (suma <= 0) {
				transform.localScale = lScale;
			} else {
				transform.localScale = rScale;
			}
		}
		
	}

	/*void OnTriggerEnter2D ( Collider2D other)
	{
		if (other.gameObject.tag == "bullet") {
			{
				
				currentLife -= other.GetComponent<Bullet> ().Attack;
				other.GetComponent<Bullet> ().SolveHit ();
				anim.SetTrigger("onDamage");
				if (currentLife <= 0) {
					gameObject.SetActive (false);
					GameManager.Instance.NotifyHit (valuePoints);
				}
			}
		}
	}*/

	public void TouchBullet(int damage)
	{
		currentLife -= damage;
		myBloodPool.ActivateBloodParticlesPool(transform);
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);

		float tempFloat =  Mathf.Sign(transform.position.x - target.position.x);
		
		StatisticsManager.Instance.IncreaseCombo();

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

	/*private void DecreaseLife()
	{
		
		life--;
		if (life <= 0)
			gameObject.SetActive (false);
	}*/

	public void FollowPlayer()
    {	
		Vector3 directions = (target.position - transform.position).normalized;
		transform.Translate (directions*speed);
	}

	private void DeactivateEnemy ()
	{
		//myMoneyPool.ActivateMoneyBag (transform);
		SpawnPowerUp();
		GameManager.Instance.NotifyDeath ();
		gameObject.SetActive (false);
		GameManager.Instance.NotifyHit ();
	}

    /*private void Movement ()
	{	
		transform.Translate (target.position);	
	}*/

	public void SetTarget (Transform trans)
	{
		target = trans;

        float suma = trans.position.x - transform.position.x;

        if (suma<=0)
		{
			transform.localScale = lScale;
		}
	}

	public void LevelUp ()
	{
		life++;
		currentLife = life;
	}

	public void SpawnPowerUp()
	{
		int tempInt = UnityEngine.Random.Range(0,100);

		if (tempInt<40)
		{
			myHearthsPool.ActivateHearthsPool(transform);
		}

		if(tempInt>60)
		{
			int tempInt2 = UnityEngine.Random.Range(0,3);
			myPetalsPool[tempInt2].ActivatePowerUpsPool(transform);
		}
	}
}
