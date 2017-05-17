using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	private List<int> listaEnemigos = new List<int>();

	private int[] enemigosNivel = new int[5];

	[SerializeField]
	private Generador[] generadores;

	[SerializeField]
	private float timeToSpawn;

	[SerializeField]
	private GameObject endMenu;

	[SerializeField]
	private int enemieLevel;

	private float elapsedTime;

	private int enemiesOfRound;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < generadores.Length; i++)
		listaEnemigos.Add (i);
		
		for(int i = 0; i<enemigosNivel.Length; i++)
		enemigosNivel [i] = GameManager.Instance.EnemiesCount [i];

		for (int i = 0; i < enemigosNivel.Length; i++)
		enemiesOfRound += enemigosNivel [i];

		enemieLevel = GameManager.Instance.LevelEnemies;

		GameManager.Instance.EnemiesOfRound = enemiesOfRound;

		GameManager.Instance.CheckOnDeath ();

		GameManager.Instance.OnDeath += ActivateEndLevel;

		LevelUpGeneradores (enemieLevel);

		CheckActiveEnemies ();

	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		if (elapsedTime >= timeToSpawn) 
		{
			elapsedTime = 0;
			SpawnEnemy ();
			Invoke ("SpawnEnemy", 1f);
		}
	}

	void SpawnEnemy()
	{
		if (listaEnemigos.Count == 0)
			return;

		int tempRandom = Random.Range (0, listaEnemigos.Count);
		enemigosNivel [listaEnemigos [tempRandom]]--;
		generadores [listaEnemigos [tempRandom]].ActivateEnemy ();
		if (enemigosNivel [listaEnemigos [tempRandom]] <= 0) 
		{
			listaEnemigos.RemoveAt(tempRandom);
		}
	}

	void ActivateEndLevel ()
	{
		endMenu.SetActive (true);
	}
	void CheckActiveEnemies()
	{
		for (int i = 0; i < enemigosNivel.Length; i++) 
		{

			if (enemigosNivel [i] <= 0) {
				listaEnemigos.Remove (i);
			}

		}
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
