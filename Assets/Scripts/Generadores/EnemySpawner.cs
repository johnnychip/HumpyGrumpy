using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	private List<int> listaEnemigos = new List<int>();

	private int[] enemigosNivel = new int[3];

	[SerializeField]
	private Generador[] generadores;

	[SerializeField]
	private float timeToSpawn;

	[SerializeField]
	private GameObject endMenu;

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

		GameManager.Instance.EnemiesOfRound = enemiesOfRound;
		Debug.Log ("Enemigos"+GameManager.Instance.EnemiesOfRound);

		GameManager.Instance.OnDeath += ActivateEndLevel;

		CheckActiveEnemies ();

	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		if (elapsedTime >= timeToSpawn) 
		{
			elapsedTime = 0;
			SpawnEnemy ();
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
		GameManager.Instance.OnDeath -= ActivateEndLevel;

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
}
