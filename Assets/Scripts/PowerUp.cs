using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PowerUp: MonoBehaviour {

    #region Properties

    [SerializeField] [Range(0,1)]
    protected float animationPercentage;
    [SerializeField]
    protected float twinkleTime;

    //Hidden
    protected bool isTwinkle;

    //Cached Components
    protected SpriteRenderer spriteRenderer;

    public float timeToDeactivate;

    private bool isEnding;

    private float elapsedTime;

    #endregion

    #region MyRegion

    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    #endregion

    #region Class functions

    public void ClockDeactivation()
    {
        if (elapsedTime < timeToDeactivate)
        {
            elapsedTime += Time.deltaTime;

            /*if(!isEnding && elapsedTime>(timeToDeactivate*0.7))
			{
				DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
				gameObject.GetComponent<SpriteRenderer>().DOFade(0f, 0.2).Loops(5);
				isEnding = true;
			}*/

            if (elapsedTime >= timeToDeactivate * animationPercentage && isTwinkle == false)
            {
                spriteRenderer.DOFade(0, twinkleTime).Loops();

                Debug.Log(spriteRenderer.material.color.a);

                isTwinkle = true;
            }
        }
        else
        {
            elapsedTime = 0;
            isEnding = false;
            gameObject.SetActive(false);
        }
    }

    #endregion
}
