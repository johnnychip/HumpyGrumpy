using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour {

	private static GameManager instance;

	public static GameManager Instance
	{

		get
		{
			return instance;
		}

	}

	public event Action OnDeath;

	public PlayerData data;

	private int score;

	private int enemiesOfRound;

	private int actualPetal;

	private int[] enemiesCount = new int[5];

	private int levelEnemies;

	private int money;

	//private int[] petalsLevel = new int[4]; 

	public int Score
	{
		get
		{
			return score;
		}
	}

	public void SaveMoney(int newMoney)
	{
		data.money += newMoney; 
	}

	public bool PayMoney(int bill)
	{
		if (data.money >= bill) {
			data.money -= bill;
			return true;
		} else {
			return false;
		}
	}

	public void LevelUpPetal(int petalToLevelUp)
	{
		data.petalsLevel [petalToLevelUp]++;
	}

	public int PetalLevel ()
	{
		return data.petalsLevel [actualPetal];
	}


	public int EnemiesOfRound {
		get {
			return enemiesOfRound;
		}
		set {
			enemiesOfRound = value;
		}
	}
		
	public void SaveEnemiesLevel(int drunk, int normal, int fast, int tank, int mariquita, int level)
	{
		enemiesCount [0] = normal;
		enemiesCount [1] = drunk;
		enemiesCount [2] = fast;
		enemiesCount [3] = tank;
		enemiesCount [4] = mariquita;
		levelEnemies = level;
	}

	private void Awake ()
	{
		DontDestroyOnLoad (gameObject);
		if (instance != null)
			Destroy (gameObject);
		else
			instance = this;
	}

	public void NotifyHit(int points)
	{
		score += points;

	}

	public void NotifyDeath()
	{
		enemiesOfRound--;
		if (OnDeath != null && enemiesOfRound <= 0) 
		{
			OnDeath();
		}
	}

	public void CheckOnDeath()
	{
		OnDeath = null;
	}
		
	public int[] EnemiesCount {
		get {
			return enemiesCount;
		}
	}

	public int ActualPetal {
		get {
			return actualPetal;
		}
		set {
			actualPetal = value;
		}
	}

	public int LevelEnemies {
		get {
			return levelEnemies;
		}
	}
}
