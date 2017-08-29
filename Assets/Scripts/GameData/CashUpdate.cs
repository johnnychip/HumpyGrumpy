using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashUpdate : MonoBehaviour {

	[SerializeField]
	private Text textoDinero;

	[SerializeField]
	private PlayerData data;

	// Use this for initialization
	void Start () {
		textoDinero.text = "CASH " + data.money;
	}
}
