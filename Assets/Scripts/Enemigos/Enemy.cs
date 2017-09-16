using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

        if (currentLife <= 0) {
			deadSound.Play ();
			anim.SetTrigger ("Die");
            ComboCounter.Instance.IncreaseComboCount();
            Invoke ("DeactivateEnemy", 0.2f);
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
		int tempInt = UnityEngine.Random.Range(0,11);

		if (tempInt<5)
		{
			myHearthsPool.ActivateHearthsPool(transform);
		}

		if(tempInt>5)
		{
			int tempInt2 = UnityEngine.Random.Range(0,4);
			myPetalsPool[tempInt2].ActivatePowerUpsPool(transform);
		}
	}
}
