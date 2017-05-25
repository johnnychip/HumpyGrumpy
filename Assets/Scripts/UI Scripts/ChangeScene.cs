using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	[SerializeField]
	private int sceneNumber;

	[SerializeField]
	private GameObject selectLevel;

	[SerializeField]
	private GameObject mainMenu;

	public void ChangeOtherScene2 ()
	{
		//SceneManager.LoadScene (sceneNumber);
		selectLevel.SetActive(true);
		mainMenu.SetActive (false);
		GameManager.Instance.MenuState = 1;
	}

	public void ChangeOtherScene ()
	{
		SceneManager.LoadScene (sceneNumber);
	}

	public void ExitGame ()
	{
		Application.Quit ();

	}


}
