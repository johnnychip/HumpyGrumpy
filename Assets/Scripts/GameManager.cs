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

	private int actualPetal;

	public int Score
	{
		get
		{
			return score;
		}
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
		
			OnDeath();
	}

	public void CheckOnDeath()
	{
		OnDeath = null;
	}
		
}
