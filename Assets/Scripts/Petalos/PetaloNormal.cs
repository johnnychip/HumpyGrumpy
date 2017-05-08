using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetaloNormal : Bullet {

	void Start ()
	{
		InitialValues ();
		hits = 1;
	}

	public void OnTriggerEnter2D (Collider2D other)
	{

		if (other.gameObject.tag == "byepetal") {

			gameObject.SetActive (false);

		}

		if (other.gameObject.tag == "enemy") {
			SolveHit ();
			other.gameObject.GetComponent<Enemy> ().TouchBullet (attack);
		}

	}

	public override void AddMove(Vector3 direction, Vector3 target)
	{	
		if (progresScale >= 1) 
		{
			isReady = false;
			float AngleRad = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
			float AngleDeg = (180 / Mathf.PI) * AngleRad;
			transform.eulerAngles = new Vector3 (0f, 0f, AngleDeg);
			rb.AddForce (direction * speed, ForceMode2D.Impulse);

			myCollider.enabled = true;

		}

	}


}
