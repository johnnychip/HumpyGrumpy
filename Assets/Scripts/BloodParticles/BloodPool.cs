using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodPool : MonoBehaviour {
[SerializeField]
	private GameObject prefBlood;

	[SerializeField]
	private Flower myFlower;

	private GameObject[] bloodParticlePool = new GameObject[5];

	private int currentBloodParticle;

	void Awake () 
	{
		CreatBloodPaticlesPool ();
	}

	public void ActivateBloodParticlesPool (Transform transEnemy)
	{
		if (currentBloodParticle >= bloodParticlePool.Length) currentBloodParticle = 0;

		bloodParticlePool [currentBloodParticle].transform.position = transEnemy.position;
		bloodParticlePool [currentBloodParticle].SetActive (true);
		currentBloodParticle++;
		
	}

	void CreatBloodPaticlesPool ()
	{
		for (int i = 0; i < bloodParticlePool.Length; i++)
		{

			bloodParticlePool [i] = Instantiate (prefBlood);
			bloodParticlePool [i].SetActive (false);
		
		}
	}

}
