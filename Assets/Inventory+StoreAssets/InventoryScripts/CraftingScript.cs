using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class CraftingScript : MonoBehaviour
{
    public List<GameObject> inventory;
   
   

    [SerializeField] TMP_Text combineeText;
    [SerializeField] Button confirmCombine;


    [SerializeField] GameObject inventoryCanvas;
    [SerializeField] GameObject craftingCanvas;
    InventoryScript inventoryScript;


    string selectedItem;



    // Start is called before the first frame update
    void Start()
    {
        inventoryScript = inventoryCanvas.GetComponent<InventoryScript>();
    }
    private void Update()
    {
      
    }

    
    public void CardSelected()
    {
        var button = EventSystem.current.currentSelectedGameObject;
        if (button != null)
        {
            selectedItem = button.name;
            confirmCombine.interactable = true;

        }
    }
  

    public void confrimCombine()
    {
        int indexCombinee2 = selectedItem == "Button1" ? 1 : (selectedItem == "Button2" ? 2 : (selectedItem == "Button3" ? 3 : (selectedItem == "Button4" ? 4 :
          (selectedItem == "Button5" ? 5 : 6))));
        indexCombinee2 = indexCombinee2 - 1;
        string combinee1 = inventory[inventoryScript.indexCombinee].GetComponent<InventoryCardScript>().cardName.text;
        string combinee2 = inventory[indexCombinee2].GetComponent<InventoryCardScript>().cardName.text;

        Debug.Log(combinee1);
        Debug.Log(combinee2);




        if (combinee1 == "Green Herb" && combinee2 == "Red Herb")
        {
            inventoryScript.RemoveItem(inventoryScript.indexCombinee);
            inventoryScript.RemoveItem(indexCombinee2);
            inventoryScript.collectItem("Green + Red Mixture");

        }

        if (combinee2 == "Green Herb" && combinee1 == "Red Herb")
        {
            inventoryScript.RemoveItem(inventoryScript.indexCombinee);
            inventoryScript.RemoveItem(indexCombinee2);
            inventoryScript.collectItem("Green + Red Mixture");

        }
        else if (combinee1 == "Green Herb" && combinee2 == "Green Herb")
        {
           
            inventoryScript.RemoveItem(inventoryScript.indexCombinee);
            inventoryScript.RemoveItem(indexCombinee2);
            inventoryScript. collectItem("Green + Green Mixture");
        }
        else if (combinee1 == "Red Herb" && combinee2 == "Red Herb")
        {
          
            inventoryScript.RemoveItem(inventoryScript.indexCombinee);
            inventoryScript.RemoveItem(indexCombinee2);
            inventoryScript.collectItem("Red + Red Mixture");
        }
        else if (combinee1 == "Normal Gunpowder" && combinee2 == "Normal Gunpowder")
        {
          
            inventoryScript.RemoveItem(inventoryScript.indexCombinee);
            inventoryScript.RemoveItem(indexCombinee2);
            inventoryScript.collectAmmo("Pistol Ammo", 12);
        }
        else if (combinee1 == "Normal Gunpowder" && combinee2 == "High-Grade Gunpowder")
        {
          
            inventoryScript.RemoveItem(inventoryScript.indexCombinee);
            inventoryScript.RemoveItem(indexCombinee2);
            inventoryScript.collectAmmo("Shotgun Ammo", 8);
        }

        else if (combinee2 == "Normal Gunpowder" && combinee1 == "High-Grade Gunpowder")
        {

            inventoryScript.RemoveItem(inventoryScript.indexCombinee);
            inventoryScript.RemoveItem(indexCombinee2);
            inventoryScript.collectAmmo("Shotgun Ammo", 8);
        }
        else if (combinee1 == "High-Grade Gunpowder" && combinee2 == "High-Grade Gunpowder")
        {
           
            inventoryScript.RemoveItem(inventoryScript.indexCombinee);
            inventoryScript.RemoveItem(indexCombinee2);
            inventoryScript.collectAmmo("Rifle Ammo", 30);

        }
        adjustCraftLayout();



    }

    public void cancelCombinee()
    {
        adjustCraftLayout();
    }

    public void adjustCraftLayout()
    {
        craftingCanvas.SetActive(false);
        inventoryCanvas.SetActive(true);


        combineeText.SetText("");


        foreach (GameObject inventoryItem in inventoryScript.inventory)
        {
            inventoryItem.SetActive(true);
        }

    }

    public void DisableButtons()
    {
        confirmCombine.interactable = false;
    }

   
}
