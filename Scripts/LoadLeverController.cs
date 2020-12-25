using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLeverController : MonoBehaviour
{
    [SerializeField] private string levelName;
    [SerializeField] private int timeToWait;
        
    public void LoadLevel()
    {

        if(levelName != null)
        {
            SceneManager.LoadSceneAsync(levelName);
        }

    }

    public void LoadWithDelay()
    {
        StartCoroutine(DelayLoadLevel());
    }

    private IEnumerator DelayLoadLevel()
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadSceneAsync(levelName);
        yield return 0;
    }

}
