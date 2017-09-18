using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodPool : MonoBehaviour {
[SerializeField]
	private GameObject prefBlood;

	private GameObject[] bloodParticlePool = new GameObject[5];

	private int currentBloodParticle;

	public void ActivateBloodParticlesPool (Transform transEnemy)
	{
		if(bloodParticlePool[0]==null)
			CreatBloodPaticlesPool ();

		if (currentBloodParticle >= bloodParticlePool.Length) currentBloodParticle = 0;


		bloodParticlePool [currentBloodParticle].transform.position = transEnemy.position;
		bloodParticlePool [currentBloodParticle].SetActive (true);
		bloodParticlePool [currentBloodParticle].GetComponent<ParticleSystem>().Play();
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
