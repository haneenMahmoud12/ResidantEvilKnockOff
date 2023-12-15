using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] GameObject kniefSharpener;
    [SerializeField] GameObject sellCanvas;
    [SerializeField] GameObject buyCanvas;
    [SerializeField] GameObject storageCanvas;
    [SerializeField] GameObject inventoryCanvas;
    public InventoryScript inventoryScript;
    public KniefSharpener kniefSharpenerScript;
    public BuyScript buyScript;
    public SellScript sellScript;
    public StorageScript storageScript;

    // Start is called before the first frame update
    void Start()
    {
        if (inventoryCanvas != null)
        {
            inventoryScript = inventoryCanvas.GetComponent<InventoryScript>();
        }
        if (kniefSharpener != null)
        {
            kniefSharpenerScript = kniefSharpener.GetComponent<KniefSharpener>();
        }
        if (buyCanvas != null)
        {
            buyScript = buyCanvas.GetComponent<BuyScript>();
        }

        if (sellCanvas != null)
        {
            sellScript = sellCanvas.GetComponent<SellScript>();
        }

        if (sellCanvas != null)
        {
            storageScript = storageCanvas.GetComponent<StorageScript>();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(inventoryScript == null)
        {
            inventoryScript = inventoryCanvas.GetComponent<InventoryScript>();
        }
        Time.timeScale = 0;
        OpenstorageCanvas();
    }

    public void OpenSell()
    {
        storageCanvas.SetActive(false);
        sellCanvas.SetActive(true);
        buyCanvas.SetActive(false);
        kniefSharpener.SetActive(false);
        sellScript.ActivateItemsSell();
    }

    public void OpenBuy()
    {
        storageCanvas.SetActive(false);
        sellCanvas.SetActive(false);
        buyCanvas.SetActive(true);
        kniefSharpener.SetActive(false);
        buyScript.ActivateItems();
        buyScript.AdjustInventory();
    }

    public void OpenKnief()
    {
        storageCanvas.SetActive(false);
        sellCanvas.SetActive(false);
        buyCanvas.SetActive(false);
        kniefSharpener.SetActive(true);
        kniefSharpenerScript.CanSharpen();

    }

    public void OpenstorageCanvas()
    {
        storageCanvas.SetActive(true);
        sellCanvas.SetActive(false);
        buyCanvas.SetActive(false);
        kniefSharpener.SetActive(false);
        storageScript.AdjustInventory();
    }
}
