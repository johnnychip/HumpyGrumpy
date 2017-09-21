using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBomb : MonoBehaviour {

	[SerializeField]
	private float timeToExplode;

	private SpriteRenderer mySpriteRenderer;
	
	private float elapsedTime;

	private Animator anim;

	[SerializeField]
	private int baseLifeBomb;

	private int life;

	private bool isTriggered;

	[SerializeField]
	private AudioSource myExplotion;

	public LifeManager myLifeManager;

	// Use this for initialization
	void Start () 
	{
		life = baseLifeBomb;
		anim = GetComponent<Animator>();
		mySpriteRenderer = GetComponent<SpriteRenderer>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("bullet"))
		{
			other.gameObject.SetActive(false);
			life--;
			if(life<=0)
			{
				RestartDates();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(elapsedTime<timeToExplode)
			elapsedTime += Time.deltaTime;
		else
		{
			if (!isTriggered)
			{
				isTriggered = true;
				mySpriteRenderer.sortingOrder = 100;
				anim.SetBool("isTriggered",true);
				myExplotion.Play();
				Invoke("Explode",0.5f);
			}
		}
	}

	void Explode()
	{
		myLifeManager.DeacreaseLife();
		RestartDates();
	}

	void RestartDates()
	{	
		mySpriteRenderer.sortingOrder = -70;
		life = baseLifeBomb;
		isTriggered = false;
		elapsedTime = 0;
		gameObject.SetActive(false);
	}	
}
