using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PetalPowerUp : MonoBehaviour {

	public event Action OnTouch;

	public Flower myFlower;

	public int petal;

	// Use this for initialization
	void OnMouseDown ()
	{
		myFlower.ChangePetal(petal);
		gameObject.SetActive(false);
	}

}
