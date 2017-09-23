using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

    #region Properties

    //UI

    [SerializeField]
    private Text topCombo;
    [SerializeField]
    private Text topKills;

    //Singleton!

    private static GameManager instance;

    public static GameManager Instance
    {

        get
        {
            return instance;
        }

    }

    //Events

    public event Action OnDeath;

    public event Action OnKill;

    //Others

    private int kills;

    private int score;

    private int actualPetal;

    public int maxKills
    {
        get; private set;
    }

    public int maxCombo
    {
        get; private set;
    }

    public int Kills
    {
        get
        {
            return kills;
        }
    }

    public int Score
    {
        get
        {
            return score;
        }
    }

    #endregion

    #region Unity Functions

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        LoadTopKillsAndCombo();

        topKills.text = string.Format("Top Kills . {0}", maxKills);
        topCombo.text = string.Format("Top Combo . {0}", maxCombo);
    }

    #endregion

    #region Class Functions

    public void CheckOnDeath()
    {
        OnDeath = null;
    }

    public void NotifyHit()
    {
        kills++;

        // ***
        Debug.Log("Notify Hit");
        // ***
    }

    public void NotifyDeath()
    {
        //OnDeath();

        StatisticsManager.Instance.RestartCombo();

        // ***
        Debug.Log("Notify Death");
        // ***
    }

    public void SetMaxKills(int _kills)
    {
        if (_kills <= maxKills)
            return;

        maxKills = _kills;

        PlayerPrefs.SetInt("maxKills", maxKills);
        PlayerPrefs.Save();
    }

    public void SetMaxCombo(int _combo)
    {
        if (_combo <= maxCombo)
            return;

        maxCombo = _combo;

        PlayerPrefs.SetInt("maxCombo", maxCombo);
        PlayerPrefs.Save();
    }

    private void LoadTopKillsAndCombo()
    {
        maxKills = PlayerPrefs.GetInt("maxKills");
        maxCombo = PlayerPrefs.GetInt("maxCombo");
    }

    #endregion
}
