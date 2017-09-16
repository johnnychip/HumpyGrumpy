using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {

	[SerializeField]
	private int life;

	[SerializeField]
	private UIManager myUI;

	[SerializeField]
	private AudioSource audioTouch;

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag == "enemy") 
		{
			GameManager.Instance.NotifyDeath ();

			life -= 10;

			audioTouch.Play ();

			myUI.DeacreaseHealth ();

			other.gameObject.SetActive (false);

			if (life <= 0) {
				
				myUI.GameOverUi ();
				gameObject.SetActive(false);

			}
		}

	}

	public int Life {
		get {
			return life;
		}
	}

	public void IncreasLife ()
	{
		if(life<100)
		life += 10;
	}

}
