using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MagnetPowerUp : MonoBehaviour {
	
	[Header("Magnet properties")]

	[SerializeField]
	private float magnetArea;
	[SerializeField]
	private float magnetVelocity;
	[SerializeField]
	private AnimationCurve magnetInterpolation;
	
	// Hidden components
	private bool isMagnet;
	private IEnumerator magnet;

	private void Start ()
	{
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
	}
	
	private void Update ()
	{
		if (isMagnet)
			DoTouch();
	}

	private void OnMouseDown()
    {
		isMagnet = true;
    }

	private void DoTouch()
	{
		if (Input.touchCount > 0)
		{
			Touch myTouch = Input.GetTouch(0);

			transform.position = Camera.main.ScreenToWorldPoint(new Vector3(
				myTouch.position.x,
				myTouch.position.y,
				transform.position.z));
			
			isMagnet = false;

			DoCircleCast();
		}
	} 

	private void DoCircleCast()
	{
	 	Collider2D[] allEnemyes = Physics2D.OverlapCircleAll(transform.position, magnetArea);

		foreach (Collider2D collider in allEnemyes)
		{

			FastBee temp = collider.gameObject.GetComponent<FastBee>();

			if(temp == null)
			{
			if (collider.gameObject.CompareTag("enemy"))							
				collider.transform.DOMove(
					transform.position,
					Vector3.Distance(transform.position, collider.transform.position) * magnetVelocity,
					false).SetEase(magnetInterpolation);
			}
		}
	}
}
