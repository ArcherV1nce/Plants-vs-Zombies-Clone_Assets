﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendersSpawnArea : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] private Defender defenderPrefab = null;

    private void OnMouseDown()
    {
        //Debug.Log("Mouse was clickedinside of game area.");
        SpawnDefender(GetSquareClick());
    }

    #region Spawn Area Methods
    public void SetSelectedDefender(Defender defenderSelected)
    {
        defenderPrefab = defenderSelected;
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