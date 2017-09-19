using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDeadPowerUp : PowerUp {

	public GameObject yunques;
	
	// Update is called once per frame
 	void Update ()
    {
        ClockDeactivation();
    }

	 void OnMouseDown()
    {
		yunques.SetActive(false);
		yunques.SetActive(true);
		Invoke("KillEmAll",0.2f);
    }

	void KillEmAll()
	{
		GameObject[] allEnemyActives = GameObject.FindGameObjectsWithTag("enemy");

		foreach(GameObject temp in allEnemyActives)
		{
			temp.GetComponent<Enemy>().TouchBullet(8);
		}
        gameObject.SetActive(false);
	}
}
