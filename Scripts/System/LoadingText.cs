using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingText : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] TextMeshProUGUI loadingTextObject = null;
    [SerializeField] string loadingText = "";
    [SerializeField] float textUpdateTime = 0.3f;
    [SerializeField] private protected int dotsMaxAmount = 3;

    
    [Header("Sceme Status")]
    [SerializeField] bool isLoaded = false;
    [SerializeField] LoadLeverController leverController = null;

    private void Start()
    {
        StartCoroutine(LoadingTextUpdate());
        leverController = FindObjectOfType<LoadLeverController>();
    }

    private void Update()
    {
        if (leverController)
        {
            isLoaded = leverController.GetLoadLevelStatus();
        }
    }

    private IEnumerator LoadingTextUpdate()
    {
        int i = 0;
        string outputText = loadingText;
        loadingTextObject.text = outputText;
        while (!isLoaded)
        {
            if (i < dotsMaxAmount)
            {
                i++;
                outputText = outputText + ".";
            }
            else if (i >= 3)
            {
                i = 0;
                outputText = loadingText;
            }

            loadingTextObject.text = outputText;

            yield return new WaitForSeconds(textUpdateTime);
        }

        StopCoroutine(LoadingTextUpdate());
    }

    /*
     * Загрузка должна проиходить в той сцене, в которой находится объект с текстом.
     * До этого должна загрузиться загрузочная сцена. 
     */


}
