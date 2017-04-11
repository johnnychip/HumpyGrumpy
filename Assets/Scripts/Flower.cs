using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour {

	[SerializeField]
	private GameObject[] bulletPref;

	[SerializeField]
	private Transform[] firePoints;

	private Bullet[] myBulletS;

	private int currentBullet;
	// Use this for initialization
	void Start () {
		GetBulletScripts ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShootBullet(Vector3 direction, Vector3 target)
	{
		
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
				bulletPref [i].transform.position = firePoints [i].position;
				bulletPref [i].transform.rotation = firePoints [i].rotation;
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
}
