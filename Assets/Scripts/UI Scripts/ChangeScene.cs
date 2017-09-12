using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	[SerializeField]
	private int sceneNumber;

	public void ChangeOtherScene ()
	{
		SceneManager.LoadScene (sceneNumber);
	}

	public void ExitGame ()
	{
		Application.Quit ();

	}


}
