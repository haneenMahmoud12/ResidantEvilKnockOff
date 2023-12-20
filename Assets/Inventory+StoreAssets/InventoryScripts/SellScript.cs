using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class SellScript : MonoBehaviour
{
    // Start is called before the first frame
    [SerializeField] GameObject shopCanvas;
    ShopController shopController;
    [SerializeField] TMP_Text gold;
    [SerializeField] List<GameObject> itemsSell;



    // 
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

    public void Sell()
    {
        var button = EventSystem.current.currentSelectedGameObject;

        if (button != null)
        {
            int index = Int32.Parse(button.tag);
            shopController.inventoryScript.RemoveItem(index);
            SellCardScript buyScript = button.GetComponent<SellCardScript>();
            shopController.inventoryScript.collectGold(buyScript.card.sellPrice);
            ActivateItemsSell();


        }
    }

    public void ActivateItemsSell()
    {
        int index = 0;
        int inventoryIndex = 0;
        if (shopController == null)
        {
            shopController = shopCanvas.GetComponent<ShopController>();
        }
        gold.SetText(shopController.inventoryScript.leonGold.ToString());

        foreach (GameObject item in shopController.inventoryScript.inventory)
        {

            InventoryCardScript script = item.GetComponent<InventoryCardScript>();

            script.Initialize();

            if (script.card != null)
            {
                Debug.Log(script.card);
                if (script.card.canSell)
                {
                    SellCardScript sellScript = itemsSell[index].transform.Find("Button").transform.Find("Sell").gameObject.GetComponent<SellCardScript>();
                    itemsSell[index].transform.Find("Button").transform.Find("Sell").tag = inventoryIndex.ToString();
                    sellScript.card = script.card;
                    sellScript.Initialize();
                    itemsSell[index].SetActive(true);
                    index++;
                }
            }
            inventoryIndex++;
        }

        if (index < 6)
        {
            for (int i = index; i < 6; i++)
            {
                itemsSell[i].SetActive(false);
            }
        }
    }
}
