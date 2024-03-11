using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UI;

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
    public Image current_Room, new_Room;

    private void Start()
    {
        SetItemUI();
    }
    
    public void SetItemUI()
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
        current_Room = GetComponent<Image>();
        new_Room = GetComponent<Image>();
        if (myResources.CheckResources(purchaseCost))
        {
            myResources.RemoveResources(purchaseCost);
            myResources.autoClicks += autoClickIncrease;
            numberOwned++;
            current_Room.enabled = false;
            new_Room.enabled = true;
            SetItemUI();
        }

        if (purchased_Decor.activeInHierarchy == false)
        {
            purchased_Decor.SetActive(true);
        }
        
    }

}