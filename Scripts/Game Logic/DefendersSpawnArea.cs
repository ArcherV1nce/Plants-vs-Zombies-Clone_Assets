﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefendersSpawnArea : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private ResourcesController resController;

    [Header("Debug")]
    [SerializeField] private Defender defenderPrefab = null;
    [SerializeField] private int defenderCost = 0;
    [SerializeField] private List<Defender> defenders = new List<Defender>();

    private void Awake()
    {
        if(!resController)
        {
            resController = FindObjectOfType<ResourcesController>();        
        }
    }

    private void Start()
    {
        resController.ResourcesAddStars(40);
        Debug.Log("Added extra stars.");
    }
    private void OnMouseDown()
    {
        //Debug.Log("Mouse was clickedinside of game area.");
        if (CheckSqareAvailability(GetSquareClick()))
        {
            SpendStars(defenderCost);
        }
    }

    public void AddResourceStars(int starsAdd)
    {
        resController.ResourcesAddStars(starsAdd);
    }

    public void SpendStars(int starsSpend)
    {
        if (resController.ResourcesSpendStars(starsSpend))
        {
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
            defender.SetResourcesController(resController);
            defenders.Add(defender);
    }

    private bool CheckSqareAvailability(Vector2 position)
    {
        Vector2 pos;
        bool temp_true = true;
        foreach(Defender d in defenders)
        {
            pos = d.transform.position;
            if (position == pos) { temp_true = false; }
        }
        return temp_true;
    }

    #endregion
}
