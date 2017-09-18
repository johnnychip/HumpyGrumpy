using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthsPool : MonoBehaviour {

	[SerializeField]
	private GameObject prefHearth;

	[SerializeField]
	private UIManager myUiManager;

	[SerializeField]
	private LifeManager myLifeManager;

	[SerializeField]
	private Transform[] spawnPoints;

	private GameObject[] healthPool = new GameObject[5];

	private int currentHearth;

	void Awake () 
	{
		
	}

	public void ActivateHearthsPool (Transform transEnemy)
	{
		if(healthPool[0]==null)
			CreatHearthsPool ();

		if (currentHearth >= healthPool.Length) currentHearth = 0;

		int randomInt = Random.Range(0, spawnPoints.Length);

		healthPool [currentHearth].transform.position = spawnPoints[randomInt].position;
		healthPool [currentHearth].SetActive (true);
		currentHearth++;
	}

	void CreatHearthsPool ()
	{
		for (int i = 0; i < healthPool.Length; i++)
		{
			healthPool [i] = Instantiate (prefHearth);
			healthPool [i].GetComponent<HealthRecuperator> ().OnTouch += myUiManager.IncreaseHealth;
			healthPool [i].GetComponent<HealthRecuperator> ().OnTouch += myLifeManager.IncreasLife;
			healthPool [i].SetActive (false);
		
		}
	}
}
