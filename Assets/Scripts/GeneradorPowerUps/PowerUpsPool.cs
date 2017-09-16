using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsPool : MonoBehaviour {

	[SerializeField]
	private GameObject prefPowerUp;

	[SerializeField]
	private Flower myFlower;

	private GameObject[] powerUpsPool = new GameObject[5];

	private int currentPowerUp;

	void Awake () 
	{
		CreatPowerUpsPool ();
	}

	public void ActivatePowerUpsPool (Transform transEnemy)
	{
		if (currentPowerUp >= powerUpsPool.Length) currentPowerUp = 0;

		powerUpsPool [currentPowerUp].transform.position = transEnemy.position;
		powerUpsPool [currentPowerUp].SetActive (true);
		currentPowerUp++;
		
	}

	void CreatPowerUpsPool ()
	{
		for (int i = 0; i < powerUpsPool.Length; i++)
		{

			powerUpsPool [i] = Instantiate (prefPowerUp);
			powerUpsPool [i].GetComponent<PetalPowerUp> ().myFlower = myFlower;
			powerUpsPool [i].SetActive (false);
		
		}
	}

}
