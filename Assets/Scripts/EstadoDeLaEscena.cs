using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoDeLaEscena : MonoBehaviour {

	[SerializeField]
	private GameObject menu;
	[SerializeField]
	private GameObject shop;

	// Use this for initialization
	void Start () 
	{
		switch(GameManager.Instance.MenuState)
		{
			
		case 0:
			menu.SetActive (true);
			shop.SetActive (false);
		break;

		case 1:
			menu.SetActive (false);
			shop.SetActive (true);
		break;

		}

	}

}
