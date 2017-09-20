using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorSpider : Generador {

	public override void ActivateEnemy ()
	{
		if(enemyPool[0]==null)
			CreatEnemyPool ();

		if(!enemyPool [currentEnemy].gameObject.activeSelf)
		{
			Debug.Log("ARANA ACTIVADA");
		enemyPool [currentEnemy].transform.position = spawnPoints [Random.Range (0, spawnPoints.Length)].position;
		enemyPool [currentEnemy].SetActive (true);
		}

		
		
	}

	public override void CreatEnemyPool ()
	{
		int i = 0;
		Debug.Log("ARANA CREADA");
		enemyPool [i] = Instantiate (enemyPrefab);
		enemyPool [i].SetActive (false);
		enemyScripts [i] =enemyPool [i].GetComponent<Enemy> ();
		enemyScripts [i].myHearthsPool = myHearthsPool;
		enemyScripts [i].myPetalsPool = myPetalsPool;
		enemyScripts [i].myBloodPool = myBloodPool;
		enemyScripts [i].myAllDeadPool = myAllDeadPool;
		enemyScripts [i].myMagnetPool = myMagnetPool;
		enemyScripts [i].myOnomatopella = myOnomatopella;	
	}
	
}
