using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class KniefSharpener : MonoBehaviour
{
    [SerializeField] GameObject shopCanvas;
    ShopController shopController;
    [SerializeField] Button sharpen;
    [SerializeField] TMP_Text kniefDurability;
    [SerializeField] TMP_Text goldCoins;

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

    public void CanSharpen()
    {
        if (shopCanvas != null && shopController == null)
        {
            shopController = shopCanvas.GetComponent<ShopController>();
        }

        if (shopController.inventoryScript.leonKniefDurability < 8 && shopController.inventoryScript.leonGold >= 100)
        {
            sharpen.interactable = true;
        }
        else
        {
            sharpen.interactable = false;
        }

        kniefDurability.SetText(shopController.inventoryScript.leonKniefDurability.ToString());
        goldCoins.SetText(shopController.inventoryScript.leonGold.ToString());

    }

    public void RestoreDurability()
    {
        shopController.inventoryScript.RestoreKniefDurability();
        kniefDurability.SetText(shopController.inventoryScript.leonKniefDurability.ToString());
        goldCoins.SetText(shopController.inventoryScript.leonGold.ToString());


    }
}
