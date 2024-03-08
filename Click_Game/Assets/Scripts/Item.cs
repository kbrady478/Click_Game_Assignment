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
    public float autoClickIncrease = 0.1f;
    public GameObject purchased_Decor;
    public TMP_Text costText, nameText, numberText, item_Gain;
    public Resource_Tracker myResources;
    

    private void Start()
    {
        SetItemUI();
    }

    private void SetItemUI()
    {
        purchaseCost = Mathf.CeilToInt(baseCost * Mathf.Pow(1.15f, numberOwned));
        gameObject.name = itemName;
        costText.text = "Price:" + purchaseCost;
        nameText.text = itemName;
        numberText.text = "In Possession: " + numberOwned;
        item_Gain.text = "Passive Influx: " + autoClickIncrease;
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

        if (purchased_Decor.activeInHierarchy == false)
        {
            purchased_Decor.SetActive(true);
        }
        
    }

}