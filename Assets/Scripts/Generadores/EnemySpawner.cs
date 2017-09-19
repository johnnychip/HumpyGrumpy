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

	private bool isFloweAlive;

	// Use this for initialization
	void Start () {
		isFloweAlive = true;
		for (int i = 0; i < generadores.Length; i++)
		listaEnemigos.Add (i);

		GameManager.Instance.CheckOnDeath ();

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
			ChangeTimeToSpawn();
			SpawnEnemy ();
		}
	}

	void ChangeTimeToSpawn()
	{
		float tempFloat = Random.Range(1f, 2f);
		timeToSpawn = tempFloat;
	}

	void SpawnEnemy()
	{
		int tempInt = Random.Range(0, generadores.Length);
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
}
