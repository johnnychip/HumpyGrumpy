using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticulaSangre : MonoBehaviour {

	[SerializeField]
	private ParticleSystem myParticleSystem;

	[SerializeField]	
	private float timeOfVfx;

	[SerializeField]
	private AnimationCurve fadeInCurve;

	[SerializeField]
	private AnimationCurve fadeOutCurve;

	[SerializeField][Range(0,1)]
	private float percentSatate1,percentSatate2,percentSatate3;

	[SerializeField][Range(0,2)]
	private float Duration;

	[SerializeField]
	private AudioSource mySound;

	[SerializeField]
	private SpriteRenderer mySpriteLight;

	[SerializeField]
	private Color alphaColor;

	private float timeState1, timeState2, timeState3;

	private float elapsedTime;

	private bool isActiveEffect;

	private int stateCounter;

	// Use this for initialization
	void Start ()
	{
		SetValueOfSates();
		alphaColor.a = 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(isActiveEffect)
		{
			elapsedTime += Time.deltaTime;

			switch (stateCounter)
			{
				case 0:
					if(elapsedTime>timeState1)
					{
						elapsedTime=0;
						stateCounter++;
					}
					else
					{
						State1();
					}
				break;

				case 1:
					if(elapsedTime>timeState2)
					{
						elapsedTime=0;
						stateCounter++;
					}
					else
					{
						State2();
					}
				break;

				case 2:
					if(elapsedTime>timeState3)
					{
						elapsedTime=0;
						isActiveEffect = false;
						stateCounter = 0;
					}
					else
					{
						State3();
					}
				break;

			}
		}
	}

	void SetInitialValues ()
	{

		var main = myParticleSystem.main;
		timeOfVfx = main.duration;
		timeOfVfx *= Duration;
		main.simulationSpeed = (1/timeOfVfx);
		mySound.pitch = (1/timeOfVfx);


	}

	public void ActivateEffect()
	{
		SetInitialValues();
		isActiveEffect = true;
		elapsedTime = 0;
		mySound.Play();
		myParticleSystem.Play();
	}

	void SetValueOfSates()
	{
		timeState1 = timeOfVfx * percentSatate1;
		timeState2 = timeOfVfx * percentSatate2;
		timeState3 = timeOfVfx * percentSatate3;
	}

	void State1()
	{
		Debug.Log("State 1");
	}

	void State2()
	{
		Debug.Log("State 2");

		float tempFloat = elapsedTime/timeState2;
		//myLight.intensity = fadeInCurve.Evaluate(tempFloat);
		//alphaColor.a = SetAlpha(fadeInCurve.Evaluate(tempFloat));
		alphaColor.a = fadeInCurve.Evaluate(tempFloat);
		mySpriteLight.color = alphaColor;
		mySound.volume = fadeInCurve.Evaluate(tempFloat);
	}

	void State3()
	{
		Debug.Log("State 3");

		float tempFloat = elapsedTime/timeState3;
		//myLight.intensity = fadeOutCurve.Evaluate(tempFloat);
		//alphaColor.a = SetAlpha(fadeOutCurve.Evaluate(tempFloat));
		alphaColor.a =fadeOutCurve.Evaluate(tempFloat);
		mySpriteLight.color = alphaColor;
		mySound.volume = fadeOutCurve.Evaluate(tempFloat);
	}

	private float SetAlpha(float colorValue)
	{
		float tempColor = (colorValue*255);
		return tempColor;
	}
}
