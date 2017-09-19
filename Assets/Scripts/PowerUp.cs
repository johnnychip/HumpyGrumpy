using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PowerUp: MonoBehaviour {

	public float timeToDeactivate;

	private float elapsedTime;

	private bool isEnding;

	public void ClockDeactivation()
	{
		if(elapsedTime<timeToDeactivate)
		{
			elapsedTime += Time.deltaTime;
			/*if(!isEnding && elapsedTime>(timeToDeactivate*0.7))
			{
				DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
				gameObject.GetComponent<SpriteRenderer>().DOFade(0f, 0.2).Loops(5);
				isEnding = true;
			}*/
		}
		else
		{
			elapsedTime = 0;
			isEnding = false;
			gameObject.SetActive(false);
		}
	}

}
