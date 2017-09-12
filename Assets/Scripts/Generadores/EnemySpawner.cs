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

	// Use this for initialization
	void Start () {
		for (int i = 0; i < generadores.Length; i++)
		listaEnemigos.Add (i);

		GameManager.Instance.CheckOnDeath ();

		GameManager.Instance.OnDeath += ActivateEndLevel;
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
		generadores[0].ActivateEnemy();
	}

	void ActivateEndLevel ()
	{
		//Invoke("ActivateEndMenu",2);
		ActivateEndMenu();
	}

	void ActivateEndMenu()
	{
		endMenu.SetActive (true);
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
