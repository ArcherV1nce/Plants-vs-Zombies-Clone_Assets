using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefenderButton : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private Color activeColor = new Color(255, 255, 255, 255);
    [SerializeField] private Color passiveColor = new Color(160, 160, 160, 255);
    [SerializeField] private Defender defenderPrefab = null;
    [SerializeField] private TextMeshPro priceTextUI = null;

    [Header("Debug")]
    [SerializeField] private SpriteRenderer buttonRenderer;
    [SerializeField] private DefendersSpawnArea spawner;
    [SerializeField] private List<DefenderButton> defenderButtons;
    [SerializeField] private Color buttonColor = new Color(255, 255, 255, 255);
    [SerializeField] private bool buttonActive = false;


    private void Awake()
    {
        buttonRenderer = gameObject.GetComponent<SpriteRenderer>();
        
        if(!buttonRenderer)
        {
            gameObject.AddComponent<SpriteRenderer>();
        }
        
        if (!buttonActive)
        {
            buttonRenderer.color = passiveColor;
            buttonColor = passiveColor;
        }
        
        defenderButtons = new List<DefenderButton>();
        DefenderButton[] db = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton defenderButton in db)
        {
            defenderButtons.Add(defenderButton);
        }

        spawner = FindObjectOfType<DefendersSpawnArea>();
    }

    #region Button Methods
    private void OnMouseOver()
    {
            buttonRenderer.color = activeColor;
    }

    private void OnMouseDown()
    {
        foreach (DefenderButton button in defenderButtons)
        {
            button.SetButtonColorPassive();
        }
        SetButtonColorActive();
        spawner.SetSelectedDefender(defenderPrefab);
    }

    private void OnMouseExit()
    {
        buttonRenderer.color = buttonColor;
    }

    public void SetButtonColor(Color newColor)
    {
        buttonColor = newColor;
        buttonRenderer.color = buttonColor;
    }

    public void SetButtonColorPassive()
    {
        buttonColor = passiveColor;
        buttonRenderer.color = buttonColor;
        if (priceTextUI) 
        { 
            priceTextUI.enabled = false;
        }
    }
    private void SetButtonColorActive()
    {
        buttonColor = activeColor;
        buttonRenderer.color = buttonColor;
        if (priceTextUI)
        {
            priceTextUI.enabled = true;
            priceTextUI.text = defenderPrefab.GetDefenderPrice().ToString();
        }
    }
    #endregion
}
