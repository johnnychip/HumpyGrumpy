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

	private int score;

	private int enemiesOfRound;

	private int actualPetal;

	private int[] enemiesCount = new int[4];

	private int levelEnemies;

	private int money;

	public int Score
	{
		get
		{
			return score;
		}
	}



	public int EnemiesOfRound {
		get {
			return enemiesOfRound;
		}
		set {
			enemiesOfRound = value;
		}
	}

	public void SaveMoney(int newMoney)
	{
		money += newMoney; 
	}

	public bool PayMoney(int bill)
	{
		if (money >= bill) {
			money -= bill;
			return true;
		} else {
			return false;
		}
	}

	public void SaveEnemiesLevel(int drunk, int normal, int fast, int tank, int level)
	{
		enemiesCount [0] = normal;
		enemiesCount [1] = drunk;
		enemiesCount [2] = fast;
		enemiesCount [3] = tank;
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

	public void PayScorePoints(int cost)
	{

		score -= cost;

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
