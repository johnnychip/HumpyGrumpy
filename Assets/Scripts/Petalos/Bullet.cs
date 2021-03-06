﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour {


	public float speed;

	public int baseHit;

	public Vector3 minScale;

	public Vector3 maxScale;

	private int attack;

	public CircleCollider2D myCollider;

	public bool isMoving;

	public bool isReady;

	public float progresScale;

	public Rigidbody2D rb;

	public int hits;

	public AudioSource audioGrow;

	public ParticleSystem particleGrow;

	public SpriteRenderer mySpriteRenderer;

	public Color enalbeColor, disableColor;

	// Use this for initialization




	public abstract void AddMove (Vector3 direction, Vector3 target);

	public void GrowProces()
	{
		if (rb.velocity == Vector2.zero) 
		{
			progresScale += 0.34f;
			transform.localScale = Vector3.Lerp (minScale, maxScale, progresScale);
			if (progresScale >= 1 && !isReady) {
				isReady = true;
				audioGrow.Play ();
				particleGrow.Emit (5);
				mySpriteRenderer.color = enalbeColor;
			}
		}

		Debug.Log("Progrese Sacale " +progresScale);
	}

	public void GrowProces(float sizeTo)
	{
			progresScale += sizeTo;
			transform.localScale = Vector3.Lerp (minScale, maxScale, progresScale);
			if (progresScale >= 1 && !isReady) {
				isReady = true;
				audioGrow.Play ();
				particleGrow.Emit (5);
				mySpriteRenderer.color = enalbeColor;
			}	
			Debug.Log("Progrese Sacale " +progresScale);
	}

	public void LevelUp(int levelTo)
	{
		attack = levelTo;
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
		transform.localScale = minScale;
		if(myCollider != null)
		myCollider.enabled = false;
		mySpriteRenderer.color = disableColor;
	}

	void OnDisable ()
	{
		isReady = false;
		progresScale = 0;
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
		mySpriteRenderer = GetComponent<SpriteRenderer>();
		isReady = false;
		progresScale = 0;
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
