using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class BuyScript : MonoBehaviour
{
    [SerializeField] List<GameObject> storeItems;
    [SerializeField] GameObject shopCanvas;
    ShopController shopController;
    [SerializeField] List<GameObject> inventoryItems;
    [SerializeField] TMP_Text gold;


    // Start is called before the first frame update
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

    public void BuyItem()
    {

        var button = EventSystem.current.currentSelectedGameObject;
        if (button != null)
        {

            BuyCardScript buyScript = button.GetComponent<BuyCardScript>();
            foreach (GameObject item in shopController.inventoryScript.inventory)
            {
                InventoryCardScript inventoryScript = item.GetComponent<InventoryCardScript>();
                if (inventoryScript.card == null)
                {
                    shopController.inventoryScript.collectItem(buyScript.cardName.text);
                    shopController.inventoryScript.collectAmmo(buyScript.cardName.text, Int32.Parse(buyScript.quantity.text));
                    break;
                }

            }
            shopController.inventoryScript.UseGold(Int32.Parse(buyScript.buyPrice.text));
            gold.SetText(shopController.inventoryScript.leonGold.ToString());
            ActivateItems();
            AdjustInventory();


        }

    }

    public void ActivateItems()
    {
        bool pistolAmmo = false;
        bool rifleAmmo = false;
        bool revolverAmmo = false;
        bool shotgunAmmo = false;
        bool emptySlot = false;

        if (shopCanvas != null && shopController == null)
        {
            shopController = shopCanvas.GetComponent<ShopController>();
        }

        gold.SetText(shopController.inventoryScript.leonGold.ToString());
        foreach (GameObject item in shopController.inventoryScript.inventory)
        {
            InventoryCardScript script = item.GetComponent<InventoryCardScript>();
            script.Initialize();
            if (script.card == null)
            {
                emptySlot = true;
            }
            if (script.cardName.text == "Pistol Ammo")
            {
                pistolAmmo = true;
            }

            else if (script.cardName.text == "Rifle Ammo")
            {
                rifleAmmo = true;
            }

            else if (script.cardName.text == "Revolver Ammo")
            {
                revolverAmmo = true;
            }
            else if (script.cardName.text == "Shotgun Ammo")
            {
                shotgunAmmo = true;
            }

        }


        foreach (GameObject item in storeItems)
        {
            BuyCardScript script = item.transform.Find("Button").transform.Find("Buy").GetComponent<BuyCardScript>();
            script.Initialize();
            if (emptySlot || (script.cardName.text == "Pistol Ammo" && pistolAmmo) || (script.cardName.text == "Rifle Ammo" && rifleAmmo)
                || (script.cardName.text == "Revolver Ammo" && revolverAmmo) || (script.cardName.text == "Shotgun Ammo" && shotgunAmmo))
            {
                if (Int32.Parse(script.buyPrice.text) <= shopController.inventoryScript.leonGold)
                {
                    Debug.Log(shopController.inventoryScript.leonGold);
                    item.transform.Find("Button").transform.Find("Buy").GetComponent<Button>().interactable = true;
                    item.transform.Find("Button").GetComponent<Button>().interactable = true;
                }
                else
                {
                    item.transform.Find("Button").transform.Find("Buy").GetComponent<Button>().interactable = false;
                    item.transform.Find("Button").GetComponent<Button>().interactable = false;
                }
            }
            else
            {
                item.transform.Find("Button").transform.Find("Buy").GetComponent<Button>().interactable = false;
                item.transform.Find("Button").GetComponent<Button>().interactable = false;
            }
        }
    }

    public void AdjustInventory()
    {
        int index = 0;
        foreach (GameObject item in shopController.inventoryScript.inventory)
        {

            InventoryCardScript script = item.GetComponent<InventoryCardScript>();

            if (script.card != null)
            {
                inventoryItems[index].GetComponent<InventoryCardScript>().card = item.GetComponent<InventoryCardScript>().card;
                inventoryItems[index].GetComponent<InventoryCardScript>().Initialize();
                inventoryItems[index].SetActive(true);
                index++;
            }
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
