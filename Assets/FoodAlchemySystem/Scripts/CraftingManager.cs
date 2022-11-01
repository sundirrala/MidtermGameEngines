using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class CraftingManager : MonoBehaviour { 
 
    public Image customCursor;

    [SerializeField]
    private Slot[] craftingSlots;

    [SerializeField]
    private List<Items> itemList;

    [SerializeField]
    private string[] recipes;

    [SerializeField]
    private Items[] recipeResults;

    [SerializeField]
    private Slot resultSlot;

    private Items currentItem;

    public void OnMouseDownItem(Items item)
    {
        if (currentItem == null)
        {
            currentItem = item;
            customCursor.gameObject.SetActive(true);
            customCursor.sprite = currentItem.GetComponent<Image>().sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            customCursor.gameObject.SetActive(false);
            Slot nearestSlot = null;
            float shortestDist = float.MaxValue;

            foreach (Slot slot in craftingSlots)
            {
                float dist = Vector2.Distance(Input.mousePosition, slot.transform.position);

                if (dist < shortestDist)
                {
                    shortestDist = dist;
                    nearestSlot = slot;
                }
            }
            nearestSlot.gameObject.SetActive(true);
            nearestSlot.GetComponent<Image>().sprite = currentItem.GetComponent<Image>().sprite;
            nearestSlot.item = currentItem;
            itemList[nearestSlot.index] = currentItem;
            currentItem = null;


            CheckForCreatedRecipes();
        }

        if(Input.GetMouseButtonDown(0))
        {
            OnClick();
        }
    }

    private void OnClick()
    {
        Debug.Log("Health is now " );
    }

    void CheckForCreatedRecipes()
    {
        resultSlot.gameObject.SetActive(false);
        resultSlot.item = null;

        string currentRecipeString = "";

        foreach (Items item in itemList)
        {
            if (item != null)
            {
                currentRecipeString += item.itemName;
            }
            else
            {
                currentRecipeString += "null";
            }
        }

        for (int i = 0; i < recipes.Length; i++)
        {
            if (recipes[i] == currentRecipeString)
            {
                resultSlot.gameObject.SetActive(true);
                resultSlot.GetComponent<Image>().sprite = recipeResults[i].GetComponent<Image>().sprite;
                resultSlot.item = recipeResults[i];
            }
        }
    }

    public void OnClickSlot(Slot slot)
    {
        slot.item = null;
        itemList[slot.index] = null;
        slot.gameObject.SetActive(false);
        CheckForCreatedRecipes();
    }


}
