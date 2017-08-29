using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetalSelectedManager : MonoBehaviour {

	[SerializeField]
	private Button[] petals;

	void Start ()
	{
		ChangePetal();
	}

	public void ChangePetal()
	{
		foreach(Button boton in petals)
		{
			boton.interactable = true;
		}

		petals[GameManager.Instance.ActualPetal].interactable = false;
	}

}
