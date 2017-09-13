using UnityEngine;

public class Loading : MonoBehaviour {

    #region Properties

    [SerializeField]
    private GameObject loadingCanvas;

    #endregion    

    #region Unity functions

    private void OnLevelWasLoaded(int level)
    {
        loadingCanvas.SetActive(false);
    }

    #endregion

    #region Class functions

    public void ActiveLoading()
    {
        loadingCanvas.SetActive(true);
    }

    #endregion
}
