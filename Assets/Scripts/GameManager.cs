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

	private int[] enemiesCount = new int[3];

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

	public void SaveEnemiesLevel(int drunk, int normal, int fast, int tank)
	{
		enemiesCount [0] = drunk;
		enemiesCount [1] = fast;
		enemiesCount [2] = tank;
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
			OnDeath ();
		}
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
}
