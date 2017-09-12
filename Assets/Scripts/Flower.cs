using System.Collections;
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

	private Bullet[] myBulletScript;

	private int currentBullet;
	// Use this for initialization
	void Awake()
	{
		bulletPrefActual = allPetalsPrefabs[0];
		CreatPetals ();
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
		for (int i = 0; i < bulletPref.Length; i++) {
			if (myBulletScript [i].IsReady) {
				
				myBulletScript [i].AddMove (direction, target);
				return;
			}
		}
	

	}

	public void GrowPetals()
	{
		for (int i = 0; i < bulletPref.Length; i++) 
		{
			if (bulletPref [i].activeSelf) {
				myBulletScript[i].GrowProces();
			} else {
				
				bulletPref [i].transform.rotation = firePoints [i].rotation;
				bulletPref [i].transform.position = firePoints [i].position;
				bulletPref [i].SetActive (true);
			}
		}
	}

	void GetBulletScripts ()
	{
		myBulletScript = new Bullet[bulletPref.Length];
		for (int i = 0; i < bulletPref.Length; i++) {
			myBulletScript[i] = bulletPref [i].GetComponent<Bullet> ();
		}
	}


	void CreatPetals(){
		for(int i = 0; i < bulletPref.Length; i++)
		{
			bulletPref [i] = Instantiate (bulletPrefActual,petalsParent);
			bulletPref [i].transform.position = firePoints [i].position;
			bulletPref [i].transform.rotation = firePoints [i].rotation;
		}
		GetBulletScripts ();
	}

	void LevelUpPetals (int levelTo)
	{
		foreach (Bullet bulletPetal in myBulletScript) 
		{
			bulletPetal.LevelUp (levelTo);
		}
	}
}
