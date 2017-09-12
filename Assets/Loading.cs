using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour {

	public static int sceneToload;
	public bool isLoadingScene = false;

	public void Execute(int _sceneToLoad)
	{
		sceneToload = _sceneToLoad;
		
		SceneLoader.Instance.LoadFirstScene();
	}

	public void Start()
	{
		Debug.Log(isLoadingScene);
		
		if (isLoadingScene)
		{
			SceneLoader.Instance.LoadScene(sceneToload); Debug.Log(sceneToload);
		}
	}
}
