using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPool : MonoBehaviour {

	[SerializeField]
	private GameObject prefMoneyBag;

	[SerializeField]
	private MoneyManager myMoneyManager;

	private GameObject[] moneyBagPool = new GameObject[10];

	private int currentBag;

	void Awake () {
		CreatMoneyBagPool ();
	}

	public void ActivateMoneyBag (Transform transEnemy)
	{
		if (currentBag >= moneyBagPool.Length) currentBag = 0;

		moneyBagPool [currentBag].transform.position = transEnemy.position;
		moneyBagPool [currentBag].SetActive (true);
		currentBag++;
	}

	void CreatMoneyBagPool ()
	{
		for (int i = 0; i < moneyBagPool.Length; i++)
		{
			moneyBagPool [i] = Instantiate (prefMoneyBag);
			moneyBagPool [i].GetComponent<MoneyBag> ().OnTouch += myMoneyManager.UpdateMoney;
			moneyBagPool [i].SetActive (false);
		
		}
	}
}
