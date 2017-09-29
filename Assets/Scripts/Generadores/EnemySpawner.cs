using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	private List<int> listaEnemigos = new List<int>();

	[SerializeField]
	private Generador[] generadores;

	[SerializeField]
	private float timeToSpawn;

	[SerializeField]
	private GameObject endMenu;

	private float elapsedTime;

	private float elapsedTimeToProgres;

	private float elapsedTimeToProgresLife;

	[SerializeField]
	private float timeToProgresLife;

	[SerializeField]
	private float timeToProgres;

	[SerializeField]
	private int progresionLifeTimes;

	[SerializeField]
	private int progresionSpeedTimes;

	[SerializeField]
	private float timeToProgresSpeed;

	private int progresLifeCounter;

	private int progresSpeedCounter;

	private int spawnersActive;

	private bool isFloweAlive;

	private bool allGeneratorsAreActive;


	// Use this for initialization
	void Start () {
		isFloweAlive = true;
		for (int i = 0; i < generadores.Length; i++)
		listaEnemigos.Add (i);
		spawnersActive++;
		//GameManager.Instance.CheckOnDeath ();

		//GameManager.Instance.OnDeath += ActivateEndLevel;
	}
	
	// Update is called once per frame
	void Update () {
		if(!isFloweAlive)
			return;
		elapsedTime += Time.deltaTime;
		if (elapsedTime >= timeToSpawn) 
		{
			elapsedTime = 0;
			//ChangeTimeToSpawn();
			SpawnEnemy ();

			if(timeToSpawn>=1f)
				timeToSpawn-=0.05f;

		}
		if(spawnersActive<generadores.Length)
		{
			if(elapsedTimeToProgres<timeToProgres)
			{
				elapsedTimeToProgres+=Time.deltaTime;
			}else
			{
				elapsedTimeToProgres = 0;
				spawnersActive++;
				if(spawnersActive>=generadores.Length)
				{
					allGeneratorsAreActive = true;
				}
			}
		}
		if(allGeneratorsAreActive)
		{
			if(progresSpeedCounter<progresionSpeedTimes)
			{
				if(elapsedTimeToProgres<timeToProgresSpeed)
				{
					elapsedTimeToProgres+=Time.deltaTime;
				}else
				{
					elapsedTimeToProgres = 0;
					progresSpeedCounter++;
					LevelUpGeneradoresSpeed(1);
				}
			}

			if(progresLifeCounter<progresionLifeTimes)
			{
				if(elapsedTimeToProgresLife<timeToProgresLife)
				{
					elapsedTimeToProgresLife += Time.deltaTime;
				}else
				{
					elapsedTimeToProgresLife = 0;
					progresLifeCounter++;
					LevelUpGeneradores(1);
				}
			}

		}
	}


	void SpawnEnemy()
	{
		int tempInt = Random.Range(0, spawnersActive);
		generadores[tempInt].ActivateEnemy();
	}

	void ActivateEndLevel ()
	{
		Invoke("ActivateEndMenu",2);
	}

	void ActivateEndMenu()
	{
		endMenu.SetActive (true);
	}

	public void StopSpawning()
	{
		isFloweAlive = false;
	}

	void LevelUpGeneradores (int numero)
	{
		for (int i = 0; i < numero; i++) 
		{
			foreach (Generador gen in generadores) 
			{
				gen.LevelUpPool ();
			}
		}
	}

	void LevelUpGeneradoresSpeed (int numero)
	{
		for (int i = 0; i < numero; i++) 
		{
			foreach (Generador gen in generadores) 
			{
				gen.LevelUpPool ();
			}
		}
	}
}
