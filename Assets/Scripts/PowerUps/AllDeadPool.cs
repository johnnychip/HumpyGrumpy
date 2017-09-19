using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDeadPool : MonoBehaviour {
[SerializeField]
	private GameObject prefPowerUp;

	[SerializeField]
	private Transform[] spawnPoints;

	[SerializeField]
	private GameObject yunques;

	private GameObject[] powerUpsPool = new GameObject[5];

	private int currentPowerUp;

	public void ActivateAllDeadPool (Transform transEnemy)
	{
		if(powerUpsPool[0]==null)
			CreatAllDeadPool ();

		if (currentPowerUp >= powerUpsPool.Length) currentPowerUp = 0;

		int randomInt = Random.Range(0, spawnPoints.Length);

		powerUpsPool [currentPowerUp].transform.position = spawnPoints[randomInt].position;
		powerUpsPool [currentPowerUp].SetActive (true);
		currentPowerUp++;
		
	}

	void CreatAllDeadPool ()
	{
		for (int i = 0; i < powerUpsPool.Length; i++)
		{

			powerUpsPool [i] = Instantiate (prefPowerUp);
			powerUpsPool [i].GetComponent<AllDeadPowerUp>().yunques = yunques;
			powerUpsPool [i].SetActive (false);
		
		}
	}
}
