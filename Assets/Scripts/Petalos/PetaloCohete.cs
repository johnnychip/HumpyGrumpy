using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PetaloCohete : Bullet {

	private bool IsTrigger;

	public BoxCollider2D myBoxCollider;


	void Awake ()
	{
		
		InitialValues ();
		hits = 1;
		IsTrigger = false;
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
		myBoxCollider = gameObject.GetComponent<BoxCollider2D>();

	}

	public void OnTriggerEnter2D (Collider2D other)
	{

		if (other.gameObject.tag == "byepetal") 
		{
			gameObject.SetActive (false);
		}

		if (other.gameObject.tag == "enemy") {
			if (!IsTrigger) {
				IsTrigger = true;
				Vector3 direction = (other.gameObject.transform.position - transform.position).normalized;
				AddMove2 (direction, other.gameObject.transform.position);
			} else {
				
				SolveHit ();
				other.gameObject.GetComponent<Enemy> ().TouchBullet (Attack);
				IsTrigger = false;
			}

			
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
			myBoxCollider.enabled = true;
			//myCollider.enabled = true;
			//myCollider.radius = 1.5f;
	

		}

	}

	public void AddMove2(Vector3 direction, Vector3 target)
	{	
		if (progresScale >= 1) 
		{
			isReady = false;
			float AngleRad = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
			float AngleDeg = (180 / Mathf.PI) * AngleRad;
			transform.DORotate(new Vector3 (0f, 0f, AngleDeg),0.3f);
			//transform.eulerAngles = new Vector3 (0f, 0f, AngleDeg);
			//rb.AddForce (direction * speed, ForceMode2D.Impulse);
			rb.AddRelativeForce(Vector3.forward*speed, ForceMode2D.Impulse);
			myBoxCollider.enabled = false;
			myCollider.enabled = true;

		}

	}

}
