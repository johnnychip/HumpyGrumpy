using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spider : Enemy {
	public Vector3[] spawnPoints;

	private bool keyFollow;

	// Use this for initialization
	void Awake ()
	{
		life = 5;
		currentLife = life;	
	}

	void Start () {
		
		speed = 0.15f;
		valuePoints = 30;
		keyFollow = false;
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
	}

	void Update ()
	{
		if(target != null && Time.timeScale > 0 && keyFollow)
			FollowPlayer ();
	}

	void OnEnable ()
	{

		currentLife = life;
		MoveFriend ();

	}

	void MoveFriend ()
	{ 
		
		int tempRandom = Random.Range (0, spawnPoints.Length);

		transform.position = spawnPoints [tempRandom];

		Vector3 direccionMira = Vector3.down * 9f;

		transform.DOMove (direccionMira, 1f).SetRelative ().SetLoops(2,LoopType.Yoyo).OnComplete (MoveFriend);
	}
	
}
