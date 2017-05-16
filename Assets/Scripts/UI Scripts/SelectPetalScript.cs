using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPetalScript : MonoBehaviour {

	[SerializeField]
	private int petal;

	public void SetThisPetal ()
	{
		GameManager.Instance.ActualPetal = petal;
		Debug.Log ("sehizo" + petal);
	}

}
