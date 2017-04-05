using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	[SerializeField]
	private float speed;

	private Vector3 directionY;

	[SerializeField]
	private float rotationYeah;

	[SerializeField]
	private Vector3 minScale;

	[SerializeField]
	private Vector3 maxScale;

	private CircleCollider2D myCollider;

	private bool isMoving;

	private bool isReady;

	private float progresScale;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		myCollider = gameObject.GetComponent<CircleCollider2D> ();
		isReady = true;
		progresScale = 1;
	}

	public void AddMove(Vector3 direction, Vector3 target)
	{	
		//transform.position = firePoint;
		//isMoving = true;
		if (progresScale >= 1) 
		{
			
			transform.rotation = Quaternion.LookRotation (target);
			rb.AddForce (direction * speed, ForceMode2D.Impulse);
			myCollider.enabled = true;

		}

	}

	public void GrowProces()
	{
		if (rb.velocity == Vector2.zero) 
		{
			progresScale += 0.1f;
			transform.localScale = Vector3.Lerp (minScale, maxScale, progresScale);
			if (progresScale >= 1)
				isReady = true;
		}
	}

	void OnEnable ()
	{	
		isReady = false;
		myCollider.enabled = false;
		progresScale = 0;
		transform.localScale = minScale;
	}

	// Update is called once per frame
	void Update () {
		/*if (isMoving) {
			rb.AddForce (directionY * speed);
		}*/
	}

	public bool IsReady {
		get {
			return isReady;
		}
	}
}
