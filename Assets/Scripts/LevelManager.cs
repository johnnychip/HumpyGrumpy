using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	[SerializeField]
	private Button[] levels;

	void Start ()
	{
		for(int i = 0; i <= GameManager.Instance.ActualLevel; i++)
		{
			levels[i].interactable = true;
		}
	}
	
}
