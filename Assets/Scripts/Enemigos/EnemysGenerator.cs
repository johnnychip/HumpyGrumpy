using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemysGenerator : MonoBehaviour {

	[SerializeField]
	private GameObject enemyPrefabDrunk;

	[SerializeField]
	private GameObject enemyPrefabNormal;

	[SerializeField]
	private GameObject enemy2Prefab;

	[SerializeField]
	private GameObject enemy3Prefab;

	[SerializeField]
	private Transform[] spawnPoints;

	[SerializeField]
	private Transform[] spawnPointsDrunk;

	[SerializeField]
	private float timeToSpawn;

	[SerializeField]
	private Transform playerTransform;

	[SerializeField]
	private Text roundText;

	[SerializeField]
	private GameObject endRoundMenu;

	private int enemySeed;

	private int enemy2Seed;

	private int enemy3Seed;

	private int enemyNormalSeed;

	private int round;

	private int enemiesNormalOfRound;

	private int enemies1OfRound;

	private int enemies2OfRound;

	private int enemies3OfRound;

	private int currentEnemyDrunk;

	private int currentEnemyNormal;

	private int currentEnemy2;

	private int currentEnemy3;

	private GameObject[] enemyPoolDrunk = new GameObject[10];

	private GameObject[] enemyPoolNormal = new GameObject[5];

	private GameObject[] enemy2Pool = new GameObject[5];

	private GameObject[] enemy3Pool = new GameObject[5];

	private Enemy[] enemyScriptsDrunk = new Enemy[10];

	private Enemy[] enemyScriptsNormal = new Enemy[5];

	private Enemy[] enemy2Scripts = new Enemy[5];

	private Enemy[] enemy3Scripts = new Enemy[5];

	private float elapsedTime;


	// Use this for initialization
	void Start () {
		

		enemySeed = 5;
		round = 0;
		CreateEnemiesDrunkPool ();
		CreateEnemies2Pool ();
		CreateEnemies3Pool ();

		GameManager.Instance.OnDeath += ActivateEndRoundMenu;
		SetNextRound ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (enemies1OfRound+enemies2OfRound+enemies3OfRound > 0)
			elapsedTime += Time.deltaTime;
		
		if (elapsedTime > timeToSpawn) 
		{
			elapsedTime = 0;
		
			int randomNum = Random.Range (0, 7);

			switch (randomNum)
			{
			 	case 0:
				if (enemies1OfRound > 0)
					ActivateEnemyDrunk ();
				else
					elapsedTime = timeToSpawn;
				break;

			case 1:
				if (enemies2OfRound > 0)
					ActivateEnemy2 ();
				else
					elapsedTime = timeToSpawn;
				break;

				case 2:
				if (enemies1OfRound > 0)
					ActivateEnemyDrunk ();
				else
					elapsedTime = timeToSpawn;
				break;

				case 3:
				if (enemies1OfRound > 0)
					ActivateEnemyDrunk ();
				else
					elapsedTime = timeToSpawn;
				break;

			    case 4:
				if (enemies3OfRound > 0)
					ActivateEnemy3 ();
				else
					elapsedTime = timeToSpawn;
				break;

			    case 5:
				if (enemies3OfRound > 0)
					ActivateEnemy3 ();
				else
					elapsedTime = timeToSpawn;
				break;

			    case 6:
				if (enemies3OfRound > 0)
					ActivateEnemy3 ();
				else
					elapsedTime = timeToSpawn;
				break;
				
				default:
				break;

			}
		}
	}

	void ActivateEnemyDrunk ()
	{
		if (currentEnemyDrunk >= enemyPoolDrunk.Length) currentEnemyDrunk = 0;

		enemyPoolDrunk [currentEnemyDrunk].transform.position = spawnPointsDrunk [Random.Range (0, spawnPointsDrunk.Length)].position;
		enemyPoolDrunk [currentEnemyDrunk].SetActive (true);
		currentEnemyDrunk++;
		enemies1OfRound--;
	}

	void ActivateEnemyNormal ()
	{
		if (currentEnemyNormal >= enemyPoolNormal.Length) currentEnemyNormal = 0;

		enemyPoolNormal [currentEnemyNormal].transform.position = spawnPoints [Random.Range (0, spawnPoints.Length)].position;
		enemyPoolNormal [currentEnemyNormal].SetActive (true);
		currentEnemyDrunk++;
		enemiesNormalOfRound--;
	}

	void ActivateEnemy2 ()
	{
		
		if (currentEnemy2 >= enemy2Pool.Length) currentEnemy2 = 0;

		enemy2Pool [currentEnemy2].transform.position = spawnPoints [Random.Range (0, spawnPoints.Length)].position;
		enemy2Pool [currentEnemy2].SetActive (true);
		currentEnemy2++;
		enemies2OfRound--;
	}

	void ActivateEnemy3 ()
	{

		if (currentEnemy3 >= enemy2Pool.Length) currentEnemy3 = 0;

		enemy3Pool [currentEnemy3].transform.position = spawnPoints [Random.Range (0, spawnPoints.Length)].position;
		enemy3Pool [currentEnemy3].SetActive (true);
		currentEnemy3++;
		enemies3OfRound--;
	}

	void CreateEnemiesDrunkPool ()
	{
		for (int i = 0; i < enemyPoolDrunk.Length; i++)
		{
			enemyPoolDrunk [i] = Instantiate (enemyPrefabDrunk);
			enemyPoolDrunk [i].SetActive (false);
			enemyScriptsDrunk [i] =enemyPoolDrunk [i].GetComponent<Enemy> ();
			enemyScriptsDrunk[i].SetTarget (playerTransform);

		}
	}

	void CreateEnemiesNormalPool ()
	{
		for (int i = 0; i < enemyPoolNormal.Length; i++)
		{
			enemyPoolNormal [i] = Instantiate (enemyPrefabNormal);
			enemyPoolNormal [i].SetActive (false);
			enemyScriptsNormal [i] =enemyPoolNormal [i].GetComponent<Enemy> ();
			enemyScriptsNormal[i].SetTarget (playerTransform);

		}
	}

	void CreateEnemies2Pool ()
	{
		for (int i = 0; i < enemy2Pool.Length; i++)
		{
			enemy2Pool [i] = Instantiate (enemy2Prefab);
			enemy2Pool [i].SetActive (false);
			enemy2Scripts [i] =enemy2Pool [i].GetComponent<Enemy> ();
			enemy2Scripts[i].SetTarget (playerTransform);

		}
	}

	void CreateEnemies3Pool ()
	{
		for (int i = 0; i < enemy3Pool.Length; i++)
		{
			enemy3Pool [i] = Instantiate (enemy3Prefab);
			enemy3Pool [i].SetActive (false);
			enemy3Scripts [i] =enemy3Pool [i].GetComponent<Enemy> ();
			enemy3Scripts[i].SetTarget (playerTransform);

		}
	}

	public void ActivateEndRoundMenu()
	{
		if (!endRoundMenu.activeSelf)
			endRoundMenu.SetActive (true);
		roundText.text = "";
		roundText.CrossFadeAlpha (255f, 0.0001f, false);
		round++;
		Time.timeScale = 0f;
	}

	public void SetNextRound ()
	{

		endRoundMenu.SetActive (false);
		Time.timeScale = 1f;
		enemies1OfRound = enemySeed + 2 * round;

		if (round % 10 == 0) 
		{
			enemy2Seed++;
			LevelUpEnemies ();
		}

		if (round % 5 == 0) {
			enemy3Seed++;
		}

		enemies2OfRound = enemy2Seed;
		enemies3OfRound = enemy3Seed;

		GameManager.Instance.EnemiesOfRound = (enemies1OfRound + enemies2OfRound + enemies3OfRound);

		roundText.text = "Round " + round;
		roundText.gameObject.SetActive (true);
		roundText.CrossFadeAlpha (0f, 1f, true);
	}

	public void LevelUpEnemies ()
	{

		for (int i = 0; i < enemyScriptsDrunk.Length; i++) {

			enemyScriptsDrunk [i].LevelUp ();
		
		}
		for (int i = 0; i < enemy2Scripts.Length; i++) {

			enemy2Scripts [i].LevelUp ();

		}


	}

	public int EnemiesOfRound {
		get {
			return enemies1OfRound;
		}
		set {
			enemies1OfRound = value;
		}
	}

	public int Round {
		get {
			return round;
		}
	}
}
