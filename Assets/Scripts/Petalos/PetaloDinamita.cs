using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetaloDinamita : Bullet {

	private Animator anim;

	void Start ()
	{
		InitialValues ();
		anim = GetComponent<Animator> ();
		hits = 1;
	}

	public void OnTriggerEnter2D (Collider2D other)
	{

		if (other.gameObject.tag == "byepetal") {

			gameObject.SetActive (false);

		}

		if (other.gameObject.tag == "enemy") {
			myCollider.enabled = false;
			anim.SetTrigger("exp");
			AreaDamageEnemies (gameObject.transform.position, 4f);

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

	void AreaDamageEnemies(Vector3 location, float radius)
	{	
		Vector2 realLocation = new Vector2 (location.x, location.y);
		Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(realLocation, radius);

		foreach (Collider2D col in objectsInRange)
		{
			Enemy enemy = col.GetComponent<Enemy>();
			if (enemy != null)
			{
				// linear falloff of effect
				float proximity = (location - enemy.transform.position).magnitude;
				float effect = 1 - (proximity / radius);


				enemy.TouchBullet (Attack);
			}
		}
		Invoke ("SolveHit", 0.15f);

	}

}
