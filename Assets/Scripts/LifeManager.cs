using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {

	[SerializeField]
	private int life;

	[SerializeField]
	private UIManager myUI;

	void Start ()
	{
		myUI.UpdateHealth (life);
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag == "enemy") 
		{

			life -= 10;

			myUI.UpdateHealth (life);

			Destroy (other.gameObject);

			if (life <= 0) {
			
				myUI.GameOverUi ();

			}
		}

	}

}
