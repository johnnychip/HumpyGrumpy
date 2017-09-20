using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnEnable : MonoBehaviour {

	[SerializeField]
	private AudioSource mySound;

	void OnEnable()
	{
		mySound.Play();
	}
}
