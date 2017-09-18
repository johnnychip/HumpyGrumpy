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

            life -= 10;

            audioTouch.Play();

            myUI.DeacreaseHealth();

            other.gameObject.SetActive(false);

            myFlower.ChangePetal();

            if (life <= 0)
                Die();
        }
    }

    #endregion

	public void IncreasLife ()
	{
        if (life < 100)
            life += 10;
	}

    private void Die()
    {
        myUI.GameOverUi();

        gameObject.SetActive(false);

        StatisticsManager.Instance.ShowStatistics();
    }

}
