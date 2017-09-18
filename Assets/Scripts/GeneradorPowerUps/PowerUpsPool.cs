using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsPool : MonoBehaviour {

	[SerializeField]
	private GameObject prefPowerUp;

	[SerializeField]
	private Flower myFlower;

	[SerializeField]
	private Transform[] spawnPoints;

	private GameObject[] powerUpsPool = new GameObject[5];

	private int currentPowerUp;

	void Awake () 
	{
		
	}

	public void ActivatePowerUpsPool (Transform transEnemy)
	{
		if(powerUpsPool[0]==null)
			CreatPowerUpsPool ();

		if (currentPowerUp >= powerUpsPool.Length) currentPowerUp = 0;

		int randomInt = Random.Range(0, spawnPoints.Length);

		powerUpsPool [currentPowerUp].transform.position = spawnPoints[randomInt].position;
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
