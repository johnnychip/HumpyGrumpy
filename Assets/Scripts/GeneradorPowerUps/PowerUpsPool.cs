using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsPool : MonoBehaviour {

    [SerializeField]
    private GameObject powerUpPrefab;

    [SerializeField]
    private Transform[] spawnPoints;

    public Transform playerTransform;

    private int currentEnemy;

    private GameObject[] powerUpPowerUp = new GameObject[10];

    private Enemy[] enemyScripts = new Enemy[10];

    public MoneyPool myMoneyPool;

    public HearthsPool myHearthsPool;

    void Awake()
    {
        CreatePowerUpsPool();
    }

    public void ActivateEnemy()
    {
        if (currentEnemy >= powerUpPowerUp.Length) currentEnemy = 0;

        powerUpPowerUp[currentEnemy].transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        powerUpPowerUp[currentEnemy].SetActive(true);
        currentEnemy++;
    }

    void CreatePowerUpsPool()
    {
        for (int i = 0; i < powerUpPowerUp.Length; i++)
        {
            powerUpPowerUp[i] = Instantiate(powerUpPrefab);
            powerUpPowerUp[i].SetActive(false);
            enemyScripts[i] = powerUpPowerUp[i].GetComponent<Enemy>();
            enemyScripts[i].myHearthsPool = myHearthsPool;
            enemyScripts[i].SetTarget(playerTransform);
        }
    }

    /*
    public void LevelUpPool()
    {
        foreach (Enemy enemyTemp in enemyScripts)
            enemyTemp.LevelUp();
    }
    */
}
