using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using StarterAssets;


public class InventoryScript : MonoBehaviour
{
    public List<GameObject> inventory;
    [SerializeField] Card greenHerb;
    [SerializeField] Card redHerb;
    [SerializeField] Card pistol;
    [SerializeField] Card shotGun;
    [SerializeField] Card rifle;
    [SerializeField] Card revolver;
    [SerializeField] Card pistolAmmo;
    [SerializeField] Card shotGunAmmo;
    [SerializeField] Card revolverAmmo;
    [SerializeField] Card rifleAmmo;
    [SerializeField] Card handGrenade;
    [SerializeField] Card flashGrenade;
    [SerializeField] Card normalGunPowder;
    [SerializeField] Card highGradeGunPowder;
    [SerializeField] Card emblem;
    [SerializeField] Card keyCard;
    [SerializeField] Card goldBar;
    [SerializeField] Card ggMixture;
    [SerializeField] Card grMixture;
    [SerializeField] Card rrMixture;
    [SerializeField] Card ruby;
    [SerializeField] Card emerald;
    [SerializeField] Card heartKey;
    [SerializeField] Card diamondKey;
    [SerializeField] Card clubKey;
    [SerializeField] Card spadeCard;
    [SerializeField] TMP_Text healthPoints;
    [SerializeField] TMP_Text gold;

    public int leonHealthPoints = 10;
    public int leonGold = 30;
    public int leonKniefDurability = 8;
    public string leonEquippedWeapon = "";
    public string leonEquippedGrenade ="";
    public bool isInvincible = false;

    [SerializeField] TMP_Text equippedWeapon;
    [SerializeField] TMP_Text equippedGrenade;
    [SerializeField] TMP_Text kniefDurability;
   
    [SerializeField] Button use;
    [SerializeField] Button discard;
    [SerializeField] Button equip;
    [SerializeField] Button combine;

    [SerializeField] TMP_Text combineeText;
    [SerializeField] Button confirmCombine;



    [SerializeField] GameObject inventoryCanvas;
    [SerializeField] GameObject craftingCanvas;
    public int indexCombinee;
    string selectedItem;

    CraftingScript craftingScript;

    public ThirdPersonController thirdPersonController;
    public StarterAssetsInputs starterAssetsInputs;
    [SerializeField] private Animator playerAnim;

    [SerializeField] GameObject player;

    [SerializeField] Slider slider;
    //[SerializeField] LeonHealthBar leonHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        if (craftingCanvas != null)
        {
            craftingScript = craftingCanvas.GetComponent<CraftingScript>();
        }
        if (player != null)
        {
            thirdPersonController = player.GetComponent<ThirdPersonController>();
            starterAssetsInputs = player.GetComponent<StarterAssetsInputs>();
            playerAnim = player.GetComponent<Animator>();
        }

        gold.SetText(leonGold.ToString());

        kniefDurability.SetText(leonKniefDurability.ToString());
        healthPoints.SetText(leonHealthPoints.ToString());
        equippedWeapon.SetText(leonEquippedWeapon.ToString());
        equippedGrenade.SetText(leonEquippedGrenade.ToString());

        //   CheckCardType();
    }
    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.R))
        {
            
            bool reload = ReloadWeapon();
        }*/

       /* if (Input.GetKeyDown(KeyCode.T))
        {

            bool reload = ThrowGrenade();
            Debug.Log(reload);
        }*/
       

    }

    public bool collectItem(string item)
    {
        bool flag = false;
        foreach (GameObject inventoryItem in inventory)
        {
            InventoryCardScript script = inventoryItem.GetComponent<InventoryCardScript>();

            if (script.card == null)
            {
                switch (item)
                {
                    case "Green Herb": script.card = greenHerb; break;
                    case "Red Herb": script.card = redHerb; break;
                    case "Normal Gunpowder": script.card = normalGunPowder; break;
                    case "High-Grade Gunpowder": script.card = highGradeGunPowder; break;
                    case "Hand Gernade": script.card = handGrenade; break;
                    case "Flash Gernade": script.card = flashGrenade; break;
                    case "Revolver": script.card = revolver; break;
                    case "Rifle": script.card = rifle; break;
                    case "Shotgun": script.card = shotGun; break;
                    case "Emblem": script.card = emblem; break;
                    case "Spade Key ": script.card = spadeCard; break;
                    case "Heart Key":
                        script.card = heartKey;
                        break;
                    case "Club Key": script.card = clubKey; break;
                    case "Diamond Key": script.card = diamondKey; break;
                    case "KeyCard": script.card = keyCard; break;
                    case "Gold Bar": script.card = goldBar; break;
                    case "Ruby": script.card = ruby; break;
                    case "Emerald": script.card = goldBar; break;
                    case "Green + Green Mixture": script.card = ggMixture; break;
                    case "Green + Red Mixture": script.card = grMixture; break;
                    case "Red + Red Mixture": script.card = rrMixture; break;
                    default:; break;
                }
                script.Initialize();

                flag = true;
                break;

            }

        }
        Debug.Log(flag);
        return flag;

    }

    public void collectAmmo(string item, int ammount)
    {
        if (item == "Pistol Ammo" || item == "Rifle Ammo" || item == "Shotgun Ammo" || item == "Revolver Ammo")
        {


            bool flag = false;
            int index = -1;
            int i = 0;
            bool ammoFound = false;
            foreach (GameObject inventoryItem in inventory)
            {
                InventoryCardScript script = inventoryItem.GetComponent<InventoryCardScript>();
                if (script.card == null && index == -1)
                {
                    index = i;

                }
                else if (script.cardName.text == item)
                {

                    script.quantity.SetText((Int32.Parse(script.quantity.text) + ammount).ToString());
                    ammoFound = true;
                    break;
                }
                i++;
            }

            if (ammoFound == true)
            {
                /*            return true;
                */
            }
            else if (index != -1)
            {
                InventoryCardScript script = inventory[index].GetComponent<InventoryCardScript>();

                switch (item)
                {
                    case "Rifle Ammo": script.card = rifleAmmo; break;
                    case "Pistol Ammo": script.card = pistolAmmo; break;
                    case "Revolver Ammo":
                        script.card = revolverAmmo; break;
                    case "Shotgun Ammo":
                        script.card = shotGunAmmo; break;
                    default:; break;
                }
                script.Initialize();

            }
        }
    }
    public void collectGold(int goldAmmount)
    {
        Debug.Log("inventoryScript  " + goldAmmount);
        leonGold += goldAmmount;
        gold.SetText((Int32.Parse(gold.text)+goldAmmount).ToString());
    }

    public bool UseGold(int goldAmmount)
    {
        if (Int32.Parse(gold.text) >= goldAmmount)
        {
            leonGold -= goldAmmount;
            gold.SetText((Int32.Parse(gold.text) - goldAmmount).ToString());
            return true;
        }
        return false;


    }

    public void IncreasePlayerHealth(int points)
    {
        if (Int32.Parse(healthPoints.text) < 8)
        {
            healthPoints.SetText((Int32.Parse(healthPoints.text) + points).ToString());
            leonHealthPoints += points;
            if (Int32.Parse(healthPoints.text) > 8)
            {
                healthPoints.SetText("8");
                leonHealthPoints = 8;
            }
            slider.value = leonHealthPoints;
            //leonHealthBar.Health(leonHealthPoints);
        }

    }

    public bool DecreasePlayerHealth(int points)
    {
        if (!isInvincible)
        {
            healthPoints.SetText((Int32.Parse(healthPoints.text) - points).ToString());
            leonHealthPoints -= points;
            slider.value = leonHealthPoints;
            //leonHealthBar.Health(leonHealthPoints);
        }
        if (Int32.Parse(healthPoints.text) <= 0)
        {
            leonHealthPoints = 0;
            slider.value = leonHealthPoints;
            //leonHealthBar.Health(leonHealthPoints);
            healthPoints.SetText("0");
            playerAnim.SetTrigger("die");
            return true;
        }
        return false;
        
    }
    public void RestoreKniefDurability()
    {
        leonKniefDurability = 10;
        kniefDurability.SetText("10");
        leonGold -= 100;
        gold.SetText(leonGold.ToString());
    }

    public void DecreaseKniefDurability(int ammount)
    {
        leonKniefDurability -= ammount;
        if (leonKniefDurability < 0)
            leonKniefDurability = 0;
        kniefDurability.SetText(leonKniefDurability.ToString());

    }

    public void CardSelected()
    {
        var button = EventSystem.current.currentSelectedGameObject;
        if (button != null)
        {
            selectedItem = button.name;
            InventoryCardScript script = button.GetComponent<InventoryCardScript>();
            CheckCardType(script);
            confirmCombine.interactable = true;

        }
        else
        {


        }
    
}
    public void Discard()
    {

        int index = selectedItem == "Button1" ? 1 : (selectedItem == "Button2" ? 2 : (selectedItem == "Button3" ? 3 : (selectedItem == "Button4" ? 4 :
           (selectedItem == "Button5" ? 5 : 6))));
        inventory[index - 1].GetComponent<InventoryCardScript>().card = null;
        inventory[index - 1].GetComponent<InventoryCardScript>().cardName.text = "";
        inventory[index - 1].GetComponent<InventoryCardScript>().quantity.text = "";
        Color newColor = new Color(1, 1, 1, 0);
        inventory[index - 1].GetComponent<InventoryCardScript>().image.color = newColor;
        inventory[index - 1].GetComponent<InventoryCardScript>().image.sprite = null;
        inventory[index - 1].GetComponent<InventoryCardScript>().Initialize();
        discard.interactable = false;
        use.interactable = false;
        combine.interactable = false;
        equip.interactable = false;
        


    }

    public void Use()
    {
        int index = selectedItem == "Button1" ? 1 :(selectedItem == "Button2" ? 2 :(selectedItem == "Button3" ?3 : (selectedItem == "Button4"?4 :
            (selectedItem == "Button5"? 5 : 6)))) ;
        GameObject item = inventory[index-1];
        InventoryCardScript script = item.GetComponent<InventoryCardScript>();
        if (script.cardName.text == "Green Herb")
        {
        
            healthPoints.SetText((Int32.Parse(healthPoints.text) +2).ToString());
        }
        else if (
               script.cardName.text == "Green + Green Mixture" )
        {
            healthPoints.SetText((Int32.Parse(healthPoints.text) + 6).ToString());
        }
        else if (script.cardName.text == "Green + Red Mixture")
        {
            healthPoints.SetText((Int32.Parse(healthPoints.text) + 8).ToString());
        }

        inventory[index-1].GetComponent<InventoryCardScript>().card = null;
        inventory[index-1].GetComponent<InventoryCardScript>().cardName.text = "";
        inventory[index-1].GetComponent<InventoryCardScript>().quantity.text = "";
        Color newColor = new Color(1, 1, 1, 0);
        inventory[index - 1].GetComponent<InventoryCardScript>().image.color = newColor;
        inventory[index-1].GetComponent<InventoryCardScript>().image.sprite = null;
        discard.interactable = false;
        use.interactable = false;
        combine.interactable = false;
        equip.interactable = false;



    }

    public void Combine()
    {
        int index = selectedItem == "Button1" ? 1 : (selectedItem == "Button2" ? 2 : (selectedItem == "Button3" ? 3 : (selectedItem == "Button4" ? 4 :
           (selectedItem == "Button5" ? 5 : 6))));

        Debug.Log(inventory);
        indexCombinee = index - 1;
        GameObject item = inventory[index - 1];
        string combinee = item.GetComponent<InventoryCardScript>().cardName.text;
        int i = 0;


        craftingCanvas.SetActive(true);
        if(craftingScript == null)
        {
            craftingScript = craftingCanvas.GetComponent<CraftingScript>();
        }
     
        int indexLoop = 0;
        foreach (GameObject inventoryItem in craftingScript.inventory)
        {
            inventoryItem.GetComponent<InventoryCardScript>().card = inventory[indexLoop].GetComponent<InventoryCardScript>().card;
            inventoryItem.GetComponent<InventoryCardScript>().Initialize();
            indexLoop++;

        }


        foreach (GameObject inventoryItem in craftingScript.inventory)
        {
            InventoryCardScript script = inventoryItem.GetComponent<InventoryCardScript>();
            Debug.Log(script);
            if (i == index - 1)
            {
                inventoryItem.SetActive(false);

            }
            else if (combinee == "Green Herb" || combinee == "Red Herb")
            {
                if (script.cardName.text == "Green Herb" || script.cardName.text == "Red Herb")
                {

                    inventoryItem.SetActive(true);

                }
                else
                {
                    inventoryItem.SetActive(false);
                }
            }
            else if (combinee == "Normal Gunpowder" || combinee == "High-Grade Gunpowder")
            {
                if (script.cardName.text == "Normal Gunpowder" || script.cardName.text == "High-Grade Gunpowder")
                {

                    inventoryItem.SetActive(true);

                }
                else
                {
                    inventoryItem.SetActive(false);
                }
            }
            i++;
        }

        inventoryCanvas.SetActive(false);
        combineeText.SetText(combinee);
        discard.interactable = false;
        use.interactable = false;
        combine.interactable = false;
        equip.interactable = false;
        confirmCombine.interactable = false;








    }

    public void RemoveItem(int item)

    {
        InventoryCardScript script = inventory[item].GetComponent<InventoryCardScript>();
        script.card = null;
        script.cardName.text = "";
        script.quantity.text = "";
        Color newColor = new Color(1, 1, 1, 0);
        script.image.color = newColor;
        script.image.sprite = null;
        script.Initialize();
    }

    public void Equip()
    {
        int index = selectedItem == "Button1" ? 1 : (selectedItem == "Button2" ? 2 : (selectedItem == "Button3" ? 3 : (selectedItem == "Button4" ? 4 :
           (selectedItem == "Button5" ? 5 : 6))));
        GameObject item = inventory[index - 1];
        InventoryCardScript script = item.GetComponent<InventoryCardScript>();
        if (script.cardName.text == "Rifle" || script.cardName.text == "Shotgun" ||
                script.cardName.text == "Revolver" || script.cardName.text == "Pistol")
        {
            equippedWeapon.SetText(script.cardName.text);
            leonEquippedWeapon = script.cardName.text;

        }
        else if (script.cardName.text == "Hand Gernade" || script.cardName.text == "Flash Gernade")
        {
            equippedGrenade.SetText(script.cardName.text);
            leonEquippedGrenade = script.cardName.text;

        }
        discard.interactable = false;
        use.interactable = false;
        combine.interactable = false;
        equip.interactable = false;

    }
    public void CheckCardType(InventoryCardScript script)
    {               
        if (script.card != null)
        {
            Debug.Log(script.cardName.text);
           

            if (script.cardName.text == "Green Herb" ||
                script.cardName.text == "Green + Green Mixture" || script.cardName.text== "Green + Red Mixture")
            {
                use.interactable = true;
            }
            else
            {
                use.interactable = false;
            }


            if (script.cardName.text == "Green Herb" || script.cardName.text == "Red Herb" ||
                script.cardName.text == "High-Grade Gunpowder" || script.cardName.text == "Normal Gunpowder")
            {
                combine.interactable = true;
            }
            else
            {
                combine.interactable = false;
            }
            
            if (script.cardName.text == "Rifle" || script.cardName.text == "Shotgun" ||
                script.cardName.text == "Revolver" || script.cardName.text == "Pistol" ||
                script.cardName.text == "Hand Gernade" || script.cardName.text == "Flash Gernade")
            {
                equip.interactable = true;
            }
            else
            {
                equip.interactable = false;
            }

            if (script.cardName.text == "Rifle" || script.cardName.text == "Shotgun" ||
                script.cardName.text == "Revolver" || script.cardName.text == "Pistol" ||
                script.cardName.text == "Key Card" || script.cardName.text == "Emblem" ||
                script.cardName.text == "Spade Key" || script.cardName.text == "Diamond Key" ||
                script.cardName.text == "Heart Key" || script.cardName.text == "Club Key")
            {
                discard.interactable = false;
            }
            else
            {
                discard.interactable = true;
            }
        }
        else
        {
            discard.interactable = false;
            use.interactable = false;
            combine.interactable = false;
            equip.interactable = false;
        }



    }

    public bool canFire()
    {
        bool canFire = false;
        if (leonEquippedGrenade != "")
        {
            return false;
        }
        else
        {
            foreach(GameObject item in inventory)
            {
                if (item.GetComponent<InventoryCardScript>().cardName.text == leonEquippedWeapon)
                {
                    if (item.GetComponent<InventoryCardScript>().ammosAmmount.text != "0")
                    {
                        canFire = true;
                        break;
                    }
                }
            }
        }
        return canFire;
    }

    public bool ReloadWeapon()
    {
        if(leonEquippedWeapon == "")
        {
            return false;
        }
        bool canReload = true;
        bool ammosFound = false;
        int ammosIndex = 0;
        foreach (GameObject item in inventory)
        {
            if (item.GetComponent<InventoryCardScript>().cardName.text == leonEquippedWeapon + " Ammo")
            {
                ammosFound = true;
                break;
            }
            ammosIndex++;

        }
        if (!ammosFound)
        {
            return false;
        }
        foreach (GameObject item in inventory)
        {
            InventoryCardScript script = item.GetComponent<InventoryCardScript>();
            if (script.cardName.text == leonEquippedWeapon)
            {
                if(script.ammosAmmount.text == script.card.capacityAmmo.ToString())
                {
                    canReload = false;
                    break;
                }
                else
                {
                    int ammosAvaliable = Int32.Parse(inventory[ammosIndex].GetComponent<InventoryCardScript>().quantity.text);
                    int clipCapacity = script.card.capacityAmmo;
                    int ammosInWeapon = Int32.Parse(script.ammosAmmount.text);
                    int ammosNeeded = clipCapacity - ammosInWeapon;

                    if(ammosNeeded >= ammosAvaliable)
                    {
                        script.ammosAmmount.text = (Int32.Parse(script.ammosAmmount.text) + Int32.Parse(inventory[ammosIndex].GetComponent<InventoryCardScript>().quantity.text)).ToString();
                        inventory[ammosIndex].GetComponent<InventoryCardScript>().quantity.text = (Int32.Parse(inventory[ammosIndex].GetComponent<InventoryCardScript>().quantity.text) 
                            - ammosNeeded).ToString();

                        if(inventory[ammosIndex].GetComponent<InventoryCardScript>().quantity.text == "0")
                        {
                            inventory[ammosIndex].GetComponent<InventoryCardScript>().card = null;
                            inventory[ammosIndex].GetComponent<InventoryCardScript>().Initialize();
                        }
                    }

                    else
                    {
                        script.ammosAmmount.text = script.card.capacityAmmo.ToString();
                        inventory[ammosIndex].GetComponent<InventoryCardScript>().quantity.text = (Int32.Parse(inventory[ammosIndex].GetComponent<InventoryCardScript>().quantity.text)
                            - ammosNeeded).ToString();
                    }

                    
                }
            }
            

        }
        return canReload;
    }

    public bool FireWeapon ()
    {
        if (!canFire())
        {
            return false;
        }
        foreach (GameObject item in inventory)
        {
            if (item.GetComponent<InventoryCardScript>().cardName.text == leonEquippedWeapon)
            {
                item.GetComponent<InventoryCardScript>().ammosAmmount.text = (Int32.Parse(item.GetComponent<InventoryCardScript>().ammosAmmount.text) -1 ).ToString();
            }
        }
        return true;

    }

    public string GetAmmoCount()
    {
        string ammos = "";
        foreach (GameObject item in inventory)
        {
            if (item.GetComponent<InventoryCardScript>().cardName.text == leonEquippedWeapon)
            {
                ammos = item.GetComponent<InventoryCardScript>().ammosAmmount.text;
            }
        }
        return ammos;
    }
    public bool ThrowGrenade ()
    {
        if(leonEquippedGrenade == "")
        {
            return false;
        }
        foreach(GameObject item in inventory)
        {
            InventoryCardScript script = item.GetComponent<InventoryCardScript>();
            if(script.cardName.text == leonEquippedGrenade)
            {
                script.card = null;
                script.Initialize();
            
            }
        }
        leonEquippedGrenade = "";
        equippedGrenade.SetText(leonEquippedGrenade);
        return true;

    }

    public bool KeycardFound ()
    {
        bool keyItemFound = false;
        foreach (GameObject item in inventory)
        {
            if(item.GetComponent<InventoryCardScript>().cardName.text == "Key Card")
            {
                item.GetComponent<InventoryCardScript>().card = null;
                item.GetComponent<InventoryCardScript>().Initialize();
                keyItemFound = true;
                break;
                
            }
        }
        return keyItemFound;
    }

    public bool HeartKeyFound()
    {
        bool itemFound = false;
        foreach (GameObject item in inventory)
        {
            if (item.GetComponent<InventoryCardScript>().cardName.text == "Heart Key")
            {
                item.GetComponent<InventoryCardScript>().card = null;
                item.GetComponent<InventoryCardScript>().Initialize();
                itemFound = true;
                break;

            }
        }
        return itemFound;
    }

    public bool ClubKeyFound()
    {
        bool itemFound = false;
        foreach (GameObject item in inventory)
        {
            if (item.GetComponent<InventoryCardScript>().cardName.text == "Club Key")
            {
                item.GetComponent<InventoryCardScript>().card = null;
                item.GetComponent<InventoryCardScript>().Initialize();
                itemFound = true;
                break;

            }
        }
        return itemFound;
    }

    public bool SpadeKeyFound()
    {
        bool itemFound = false;
        foreach (GameObject item in inventory)
        {
            if (item.GetComponent<InventoryCardScript>().cardName.text == "Spade Key")
            {
                item.GetComponent<InventoryCardScript>().card = null;
                item.GetComponent<InventoryCardScript>().Initialize();
                itemFound = true;
                break;

            }
        }
        return itemFound;
    }

    public bool DiamondKeyFound()
    {
        bool itemFound = false;
        foreach (GameObject item in inventory)
        {
            if (item.GetComponent<InventoryCardScript>().cardName.text == "Diamond Key")
            {
                item.GetComponent<InventoryCardScript>().card = null;
                item.GetComponent<InventoryCardScript>().Initialize();
                itemFound = true;
                break;

            }
        }
        return itemFound;
    }

    public bool EmblemFound()
    {
        bool itemFound = false;
        foreach (GameObject item in inventory)
        {
            if (item.GetComponent<InventoryCardScript>().cardName.text == "Emblem")
            {
                item.GetComponent<InventoryCardScript>().card = null;
                item.GetComponent<InventoryCardScript>().Initialize();
                itemFound = true;
                break;

            }
        }
        return itemFound;
    }

    public void DisableButtons ()
    {
        discard.interactable = false;
        use.interactable = false;
        combine.interactable = false;
        equip.interactable = false;
    }

    public void OpenInventory ()
    {
        if (thirdPersonController == null)
        {
            thirdPersonController = player.GetComponent<ThirdPersonController>();
        }
        if (starterAssetsInputs == null)
        {
            starterAssetsInputs = player.GetComponent<StarterAssetsInputs>();
        }
        Time.timeScale = 0;
        starterAssetsInputs.cursorLocked = false;
        Cursor.lockState = CursorLockMode.None;

        thirdPersonController.LockCameraPosition = true;
        inventoryCanvas.SetActive(true);
    }

    public void CloseInventory()
    {
        Time.timeScale = 1;
        inventoryCanvas.SetActive(false);
        craftingCanvas.SetActive(false);
        thirdPersonController.LockCameraPosition = false;
/*        starterAssetsInputs.cursorLocked = true;
*/    }

    public void GoldCheat()
    {
        collectGold(1000);
    }

    public void HealCheat()
    {
        if(leonHealthPoints!=0)
            IncreasePlayerHealth(4);
    }

    public void InvincibilityCheat()
    {
        isInvincible = !isInvincible;
    }

}
