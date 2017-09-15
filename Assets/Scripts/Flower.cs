﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour {



	private GameObject[] bulletPref = new GameObject[6];

	private GameObject bulletPrefActual;

	[SerializeField]
	private GameObject[] allPetalsPrefabs;

	[SerializeField]
	private Transform[] firePoints;

	[SerializeField]
	private Animator animFlower;

	[SerializeField]
	private Transform petalsParent;

	[SerializeField]
	private AudioSource audioLanzamiento;

	[SerializeField]
	private PlayerData data;

	private Bullet[] myBulletScript = new Bullet[6];

	private int currentBullet;

	private List<Bullet[]> listBulletsTypeInScene = new List<Bullet[]>();
	// Use this for initialization
	void Awake()
	{
		CreatPetals (allPetalsPrefabs[0]);
		CreatPetals (allPetalsPrefabs[1]);
		CreatPetals (allPetalsPrefabs[2]);
		CreatPetals (allPetalsPrefabs[3]);
		myBulletScript = listBulletsTypeInScene[0];
		foreach(Bullet temp in myBulletScript)
		{
			temp.gameObject.SetActive(true);
		}
	}

	void Start () 
	{
		


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShootBullet(Vector3 direction, Vector3 target)
	{
		animFlower.SetTrigger("Shoot");
		for (int i = 0; i < myBulletScript.Length; i++) {
			if (myBulletScript [i].IsReady) {
				
				myBulletScript [i].AddMove (direction, target);
				return;
			}
		}
	

	}

	public void GrowPetals()
	{
		for (int i = 0; i < myBulletScript.Length; i++) 
		{
			if (myBulletScript[i].gameObject.activeSelf) {
				myBulletScript[i].GrowProces();
			} else {
				
				myBulletScript [i].transform.rotation = firePoints [i].rotation;
				myBulletScript [i].transform.position = firePoints [i].position;
				myBulletScript [i].gameObject.SetActive (true);
			}
		}
	}

	public void ChangePetal(int nextPetal)
	{
		
		foreach(Bullet temp in myBulletScript)
		{
			temp.gameObject.SetActive(false);
		}

		myBulletScript = listBulletsTypeInScene[nextPetal];

		foreach(Bullet temp in myBulletScript)
		{
			temp.gameObject.SetActive(true);
		}
	}

	void CreatPetals(GameObject petalPref)
	{

		Bullet[] tempBulletScript = new Bullet[6];
		for(int i = 0; i < tempBulletScript.Length; i++)
		{
			GameObject tempObject= Instantiate (petalPref,petalsParent);
			tempObject.transform.position = firePoints [i].position;
			tempObject.transform.rotation = firePoints [i].rotation;
			tempBulletScript[i] = tempObject.GetComponent<Bullet> ();
			tempObject.gameObject.SetActive(false);
		}

		listBulletsTypeInScene.Add(tempBulletScript);
	}

	/*void CreatPetals(){
		for(int i = 0; i < bulletPref.Length; i++)
		{
			bulletPref [i] = Instantiate (bulletPrefActual,petalsParent);
			bulletPref [i].transform.position = firePoints [i].position;
			bulletPref [i].transform.rotation = firePoints [i].rotation;
		}
		GetBulletScripts ();
	}*/

	void LevelUpPetals (int levelTo)
	{
		foreach (Bullet bulletPetal in myBulletScript) 
		{
			bulletPetal.LevelUp (levelTo);
		}
	}
}
