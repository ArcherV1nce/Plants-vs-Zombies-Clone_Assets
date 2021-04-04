using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int playerHealth = 100;
    [SerializeField] private TextMeshProUGUI healthTextUI = null;
    [SerializeField] private AudioSource musicSource = null;

    // Start is called before the first frame update
    private void Start()
    {
        UpdatePlayerHealthUI();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Attacker>())
        {
            playerHealth -= 20;
            collision.GetComponent<Health>().ReciveDamage(1000);
            UpdatePlayerHealthUI();
        }
    }
    private void UpdatePlayerHealthUI()
    {
        if (healthTextUI != null)
        {
            healthTextUI.text = "Glitch population: " + playerHealth + " ppl";
        }

        //Game over. Going back to main menu.
        if (playerHealth <= 0)
        {
            healthTextUI.rectTransform.localPosition = new Vector3 (0,0,0);
            healthTextUI.rectTransform.sizeDelta = new Vector2 (1200, 150);
            healthTextUI.fontSize = 72;
            healthTextUI.color = new Color32(255, 0, 0, 255);
            transform.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            StartCoroutine(GameOverUI());
            if (musicSource != null) { StartCoroutine(LoveringSound()); }
        }
    }

    private IEnumerator GameOverUI()
    {
        yield return new WaitForSecondsRealtime(1f);
        string loseText = "Your town was doomed because of you...";
        char[] loseTextCharArray = loseText.ToCharArray();
        string tempText = "";
        for (int i = 0; i < loseTextCharArray.Length; i++)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            tempText += loseTextCharArray[i];
            healthTextUI.text = tempText;
            if (tempText == loseText)
            {
                loseTextCharArray = new char[0];
                break;
            }
        }
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadSceneAsync(0);
        StopCoroutine(GameOverUI());
    }
    private IEnumerator LoveringSound()
    {
        float volume = musicSource.volume;
        while (volume > 0)
        {
            volume -= 0.05f;
            musicSource.volume = volume;
            yield return new WaitForSecondsRealtime(0.15f);
        }
    }
}
