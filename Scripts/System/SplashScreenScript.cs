using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenScript : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(WaitForSceneLoad());
    }

    private static IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadSceneAsync("MainMenu");
        yield return 0;
    }

}
