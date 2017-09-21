using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spider : Enemy {
	public Vector3[] spawnPoints;


	[SerializeField]
	private GameObject prefBomb;

	private GameObject myBomb;

	private bool keyFollow;

	// Use this for initialization
	void Awake ()
	{
		if(myBomb==null)
		{
			myBomb = Instantiate(prefBomb);
			myBomb.SetActive(false);
		}
			
		
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

	void PutBomb()
	{


		if(transform.position.y>0)
			return;

		int tempInt = Random.Range(0,10);

		if(tempInt>5)
			return;

		if(myBomb.GetComponent<SpiderBomb>().myLifeManager == null)
			myBomb.GetComponent<SpiderBomb>().myLifeManager = myLifeManager;

		if(!myBomb.activeSelf)
		{
			myBomb.transform.position= transform.position;
			myBomb.SetActive(true);
		}
	}

	public override void TouchBullet(int damage)
	{
		currentLife -= damage;
		myBloodPool.ActivateBloodParticlesPool(transform);
		myOnomatopella.ActivatePowerUpsPool(transform);


		float tempFloat =  Mathf.Sign(transform.position.x - target.position.x);
		


		StatisticsManager.Instance.IncreaseCombo();

		anim.SetBool("isInjured",true);

        if (currentLife <= 0) {
			deadSound.Play ();
			anim.SetTrigger ("Die");
            StatisticsManager.Instance.IncreaseKills();
			transform.DOKill();
            Invoke ("DeactivateEnemy", 0.2f);
		}

	}

	void MoveFriend ()
	{ 
		
		int tempRandom = Random.Range (0, spawnPoints.Length);

		transform.position = spawnPoints [tempRandom];

		Vector3 direccionMira = Vector3.down * 10f;

		transform.DOMove (direccionMira, 1f).SetRelative ().SetLoops(2,LoopType.Yoyo).OnComplete (MoveFriend).OnStepComplete(PutBomb);
	}
	
}
