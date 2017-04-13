using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysGenerator : MonoBehaviour {

	[SerializeField]
	private GameObject enemyPrefab;

	[SerializeField]
	private Transform[] spawnPoints;

	[SerializeField]
	private float timeToSpawn;

	[SerializeField]
	private Transform playerTransform;

	private int currentEnemy;

	private GameObject[] enemy1Pool = new GameObject[20];

	private float elapsedTime;

	// Use this for initialization
	void Start () {
		CreateEnemies1Pool ();
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		if (elapsedTime > timeToSpawn) 
		{
			elapsedTime = 0;

			if (currentEnemy >= enemy1Pool.Length) currentEnemy = 0;

			enemy1Pool [currentEnemy].transform.position = spawnPoints [Random.Range (0, spawnPoints.Length)].position;
			enemy1Pool [currentEnemy].SetActive (true);
			currentEnemy++;

		}
	}

	void CreateEnemies1Pool ()
	{
		for (int i = 0; i < enemy1Pool.Length; i++)
		{
			enemy1Pool [i] = Instantiate (enemyPrefab);
			enemy1Pool [i].SetActive (false);
			enemy1Pool [i].GetComponent<Enemy> ().SetTarget (playerTransform);
		}
	}

}
