using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

	[SerializeField]
	private LifeManager myLifeManager;

	[SerializeField]
	private int lifeCost;

	[SerializeField]
	private int petalsCost;

	[SerializeField]
	private Text petalLevel;

	[SerializeField]
	private Text petalLevelCost;

	[SerializeField]
	private Text healthLevel;

	[SerializeField]
	private Text healthLevelCost;

	[SerializeField]
	private Flower myFlower;

	[SerializeField]
	private Text realHealth;

	[SerializeField]
	private Text realScore;

	private int petalsLevel;

	void Start ()
	{

		petalsLevel = 1;

	}

	void OnEnable()
	{
		petalLevel.text = "PETALS  LEVEL  " + petalsLevel;	
		petalLevelCost.text = "" + petalsCost;

		healthLevel.text = "HEALTH          " + myLifeManager.Life;
		healthLevelCost.text = "" + lifeCost;
	}

	public void BuyLife ()
	{
		if (GameManager.Instance.Score >= lifeCost) {
			GameManager.Instance.PayScorePoints (lifeCost);
			myLifeManager.IncreasLife ();
			healthLevel.text = "HEALTH          " + myLifeManager.Life;
			realHealth.text = "HEALTH  " + myLifeManager.Life;
			realScore.text = GameManager.Instance.Score+ "  SCORE";

		}
	}

	public void BuyPetalsLevel()
	{
		if (GameManager.Instance.Score >= petalsCost) 
		{
			GameManager.Instance.PayScorePoints (petalsCost);
			myFlower.LevelUpPetals ();
			petalsCost *= 2;
			petalsLevel++;
			petalLevel.text = "PETALS  LEVEL  " + petalsLevel;	
			petalLevelCost.text = "" + petalsCost;
		}
	}



}
