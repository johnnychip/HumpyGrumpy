using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour {


	[SerializeField]
	private Text scoreText;

	[SerializeField]
	private Text HealthText;

	[SerializeField]
	private Text gameOverText;

	[SerializeField]
	private GameObject gameOverScreen;

	[SerializeField]
	private Text finalScoreText;

	[SerializeField]
	private EnemysGenerator myEGenerator;

	void Start ()
	{
		UpdateScore ();
		GameManager.Instance.OnDeath += UpdateScore;
	}

	public void UpdateScore()
	{

		scoreText.text = "Score " + GameManager.Instance.Score;

	}

	public void UpdateHealth(int health)
	{

		HealthText.text = "Health " + health;

	}

	public void GameOverUi ()
	{
		scoreText.gameObject.SetActive (false);
		HealthText.gameObject.SetActive (false);

		gameOverScreen.SetActive (true);
		gameOverText.text = "Game Over";
		//finalScoreText.text = myEGenerator.Round + " Round"; 

		Invoke ("RestartGame", 2);

	}

	void RestartGame()
	{

		SceneManager.LoadScene (0);

	}

}
