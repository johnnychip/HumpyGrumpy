using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour {

	[SerializeField]
	private int nPetal;

	private string myKey;
	
	private int costPetal;

	[SerializeField]
	private int baseCostPetal;

	[SerializeField]
	private PlayerData data;

	[SerializeField]
	private Text textPetalLevel;

	[SerializeField]
	private Text textMoney;

	[SerializeField]
	private Text textPetalCost;
	// Use this for initialization
	void Start () {
		textPetalLevel.text = "LEVEL " + data.petalsLevel[nPetal];
		costPetal = baseCostPetal*data.petalsLevel[nPetal];
		textPetalCost.text = "" + costPetal;
		myKey = "petal"+nPetal.ToString();
		if(PlayerPrefs.HasKey(myKey))
		{
			data.petalsLevel[nPetal] = PlayerPrefs.GetInt(myKey);
		}
	}

	public void BuyUpgrade ()
	{
		if(data.money>=costPetal)
		{
			data.money -= costPetal;
			data.petalsLevel[nPetal] ++;
			costPetal = baseCostPetal*data.petalsLevel[nPetal];
			UpdateText();
			PlayerPrefs.SetInt(myKey, data.petalsLevel[nPetal]);
		}
	}

	void UpdateText()
	{
		textPetalLevel.text = "LEVEL " + data.petalsLevel[nPetal];
		textMoney.text = "CASH " + data.money;
		textPetalCost.text = "" + costPetal;
	}
}
