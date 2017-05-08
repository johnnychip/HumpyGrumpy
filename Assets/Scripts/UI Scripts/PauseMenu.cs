using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	[SerializeField]
	private int mainMenuId;

	[SerializeField]
	private GameObject menuUI;

	public void PauseGame ()
	{
		Time.timeScale = 0f;
		menuUI.SetActive (true);
	}

	public void ContinueGame ()
	{
		Time.timeScale = 1f;
		menuUI.SetActive (false);
	}

	public void GoToMyMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene (mainMenuId);
	}

}
