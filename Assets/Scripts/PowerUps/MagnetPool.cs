using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPool : MonoBehaviour {

[SerializeField]
	private GameObject prefPowerUp;

	[SerializeField]
	private Transform[] spawnPoints;

	private GameObject[] powerUpsPool = new GameObject[5];

	private int currentPowerUp;

	public void ActivateMagnetPool (Transform transEnemy)
	{
		if(powerUpsPool[0]==null)
			CreatMagnetPool ();

		if (currentPowerUp >= powerUpsPool.Length) currentPowerUp = 0;

		int randomInt = Random.Range(0, spawnPoints.Length);

		powerUpsPool [currentPowerUp].transform.position = spawnPoints[randomInt].position;
		powerUpsPool [currentPowerUp].SetActive (true);
		currentPowerUp++;
		
	}

	void CreatMagnetPool ()
	{
		for (int i = 0; i < powerUpsPool.Length; i++)
		{

			powerUpsPool [i] = Instantiate (prefPowerUp);
			powerUpsPool [i].SetActive (false);
		
		}
	}

}
