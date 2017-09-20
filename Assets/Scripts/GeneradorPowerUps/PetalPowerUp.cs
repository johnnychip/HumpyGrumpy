using UnityEngine;
using System;


public class PetalPowerUp : PowerUp {

    #region Properties

    public event Action OnTouch;

    public Flower myFlower;

    public int petal;

    #endregion

    #region Unity Functions

    void OnMouseDown()
    {
        myFlower.ChangePetal(petal);
        gameObject.SetActive(false);
    }

    void Update ()
    {
        ClockDeactivation();
    }

    #endregion
}
