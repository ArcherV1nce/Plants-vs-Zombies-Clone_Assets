using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLeverController : MonoBehaviour
{
    [SerializeField] private string loadingScreenName = "LoadingScene";
    [SerializeField] private string levelName = "SplashScreen";
    [SerializeField] private int timeToWait = 5;
    [SerializeField] private bool sceneLoadingFinished = false;


    /*
    * Загрузка должна проиходить в той сцене, в которой находится объект с текстом.
     * До этого должна загрузиться загрузочная сцена. 
     */

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadLevel()
    {

        if(levelName != null)
        {
            SceneManager.LoadSceneAsync(levelName);
        }

    }

    public void LoadWithDelay()
    {
        if (levelName != null)
        {
            StartCoroutine(DelayLoadLevel());
        }
    }

    private IEnumerator DelayLoadLevel()
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadSceneAsync(levelName);
        yield return 0;
    }

    public void LoadScreenLoadLevel()
    {
        StartCoroutine(LoadScreenOperationProcess());    
    }

    private IEnumerator LoadScreenOperationProcess()
    {
        AsyncOperation tempOp = SceneManager.LoadSceneAsync(loadingScreenName);
        while(SceneManager.GetActiveScene().name != loadingScreenName)
        {
            yield return new WaitForEndOfFrame();
        }
        #region Editor check if Loading Scene is working.
        /*
        if (SceneManager.GetActiveScene().name == loadingScreenName)
        {
            UnityEditor.EditorApplication.isPaused = true;
            yield return new WaitForEndOfFrame();
        }
        */
        #endregion

        AsyncOperation sceneLoadingOperation = SceneManager.LoadSceneAsync(levelName);
        Debug.Log(sceneLoadingOperation.progress);
        while (!sceneLoadingFinished)
        {
            Debug.Log(sceneLoadingOperation.progress);
            sceneLoadingFinished = sceneLoadingOperation.isDone;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForEndOfFrame();
        Destroy(this.gameObject);
        StopCoroutine(LoadScreenOperationProcess());
    }

    public bool GetLoadLevelStatus()
    {
        return sceneLoadingFinished;
    }
}
