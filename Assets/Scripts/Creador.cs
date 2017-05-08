using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creador : MonoBehaviour {

	private List<int> listaPrueba = new List<int> ();

	[SerializeField]
	private int numEnemiesDrunk;

	[SerializeField]
	private int numEnemiesNormal;

	[SerializeField]
	private int numEnemiesTank;

	[SerializeField]
	private int numEnemiesFast;

	public string[] Generadores;

	void Start () {
		listaPrueba.Add (1);

		int tempRandom = Random.Range (0, listaPrueba.Count);

		Debug.Log (Generadores[tempRandom]);
	}

}
