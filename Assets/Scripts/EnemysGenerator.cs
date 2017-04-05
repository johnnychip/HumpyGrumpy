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

	private float elapsedTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		if (elapsedTime > timeToSpawn) 
		{
			elapsedTime = 0;
			GameObject objTemp = Instantiate (enemyPrefab, spawnPoints [Random.Range (0, spawnPoints.Length)].position, Quaternion.identity);
			objTemp.GetComponent<Enemy> ().SetTarget(playerTransform);
		}
	}
}
