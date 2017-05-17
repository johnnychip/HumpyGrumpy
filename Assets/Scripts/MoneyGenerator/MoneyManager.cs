using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour 
{

	[SerializeField]
	private Text moneyText;

	[SerializeField]
	private PlayerData data;

	void Start ()
	{
		UpdateMoney ();
	}

	public void UpdateMoney()
	{
		moneyText.text = data.money + " CASH";
	}

}
