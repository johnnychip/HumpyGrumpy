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

	public event Action OnKill;

	private int score;

	private int kills;

	private int actualPetal;

	public int Kills
	{
		get
		{
			return kills;
		}
	}

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

	public void NotifyHit()
	{
		kills++;

        ComboCounter.Instance.RestartComboCount();

        // ***
        Debug.Log("Notify Hit");
        // ***
    }

    public void NotifyDeath()
	{
        //OnDeath();
        // ***
        Debug.Log("Notify Death");
        // ***
    }

    public void CheckOnDeath()
	{
		OnDeath = null;
	}
		
}
