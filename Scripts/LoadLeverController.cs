using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLeverController : MonoBehaviour
{
    [SerializeField] private string levelName;

    public void LoadLevel()
    {

        if(levelName != null)
        {
            SceneManager.LoadSceneAsync(levelName);
        }

    }

}
