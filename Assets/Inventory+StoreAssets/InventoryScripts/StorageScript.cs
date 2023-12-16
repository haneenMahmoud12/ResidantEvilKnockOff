using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class StorageScript : MonoBehaviour


{    // Start is called before the first frame update

    [SerializeField] GameObject shopCanvas;
    ShopController shopController;
    [SerializeField] List<GameObject> inventoryItems;
    [SerializeField] List<GameObject> storageItems;
    [SerializeField] Transform content;
    [SerializeField] GameObject storageSlot;
    [SerializeField] Button switchToInventory;
    [SerializeField] Button switchToStorage;
    int inventorySelectedItem;
    int selectedStorageItem;
    int activeItemsInStorage = 0;






    void Start()
    {

        if (shopCanvas != null)
        {
            shopController = shopCanvas.GetComponent<ShopController>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchToInventory()
    {
       
        int index = selectedStorageItem;

        shopController.inventoryScript.collectAmmo(storageItems[index].transform.Find("Button").GetComponent<StorageCardScript>().cardName.text, Int32.Parse(storageItems[index].transform.Find("Button").GetComponent<StorageCardScript>().quantity.text));
        shopController.inventoryScript.collectItem(storageItems[index].transform.Find("Button").GetComponent<StorageCardScript>().cardName.text);
        AdjustInventory();
        StorageCardScript script = storageItems[index].transform.Find("Button").GetComponent<StorageCardScript>();
        if (script.cardName.text == "Pistol Ammo" || script.cardName.text == "Rifle Ammo" ||
            script.cardName.text == "Shotgun Ammo" || script.cardName.text == "Revolver Ammo")
        {
            storageItems[index].SetActive(false);
            GameObject itemDeactivated = storageItems[index];
            storageItems.RemoveAt(index);
            storageItems.Add(itemDeactivated);
            activeItemsInStorage--;
        }

       else
        {
            script.quantity.text = (Int32.Parse(script.quantity.text) - 1).ToString();
            if (script.quantity.text == "0")
            {
                storageItems[index].SetActive(false);
                GameObject itemDeactivated = storageItems[index];
                storageItems.RemoveAt(index);
                storageItems.Add(itemDeactivated);
                activeItemsInStorage--;
            }
        }


        switchToInventory.interactable = false;



    }

    public void SwitchToStorage()
    {
        Debug.Log("Etzafet");
        GameObject inventory = shopController.inventoryScript.inventory[inventorySelectedItem];

        if (inventory.GetComponent<InventoryCardScript>().cardName.text != shopController.inventoryScript.leonEquippedWeapon &&
            inventory.GetComponent<InventoryCardScript>().cardName.text != shopController.inventoryScript.leonEquippedGrenade)
        {
            bool itemFound = false;

            foreach (GameObject item in storageItems)
            {

                if (item.transform.Find("Button").GetComponent<StorageCardScript>().cardName.text == inventory.GetComponent<InventoryCardScript>().cardName.text && item.activeInHierarchy)
                {
                    item.transform.Find("Button").GetComponent<StorageCardScript>().quantity.SetText((Int32.Parse(item.transform.Find("Button").GetComponent<StorageCardScript>().quantity.text)
                        + Int32.Parse(inventory.GetComponent<InventoryCardScript>().quantity.text)).ToString());
                    itemFound = true;
                    item.transform.Find("Button").GetComponent<StorageCardScript>().Initialize();
                    Debug.Log(item.transform.Find("Button").GetComponent<StorageCardScript>().quantity.text);
                    break;
                }
            }
            if (!itemFound)
            {
                Debug.Log(storageItems.Count);
                GameObject itemToAdd = storageItems[activeItemsInStorage];
                itemToAdd.transform.Find("Button").GetComponent<StorageCardScript>().card = inventory.GetComponent<InventoryCardScript>().card;
                itemToAdd.transform.Find("Button").GetComponent<StorageCardScript>().quantity.text = inventory.GetComponent<InventoryCardScript>().quantity.text;
                itemToAdd.transform.Find("Button").GetComponent<StorageCardScript>().Initialize();
                itemToAdd.transform.Find("Button").tag = activeItemsInStorage.ToString();
                itemToAdd.transform.Find("Button").GetComponent<Button>().onClick.AddListener(StorageCardSelected); ;
                itemToAdd.SetActive(true);
                activeItemsInStorage += 1;
            }

            shopController.inventoryScript.RemoveItem(inventorySelectedItem);
            AdjustInventory();
            switchToStorage.interactable = false;
            

        }



    }

    public void DisableButtons()
    {
        switchToInventory.interactable = false;
        switchToStorage.interactable = false;
    }

    public void AdjustStorage()
    {

        if (storageItems.Count > 0)
        {

            GameObject storageCard = Instantiate(storageItems[storageItems.Count - 1], content);
        }





    }


    public void InventoryCardSelected()
    {
        var button = EventSystem.current.currentSelectedGameObject;
        if (button != null)
        {
            inventorySelectedItem = Int32.Parse(button.tag);
            StorageCardScript script = button.GetComponent<StorageCardScript>();

            switchToStorage.interactable = true;
            switchToInventory.interactable = false;
        }
    }

    public void StorageCardSelected()
    {
        var button = EventSystem.current.currentSelectedGameObject;
        if (button != null)
        {
            selectedStorageItem = Int32.Parse(button.tag);
            StorageCardScript script = button.GetComponent<StorageCardScript>();


            switchToInventory.interactable = true;
            switchToStorage.interactable = false;
        }
    }

    public void AdjustInventory()
    {
        if (shopCanvas != null && shopController == null)
        {
            shopController = shopCanvas.GetComponent<ShopController>();
        }

        int index = 0;
        int inventoryIndex = 0;
        foreach (GameObject item in shopController.inventoryScript.inventory)
        {

            InventoryCardScript script = item.GetComponent<InventoryCardScript>();

            if (script.card != null)
            {
                inventoryItems[index].GetComponent<InventoryCardScript>().card = item.GetComponent<InventoryCardScript>().card;
                inventoryItems[index].GetComponent<InventoryCardScript>().Initialize();
                Debug.Log("Invetory Quantity " + item.GetComponent<InventoryCardScript>().quantity.text);
                inventoryItems[index].GetComponent<InventoryCardScript>().quantity.text = item.GetComponent<InventoryCardScript>().quantity.text;
                inventoryItems[index].SetActive(true);
                inventoryItems[index].tag = inventoryIndex.ToString();                
                if (shopController.inventoryScript.leonEquippedWeapon == inventoryItems[index].GetComponent<InventoryCardScript>().cardName.text ||
                    shopController.inventoryScript.leonEquippedGrenade == inventoryItems[index].GetComponent<InventoryCardScript>().cardName.text)
                {
                    inventoryItems[index].GetComponent<Button>().interactable = false;
                }
                else
                {
                    inventoryItems[index].GetComponent<Button>().interactable = true;

                }
                index++;
            }
            inventoryIndex++;
        }

        if (index < 6)
        {
            for (int i = index; i < 6; i++)
            {
                inventoryItems[i].SetActive(false);
            }
        }
    }

}
