using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {

    #region Properties

    [SerializeField]
    private int life;

    [SerializeField]
    private UIManager myUI;

    [SerializeField]
    private AudioSource audioTouch;

    [SerializeField]
    private Flower myFlower;

    [SerializeField]
    private EnemySpawner myEnemySpawner;

    [SerializeField]
    private GameObject destello;

    public int Life
    {
        get
        {
            return life;
        }
    }

    #endregion

    #region Unity Functions

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            GameManager.Instance.NotifyDeath();
            DeacreaseLife();
            other.gameObject.SetActive(false);

            if (life <= 0)
            {
                myEnemySpawner.StopSpawning();
                DeactivateAllEnemies();
                Die();
            }
            
                
        }
    }

    #endregion

	public void IncreasLife ()
	{
        if (life < 100)
            life += 10;
	}

    public void DeacreaseLife()
    {
        destello.SetActive(false);
            
        destello.SetActive(true);

        life -= 10;

        audioTouch.Play();

        myUI.DeacreaseHealth();

        myFlower.ChangePetal();

         if (life <= 0)
            {
                myEnemySpawner.StopSpawning();
                DeactivateAllEnemies();
                Die();
                GameManager.Instance.SetMaxCombo(StatisticsManager.Instance.maxCombo);
                GameManager.Instance.SetMaxKills(StatisticsManager.Instance.kills);
        }
    }

    private void DeactivateAllEnemies()
    {
       GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
       foreach(GameObject temp in enemies)
       {
           temp.SetActive(false);
       }
    }

    private void Die()
    {
        myUI.GameOverUi();

        gameObject.SetActive(false);

        StatisticsManager.Instance.ShowStatistics();
    }

}
