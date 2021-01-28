using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourcesController : MonoBehaviour
{
    [SerializeField] private Resources resources = new Resources();
    [SerializeField] private TextMeshProUGUI starsText;

    private void Awake()
    {
        if (!starsText)
        {
            TextMeshProUGUI[] texts = FindObjectsOfType<TextMeshProUGUI>();
            for(int i = 0; i<texts.Length; i++)
            {
                if(texts[i].name == "ResourceStarsText")
                {
                    starsText = texts[i];
                }
            }
        }
    }

    public int ResourcesGetStars()
    {
        int s = resources.stars;
        starsText.text = resources.starsText + resources.stars.ToString();
        return s;
    }

    public bool ResourcesSpendStars(int stars)
    {
        bool rss = resources.SpendStars(stars);
        if(rss) { starsText.text = resources.starsText + resources.stars.ToString(); }
        return rss;
    }

    public void ResourcesAddStars(int stars)
    {
        resources.AddStars(stars);
        starsText.text = resources.starsText + resources.stars.ToString();
    }

}
