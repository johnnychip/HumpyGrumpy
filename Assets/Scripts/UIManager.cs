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
	private AudioSource audioEnd;

	[SerializeField]
	private GameObject[] hearths;

	private int currentHearth;

	void Start ()
	{
		UpdateScore ();
		GameManager.Instance.OnKill += UpdateScore;
		currentHearth = 0;
	}

	public void UpdateScore()
	{

		scoreText.text = "Kill " + GameManager.Instance.Kills;

	}

	public void DeacreaseHealth()
	{
		if (currentHearth < hearths.Length) 
		{
			hearths [currentHearth].SetActive (false);
			currentHearth++;
		}

	}

	public void IncreaseHealth()
	{
		if (currentHearth > 0) 
		{
			currentHearth--;
			hearths [currentHearth].SetActive (true);
		}
	}

	public void GameOverUi ()
	{
		scoreText.gameObject.SetActive (false);
		HealthText.gameObject.SetActive (false);

		gameOverScreen.SetActive (true);
		gameOverText.text = "Game Over";
		//finalScoreText.text = myEGenerator.Round + " Round"; 
		audioEnd.Play();
		Invoke ("RestartGame", 2);

	}

	void RestartGame()
	{
		SceneLoader.Instance.LoadPreviousScene();
	}

}
