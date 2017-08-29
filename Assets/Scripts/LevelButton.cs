using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour {

	[SerializeField]
	private int numEnemiesNormal;

	[SerializeField]
	private int numEnemiesDrunk;

	[SerializeField]
	private int numEnemiesFast;

	[SerializeField]
	private int numEnemiesTank;

	[SerializeField]
	private int numEnemiesMariq;

	[SerializeField]
	private int levelEnemies;

	[SerializeField]
	private int levelToLoad;

	[SerializeField]
	private int myLevel;

	public void SetLevel()
	{	
		GameManager.Instance.SaveEnemiesLevel (numEnemiesDrunk, numEnemiesNormal, numEnemiesFast, numEnemiesTank, numEnemiesMariq, levelEnemies);
		SceneManager.LoadScene (levelToLoad);
		
	}

}
