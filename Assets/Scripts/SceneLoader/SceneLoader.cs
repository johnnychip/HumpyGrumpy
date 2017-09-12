using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Facade class that manage the load scene events of the game.
/// </summary>
public class SceneLoader : MonoBehaviour {

    #region Properties

    private int sceneToLoad;
    private int sceneToLoadTemp;

    /// <summary>
    /// Property that allows you know the current scene index.
    /// </summary>
    [HideInInspector]
    public int actualScene
    {
        get; private set;
    }
    /// <summary>
    /// Property that allows you know the progress of the actual scene loading.
    /// </summary>
    [HideInInspector]
    public float loadProgress
    {
        get; private set;
    }
    /// <summary>
    /// Property that allows you know if the actual scene loading has completed.
    /// </summary>
    [HideInInspector]
    public bool isDone
    {
        get; private set;
    }
    
    /// <summary>
    /// Static property that performs like singleton.
    /// </summary>
    public static SceneLoader Instance
    {
        get; private set;
    }

    #endregion

    #region Unity functions

    private void Awake()
    {
        if (Instance != null)
            DestroyImmediate(gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    #endregion

    #region Class functions

    /// <summary>
    /// Function that loads a specific scene.
    /// </summary>
    /// <param name="sceneToLoad">Used to point the scene index at the build settings.</param>
    public void LoadScene(int sceneToLoad)
    {
        if (sceneToLoad >= 0 && sceneToLoad < SceneManager.sceneCountInBuildSettings)
        {
            this.sceneToLoad = sceneToLoad;
        }
        else
        {
            Debug.LogError("This scene doesn't exist.");
            return;
        }

        StartCoroutine(LoadScene());
    }

    /// <summary>
    /// Function that loads the next scene in the build settings.
    /// </summary>
    /// <remarks>
    /// If you are at the top scene in build settings, this function will going to load the first scene in the build settings.
    /// </remarks>
    public void LoadNextScene()
    {
        if (!SceneChecker())
            return;

        switch (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            case true:
                sceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
                break;

            case false:
                LoadFirstOne();
                return;
        }

        StartCoroutine(LoadScene());
    }

    /// <summary>
    /// Function that loads the previous scene in the build settings.
    /// </summary>
    /// <remarks>
    /// If you are at the bottom scene in build settings, this function will going to load the last scene in the build settings.
    /// </remarks>
    public void LoadPreviousScene()
    {
        if (!SceneChecker())
            return;

        switch (SceneManager.GetActiveScene().buildIndex > 0)
        {
            case true:
                sceneToLoad = SceneManager.GetActiveScene().buildIndex - 1; ;
                break;

            case false:
                LoadLastOne();
                return;
        }

        StartCoroutine(LoadScene());
    }

    /// <summary>
    /// Function that loads the first scene in the build settings.
    /// </summary>
    public void LoadFirstScene()
    {
        if (!SceneChecker())
            return;

        LoadFirstOne();
    }

    /// <summary>
    /// Function that loads the last scene in the build settings.
    /// </summary>
    public void LoadLastScene()
    {
        if (!SceneChecker())
            return;

        LoadLastOne();
    }

    /// <summary>
    /// Function that reloads the current scene.
    /// </summary>
    public void ReloadScene()
    {
        sceneToLoad = SceneManager.GetActiveScene().buildIndex;

        StartCoroutine(LoadScene());
    }

    private void LoadFirstOne()
    {
        sceneToLoad = 0;

        StartCoroutine(LoadScene());
    }

    private void LoadLastOne()
    {
        sceneToLoad = SceneManager.sceneCountInBuildSettings - 1;

        StartCoroutine(LoadScene());
    }

    private bool SceneChecker()
    {
        switch (SceneManager.sceneCountInBuildSettings)
        {
            case 0:
                CaseNoScenes();
                return false;

            case 1:
                CaseOneScene();
                return false;

            default:
                return true;
        }
    }

    private void CaseNoScenes()
    {
        Debug.LogError("There's not scenes in build settings.");
    }

    private void CaseOneScene()
    {
        Debug.LogWarning("There's only one scene in build settings.");

        ReloadScene();
    }

    #endregion

    #region Coroutines

    private IEnumerator LoadScene()
    {
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(sceneToLoad);

        isDone = false;

        while (!loadScene.isDone)
        {
            loadProgress = loadScene.progress / 0.9f;

            yield return null;
        }

        isDone = true;

        actualScene = SceneManager.GetActiveScene().buildIndex;
    }

    #endregion
}
