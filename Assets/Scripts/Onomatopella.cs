using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onomatopella : MonoBehaviour {

	[SerializeField]
	private GameObject prefPowerUp;

	[SerializeField]
	private Sprite[] onomatoSprites;

	private SpriteRenderer mySpriteRender;

	private GameObject[] powerUpsPool = new GameObject[5];

	private int currentPowerUp;

	void Awake()
	{
		mySpriteRender = GetComponent<SpriteRenderer>();
	}

	public void ActivatePowerUpsPool (Transform transEnemy)
	{
		if(powerUpsPool[0]==null)
			CreatPowerUpsPool ();

		if (currentPowerUp >= powerUpsPool.Length) currentPowerUp = 0;

		SetRandomSprite(powerUpsPool [currentPowerUp].GetComponent<SpriteRenderer>());

		powerUpsPool [currentPowerUp].transform.position = transEnemy.position;
		powerUpsPool [currentPowerUp].SetActive (false);
		powerUpsPool [currentPowerUp].SetActive (true);
		currentPowerUp++;
		
	}

	void CreatPowerUpsPool ()
	{
		for (int i = 0; i < powerUpsPool.Length; i++)
		{

			powerUpsPool [i] = Instantiate (prefPowerUp);
			powerUpsPool [i].SetActive (false);
		
		}
	}

	void SetRandomSprite(SpriteRenderer sRender)
	{
		int tempInt = Random.Range(0,onomatoSprites.Length);
		sRender.sprite = onomatoSprites[tempInt];
	}

}
