using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetaloMartillo : Bullet {

	private Animation anim;

	private AnimationClip shootAnimation;

	// Use this for initialization
	void Start () {
		InitialValues ();
		hits = 1;
		anim = GetComponent<Animation> ();
	}
	
	public void OnTriggerEnter2D (Collider2D other)
	{

		if (other.gameObject.tag == "byepetal") {

			gameObject.SetActive (false);
			anim.Stop ();

		}

		if (other.gameObject.tag == "enemy") {
			other.gameObject.GetComponent<Enemy> ().TouchBullet (Attack);
		}

	}


	public override void AddMove(Vector3 direction, Vector3 target)
	{

		if (progresScale >= 1) 
		{
			anim.Play ();
			isReady = false;
			rb.AddForce (direction * speed, ForceMode2D.Impulse);

			myCollider.enabled = true;

		}

	}

}
