using UnityEngine;

public class ComboCounter : MonoBehaviour {

    #region Properties

    public int combo
    {
        get; private set;
    }

    //Singleton!
    public static ComboCounter Instance
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
        RestartComboCount();
    }

    #endregion

    #region Class Functions

    public void IncreaseComboCount()
    {
        combo++;

        Debug.Log(string.Format("Combo: {0}", combo));
    }

    public void RestartComboCount()
    {
        combo = 0;

        Debug.Log(string.Format("Combo: {0}", combo));
    }

    #endregion
}
