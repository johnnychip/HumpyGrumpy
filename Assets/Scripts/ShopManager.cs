using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

	[SerializeField]
	private PlayerData data;

	[SerializeField]
	private Text textLevel;

	[SerializeField]
	private Text priceText;

	[SerializeField]
	private Text cashText;

	[SerializeField]
	private int petalTipe;

	void Start ()
	{
		textLevel.text = "Level " + data.petalsLevel [petalTipe];
		priceText.text = "" + data.petalsLevel [petalTipe] * 100;
		cashText.text = "CASH " + data.money;
	}

	public void BuyUpgrade ()
	{
		if (data.money >= data.petalsLevel [petalTipe] * 100) 
		{
			data.money -= (data.petalsLevel [petalTipe] * 100);
			cashText.text = "CASH " + data.money;
			GameManager.Instance.LevelUpPetal (petalTipe);
			textLevel.text = "Level " + data.petalsLevel [petalTipe];
			priceText.text = "" + data.petalsLevel [petalTipe] * 100;
		}
	}


}
