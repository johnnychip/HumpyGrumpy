using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsOnOff : MonoBehaviour {

	[SerializeField]
	private GameObject[] objectsOn;

	[SerializeField]
	private GameObject[] objectsOff;

	public void TurnOnTunrOff()
	{
		for (int i = 0; i < objectsOff.Length; i++) 
		{
			objectsOff [i].SetActive (false);
		}

		for (int i = 0; i < objectsOn.Length; i++) 
		{
			objectsOn [i].SetActive (true);
		}
	}

}
