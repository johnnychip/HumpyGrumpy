using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPetalScript : MonoBehaviour {

	[SerializeField]
	private int petal;

	[SerializeField]
	private Button[] otherPetals;

	[SerializeField]
	private Color[] colorState;

	[SerializeField]
	private PetalSelectedManager petalSelecMang;

	public void SetThisPetal ()
	{
		GameManager.Instance.ActualPetal = petal;
		petalSelecMang.ChangePetal();
	}

}
