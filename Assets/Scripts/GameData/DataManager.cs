using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {

	[SerializeField]
	private PlayerData data;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey("money")&&data.money==0)
		{
			data.money = PlayerPrefs.GetInt("money");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
