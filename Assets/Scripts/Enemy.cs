using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField]
	private int life;

	[SerializeField]
	private float speed;

	[SerializeField]
	private Transform target;


	void Update (){
		if(target != null)
		FollowPlayer ();

	
	}

	void OnTriggerEnter2D ( Collider2D other)
	{
		if (other.gameObject.tag == "bullet") {
			{
				GameManager.Instance.NotifyHit ();
				other.gameObject.SetActive (false);
				Destroy (gameObject);
			}
		}

		/*if (other.gameObject.tag == "plant") {
		}*/
			
	}

	private void DecreaseLife()
	{
		
		life--;
		if (life <= 0)
			gameObject.SetActive (false);

	}

	public void FollowPlayer() {
	
		Vector3 directions = (target.position - transform.position).normalized;
		transform.Translate (directions*Time.deltaTime);

	}



	private void Movement ()
	{
		transform.Translate (target.position);	
	}


	public void SetTarget (Transform trans)
	{
		target = trans;
	}
}
