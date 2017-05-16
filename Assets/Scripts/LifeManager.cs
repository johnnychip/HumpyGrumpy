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

	void Start ()
	{
		myUI.UpdateHealth (life);
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag == "enemy") 
		{
			GameManager.Instance.NotifyDeath ();

			life -= 10;

			audioTouch.Play ();

			myUI.UpdateHealth (life);

			other.gameObject.SetActive (false);

			if (life <= 0) {
			
				myUI.GameOverUi ();

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
		life += 10;
	}

}
