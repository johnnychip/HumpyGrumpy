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

	[SerializeField]
	private Animator anim;


	void OnEnable ()
	{

		currentLife = life;
		if (target != null) {
			float suma = target.position.x - transform.position.x;
			if (suma <= 0) {
				transform.localScale = lScale;
			} else {
				transform.localScale = rScale;
			}
		}

	}

	void OnDisable ()
	{

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
		anim.SetTrigger("onDamage");
		if (currentLife <= 0) {
			GameManager.Instance.NotifyDeath ();
			gameObject.SetActive (false);
			GameManager.Instance.NotifyHit (valuePoints);
		}
	}

	private void DecreaseLife()
	{
		
		life--;
		if (life <= 0)
			gameObject.SetActive (false);

	}

	public void FollowPlayer() {
	
		Vector3 directions = (target.position - transform.position).normalized;
		transform.Translate (directions*speed);

	}



	private void Movement ()
	{	
		
		transform.Translate (target.position);	
	}


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
	}
}
