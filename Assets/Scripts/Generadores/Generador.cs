﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour 
{

	[SerializeField]
	private GameObject enemyPrefab;

	[SerializeField]
	private Transform[] spawnPoints;

	public Transform playerTransform;

	private int currentEnemy;

	private GameObject[] enemyPool = new GameObject[10];

	private Enemy[] enemyScripts = new Enemy[10];

	public MoneyPool myMoneyPool;

	public HearthsPool myHearthsPool;

	public BloodPool myBloodPool;

	public AllDeadPool myAllDeadPool;

	public PowerUpsPool[] myPetalsPool;

	void Awake ()
	{

		

	}

	public void ActivateEnemy ()
	{
		if(enemyPool[0]==null)
			CreatEnemyPool ();

		if (currentEnemy >= enemyPool.Length) currentEnemy = 0;

		enemyPool [currentEnemy].transform.position = spawnPoints [Random.Range (0, spawnPoints.Length)].position;
		enemyPool [currentEnemy].SetActive (true);
		currentEnemy++;
	}

	void CreatEnemyPool ()
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
