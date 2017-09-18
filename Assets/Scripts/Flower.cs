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

	[SerializeField]
	private float timeToEndPowerUp;

	private Bullet[] myBulletScript = new Bullet[6];

	private int currentBullet;

	private float elapsedTimeWithPowerUp;

	private bool isPowerUp;

	private List<Bullet[]> listBulletsTypeInScene = new List<Bullet[]>();

	private void Awake()
	{
		CreatPetals (allPetalsPrefabs[0]);
		CreatPetals (allPetalsPrefabs[1]);
		CreatPetals (allPetalsPrefabs[2]);
		CreatPetals (allPetalsPrefabs[3]);
		myBulletScript = listBulletsTypeInScene[0];

        foreach (Bullet temp in myBulletScript)
		{
			temp.gameObject.SetActive(true);
		}
	}

	public void ShootBullet(Vector3 direction, Vector3 target)
	{
		animFlower.SetTrigger("Shoot");

        for (int i = 0; i < myBulletScript.Length; i++)
        {
			if (myBulletScript [i].IsReady)
            {
				myBulletScript [i].AddMove (direction, target);
				return;
			}
		}
	}

	void Update()
	{
		if(isPowerUp)
		{
			if(elapsedTimeWithPowerUp<timeToEndPowerUp)
				elapsedTimeWithPowerUp += Time.deltaTime;
			else
			{
				ChangePetal();
			}
		}
	}

	public void GrowPetals()
	{
		for (int i = 0; i < myBulletScript.Length; i++) 
		{
			if (myBulletScript[i].gameObject.activeSelf)
            {
				myBulletScript[i].GrowProces();
			}
            else
            {	
				myBulletScript [i].transform.rotation = firePoints [i].rotation;
				myBulletScript [i].transform.position = firePoints [i].position;
				myBulletScript [i].gameObject.SetActive (true);
			}
		}
	}

	public void ChangePetal(int nextPetal)
	{	
		isPowerUp = true;
		elapsedTimeWithPowerUp = 0;
		foreach(Bullet temp in myBulletScript)
		{
			temp.gameObject.SetActive(false);
		}

		myBulletScript = listBulletsTypeInScene[nextPetal];

		RestartPetal();

		foreach(Bullet temp in myBulletScript)
		{	
            temp.gameObject.SetActive(true);
		}

		foreach(Bullet temp in myBulletScript)
		{	
			temp.GrowProces(1f);
		}
	}

	public void ChangePetal()
	{	
		
		if(isPowerUp)
		{
			isPowerUp = false;
		}else
		{
			return;
		}

		foreach(Bullet temp in myBulletScript)
		{
			temp.gameObject.SetActive(false);
		}

		myBulletScript = listBulletsTypeInScene[0];

		RestartPetal();

		foreach(Bullet temp in myBulletScript)
		{	
            temp.gameObject.SetActive(true);
		}

		foreach(Bullet temp in myBulletScript)
		{	
			temp.GrowProces(1f);
		}
	}

	

	private void RestartPetal ()
	{
		for (int i = 0; i < myBulletScript.Length; i++) 
		{
		    myBulletScript [i].transform.rotation = firePoints [i].rotation;
		    myBulletScript [i].transform.position = firePoints [i].position;
		}
	}

	private void CreatPetals(GameObject petalPref)
	{
		Bullet[] tempBulletScript = new Bullet[6];

        for (int i = 0; i < tempBulletScript.Length; i++)
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

	private void LevelUpPetals (int levelTo)
	{
		foreach (Bullet bulletPetal in myBulletScript) 
		{
			bulletPetal.LevelUp (levelTo);
		}
	}
}
