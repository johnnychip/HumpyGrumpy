using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FastBee : Enemy {

	public Vector3[] spawnPoints;

	private int serch;

	private bool keyFollow;

	// Use this for initialization
	void Awake ()
	{
		life = 1;
		currentLife = life;	
	}

	void Start () {
		
		speed = 0.1f;
		valuePoints = 30;
		keyFollow = false;
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
	}

	public override void LevelUpSpeed ()
	{
		if(speed<maxSpeed)
		{
			speed += 0.005f;
		}

	}

	void Update ()
	{
		if(target != null && Time.timeScale > 0 && keyFollow)
			FollowPlayer ();
	}

	void OnEnable ()
	{

		currentLife = life;
		serch = 2;
		ChangeLook ();
		MoveFriend ();

	}

	void MoveFriend ()
	{ 
		if (target == null)
			return;
		int tempRandom = Random.Range (0, spawnPoints.Length);

		transform.position = spawnPoints [tempRandom];

		ChangeLook ();

		if (serch > 0) 
		{

			Vector3 direccionMira = ((target.position - transform.position).normalized) * 4f;

			transform.DOMove (direccionMira, 1f).SetRelative ().SetLoops(2,LoopType.Yoyo).OnComplete (MoveFriend);

			serch--;

		} else 
		{
			ChangeLook ();

			keyFollow = true;	
		}
		


	}
	

}
