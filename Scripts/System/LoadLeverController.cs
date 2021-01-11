using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLeverController : MonoBehaviour
{
    [SerializeField] private string levelName = "SplashScreen";
    [SerializeField] private int timeToWait = 5;
    [SerializeField] private bool sceneLoadingFinished = false;


    /*
    * Загрузка должна проиходить в той сцене, в которой находится объект с текстом.
     * До этого должна загрузиться загрузочная сцена. 
     * Обновить курутину загрузкой сцены с текстом, после которой осуществляется загрузка следующей сцены.
     */

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
        AsyncOperation sceneLoadingOperation = SceneManager.LoadSceneAsync(levelName);
        DontDestroyOnLoad(this.gameObject);
        sceneLoadingFinished = sceneLoadingOperation.isDone;
        while (!sceneLoadingFinished)
        {
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
