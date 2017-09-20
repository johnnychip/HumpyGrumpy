using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Generador : MonoBehaviour 
{

	public GameObject enemyPrefab;

	public MagnetPool myMagnetPool;

	public Transform[] spawnPoints;

	public Transform playerTransform;

	public int currentEnemy;

	public GameObject[] enemyPool = new GameObject[10];

	public Enemy[] enemyScripts = new Enemy[10];

	public MoneyPool myMoneyPool;

	public HearthsPool myHearthsPool;

	public BloodPool myBloodPool;

	public AllDeadPool myAllDeadPool;

	public PowerUpsPool[] myPetalsPool;

	public Onomatopella myOnomatopella;


	public virtual void ActivateEnemy ()
	{
		if(enemyPool[0]==null)
			CreatEnemyPool ();

		if (currentEnemy >= enemyPool.Length) currentEnemy = 0;

		enemyPool [currentEnemy].transform.position = spawnPoints [Random.Range (0, spawnPoints.Length)].position;
		enemyPool [currentEnemy].SetActive (true);
		currentEnemy++;
	}

	public virtual void CreatEnemyPool ()
	{
		for (int i = 0; i < enemyPool.Length; i++)
		{
			enemyPool [i] = Instantiate (enemyPrefab);
			enemyPool [i].SetActive (false);
			enemyScripts [i] =enemyPool [i].GetComponent<Enemy> ();
			enemyScripts [i].myHearthsPool = myHearthsPool;
			enemyScripts [i].myPetalsPool = myPetalsPool;
			enemyScripts [i].myBloodPool = myBloodPool;
			enemyScripts [i].myAllDeadPool = myAllDeadPool;
			enemyScripts [i].myMagnetPool = myMagnetPool;
			enemyScripts [i].myOnomatopella = myOnomatopella;
			enemyScripts[i].SetTarget (playerTransform);

		}
	}

	public void LevelUpPool()
	{

		foreach (Enemy enemyTemp in enemyScripts) 
		{
			enemyTemp.LevelUp ();
		}
			
	}
}
