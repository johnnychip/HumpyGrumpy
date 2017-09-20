using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsManager : MonoBehaviour {

    #region Properties

    public float time
    {
        get; private set;
    }

    public int kills
    {
        get; private set;
    }

    public int combo
    {
        get; private set;
    }

    public int maxCombo
    {
        get; private set;
    }

    [Header("UI Text")]

    [SerializeField]
    private Text timeField;
    [SerializeField]
    private Text killField;
    [SerializeField]
    private Text comboField;

    [Space(10f)]

    [SerializeField]
    private Text textKills;
    [SerializeField]
    private Text textCombo;

    //Cached Components
    private float seconds;
    private float minutes;
    private IEnumerator maxComboAnim;

    //Singleton!
    public static StatisticsManager Instance
    {
        get; private set;
    }

    #endregion

    #region Unity Functions

    private void Awake()
    {
        if (Instance != null)
            DestroyImmediate(gameObject);
        else
            Instance = this;
    }

    private void OnLevelWasLoaded(int level)
    {
        RestartStatistics();
    }

    private void Update()
    {
        UpdateTime();
    }

    #endregion

    #region Class Functions

    public void ShowStatistics()
    {        
        killField.text = kills.ToString();
        comboField.text = maxCombo.ToString();
        timeField.text = string.Format("{0}.{1} S", minutes, seconds);
    }

    public void IncreaseKills()
    {
        kills++;
        
        textKills.text = string.Format("{0} ", kills);
        
        Debug.Log(string.Format("Kills: {0}", kills));
    }

    public void IncreaseCombo()
    {
        combo++;

        Debug.Log(string.Format("Combo: {0}", combo));

        CheckCombo(combo);
    }

    public void RestartCombo()
    {
        combo = 0;

        Debug.Log(string.Format("Combo: {0}", combo));
    }

    private void RestartStatistics()
    {
        time = 0;
        kills = 0;
        combo = 0;
    }

    private void CheckCombo(int combo)
    {
        if (combo > maxCombo)
        {
            maxCombo = combo;

            textCombo.text = string.Format("{0} Combo", maxCombo);

            if (maxComboAnim != null)
                StopCoroutine(maxComboAnim);

            maxComboAnim = MaxComboAnimation();

            StartCoroutine(maxComboAnim);
        }
    }

    private void UpdateTime()
    {
        time += Time.deltaTime;

        seconds = (int)time % 60;
        minutes = (int)time / 60;        
    }

    #endregion

    #region Coroutines

    private IEnumerator MaxComboAnimation()
    {
        textCombo.gameObject.SetActive(true);

        yield return new WaitForSeconds(1);

        textCombo.gameObject.SetActive(false);
    }

    #endregion
}
