using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoneyBag : MonoBehaviour {

	public int money;

	public event Action OnTouch;

	void OnMouseDown ()
	{
		GameManager.Instance.SaveMoney (money);
		if (OnTouch != null)
			OnTouch ();
		gameObject.SetActive(false);

	}

}
