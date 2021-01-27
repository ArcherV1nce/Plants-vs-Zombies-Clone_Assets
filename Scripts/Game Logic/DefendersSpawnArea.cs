using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefendersSpawnArea : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private ResourcesController resources;
    [SerializeField] private TextMeshProUGUI starsTextMP = null;

    [Header("Debug")]
    [SerializeField] private Defender defenderPrefab = null;
    [SerializeField] private int defenderCost = 0;

    private void Awake()
    {
        if(!resources)
        {
            resources = FindObjectOfType<ResourcesController>();        
        }
    }

    private void Start()
    {
        resources.ResourcesAddStars(60);
        Debug.Log("Added extra stars.");
        ShowResourceAmountStars();
    }
    private void OnMouseDown()
    {
        //Debug.Log("Mouse was clickedinside of game area.");
        SpendStars(defenderCost);
    }

    private void ShowResourceAmountStars()
    {
        if (starsTextMP != null)
        {
            starsTextMP.text = "Stars: \n" + resources.ResourcesGetStars().ToString();
        }
    }

    public void AddResourceStars(int starsAdd)
    {
        resources.ResourcesAddStars(starsAdd);
        ShowResourceAmountStars();
    }

    public void SpendStars(int starsSpend)
    {
        if (resources.ResourcesSpendStars(starsSpend))
        {
            ShowResourceAmountStars();
            SpawnDefender(GetSquareClick());
        }
        
    }

    #region Spawn Area Methods
    public void SetSelectedDefender(Defender defenderSelected)
    {
        defenderPrefab = defenderSelected;
        defenderCost = defenderSelected.GetDefenderPrice();
    }

    private Vector2 GetSquareClick()
    {
        Vector2 clickPos = new Vector2(
            Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return SnapToGrid(worldPos);
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 defenderPosition)
    {
        var defender = Instantiate(
            defenderPrefab, defenderPosition, Quaternion.identity)
            as Defender;
    }

    #endregion
}
