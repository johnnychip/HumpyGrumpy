using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour {


	private GameObject[] bulletPref = new GameObject[6];

	[SerializeField]
	private GameObject bulletPrefab;

	[SerializeField]
	private Transform[] firePoints;

	[SerializeField]
	private Animator animFlower;

	[SerializeField]
	private Transform petalsParent;

	private Bullet[] myBulletS;

	private int currentBullet;
	// Use this for initialization
	void Start () 
	{
		CreatPetals ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShootBullet(Vector3 direction, Vector3 target)
	{
		animFlower.SetTrigger("Shoot");
		for (int i = 0; i < bulletPref.Length; i++) {
			if (myBulletS [i].IsReady) {
				myBulletS [i].AddMove (direction, target);
				return;
			}
		}
	

	}

	public void GrowPetals()
	{
		for (int i = 0; i < bulletPref.Length; i++) 
		{
			if (bulletPref [i].activeSelf) {
				myBulletS[i].GrowProces();
			} else {
				
				bulletPref [i].transform.rotation = firePoints [i].rotation;
				bulletPref [i].transform.position = firePoints [i].position;
				bulletPref [i].SetActive (true);
			}
		}
	}

	void GetBulletScripts ()
	{
		myBulletS = new Bullet[bulletPref.Length];
		for (int i = 0; i < bulletPref.Length; i++) {
			myBulletS[i] = bulletPref [i].GetComponent<Bullet> ();
		}
	}

	public void LevelUpPetals ()
	{
		for (int i = 0; i < bulletPref.Length; i++) {
			myBulletS [i].LevelUp ();
		}
	}


	void CreatPetals(){
		for(int i = 0; i < bulletPref.Length; i++)
		{
			bulletPref [i] = Instantiate (bulletPrefab,petalsParent);
			bulletPref [i].transform.position = firePoints [i].position;
			bulletPref [i].transform.rotation = firePoints [i].rotation;
		}
		GetBulletScripts ();
	}
}
