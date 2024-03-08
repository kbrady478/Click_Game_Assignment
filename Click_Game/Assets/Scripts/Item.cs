using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class Item : MonoBehaviour
{
    public string itemName = "Name me?";
    public int numberOwned = 0;
    public int baseCost = 10;
    public int purchaseCost;
    public TMP_Text costText, nameText, numberText;
    public Resource_Tracker myResources;
    public float autoClickIncrease = 0.1f;

    private void Start()
    {
        SetItemUI();
    }

    public void SetItemUI()
    {
        purchaseCost = Mathf.CeilToInt(baseCost * Mathf.Pow(1.15f, numberOwned));
        gameObject.name = itemName;
        costText.text = purchaseCost.ToString();
        nameText.text = itemName;
        numberText.text = numberOwned.ToString();
    }

    public void PurchaseItem()
    {
        if (myResources.CheckResources(purchaseCost))
        {
            myResources.RemoveResources(purchaseCost);
            myResources.autoClicks += autoClickIncrease;
            numberOwned++;
            SetItemUI();
        }
    }

}