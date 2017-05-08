using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour {


	public float speed;

	public int baseHit;

	public Vector3 minScale;

	public Vector3 maxScale;

	public int level;

	public int attack;

	public CircleCollider2D myCollider;

	public bool isMoving;

	public bool isReady;

	public float progresScale;

	public Rigidbody2D rb;

	public int hits;

	// Use this for initialization




	public abstract void AddMove (Vector3 direction, Vector3 target);

	public void GrowProces()
	{
		if (rb.velocity == Vector2.zero) 
		{
			progresScale += 0.2f;
			transform.localScale = Vector3.Lerp (minScale, maxScale, progresScale);
			if (progresScale >= 1)
				isReady = true;
		}
	}

	public void LevelUp()
	{
		level++;
		attack++;
	}

	public void SolveHit()
	{
		hits--;
		if (hits <= 0)
			gameObject.SetActive (false);
	}

	void OnEnable ()
	{	
		hits = baseHit;
		progresScale = 0;
		transform.localScale = minScale;
		if(myCollider != null)
		myCollider.enabled = false;
	}

	void OnDisable ()
	{
		isReady = false;
	}

	// Update is called once per frame
	void Update () {
		/*if (isMoving) {
			rb.AddForce (directionY * speed);
		}*/
	}

	public void InitialValues ()
	{
		rb = gameObject.GetComponent<Rigidbody2D> ();
		myCollider = gameObject.GetComponent<CircleCollider2D> ();
		myCollider.enabled = false;
		isReady = false;
		progresScale = 0;
		level = 1;
		attack = 1;
	}

	public bool IsReady {
		get {
			return isReady;
		}
	}

	public int Attack {
		get {
			return attack;
		}
	}
}
