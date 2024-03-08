using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resource_Tracker : MonoBehaviour
{
    public int resourcesAvailable;
    public float autoClicks;
    private float autoClickPool;
    public TMP_Text resourceCounter, clickCounter;

    // Add resources to the available pool
    public void AddResources(int AmountToAdd)
    {
        resourcesAvailable += AmountToAdd;
    }

    // Remove resources from the available pool
    public void RemoveResources(int AmountToRemove)
    {
        resourcesAvailable -= AmountToRemove;
    }

    // Check if we meet the resources requested
    public bool CheckResources(int CheckValue)
    {
        if (CheckValue <= resourcesAvailable)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Update()
    {
        // Add autoClicks  adjusted for framerate
        autoClickPool += autoClicks * Time.deltaTime;

        //check if the autoClicks have created a new resource (>1)
        if (autoClickPool > 1f)
        {
            // store the part of the fractional component of the autoclickPool
            var franctionalRemainder = autoClickPool % 1;

            // add the integer amount of autoclicks by removing the fractional component
            AddResources((int) (autoClickPool - franctionalRemainder));

            // set the autoclick pool to be the fractional remainder
            autoClickPool = franctionalRemainder;
        }

        // Update the UI text
        resourceCounter.text = "Knowledge Gathered: " + resourcesAvailable;
        clickCounter.text = "Passive Accumulation: " + (Mathf.Round(autoClicks * 10)/10).ToString();
    }
}