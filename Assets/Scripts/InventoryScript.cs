//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;
//using TMPro;


//public class InventoryScript : MonoBehaviour
//{
	
//    [SerializeField] Card diamondKey;
//    [SerializeField] Card clubKey;
//    [SerializeField] Card spadeCard;
//    [SerializeField] TMP_Text healthPoints;
//    [SerializeField] TMP_Text gold;
//    [SerializeField] TMP_Text equippedWeapon;
//    [SerializeField] TMP_Text equippedGrenade;
//    [SerializeField] TMP_Text kniefDurability;
//    [SerializeField] Button use;
//    [SerializeField] Button discard;
//    [SerializeField] Button equip;
//    [SerializeField] Button combine;

//    string selectedItem;



//    // Start is called before the first frame update
//    void Start()
//    {
//        //   CheckCardType();
//    }
//    private void Update()
//    {
//        if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
//        {
//            discard.interactable = false;
//            use.interactable = false;
//            combine.interactable = false;
//            equip.interactable = false;
//        }

//    }

//    public void CardSelected()
//    {
//        var button = EventSystem.current.currentSelectedGameObject;
//        if (button != null)
//        {
//            selectedItem = button.name;
//            NewBehaviourScript script = button.GetComponent<NewBehaviourScript>();
//            CheckCardType(script);

//        }
//        else
//        {


//        }

//    }
//    public void Discard()
//    {

//        int index = selectedItem == "Button1" ? 1 : (selectedItem == "Button2" ? 2 : (selectedItem == "Button3" ? 3 : (selectedItem == "Button4" ? 4 :
//           (selectedItem == "Button5" ? 5 : 6))));
//        inventory[index - 1].GetComponent<NewBehaviourScript>().card = null;
//        inventory[index - 1].GetComponent<NewBehaviourScript>().cardName.text = "";
//        inventory[index - 1].GetComponent<NewBehaviourScript>().quantity.text = "";
//        Color newColor = new Color(1, 1, 1, 0);
//        inventory[index - 1].GetComponent<NewBehaviourScript>().image.color = newColor;
//        inventory[index - 1].GetComponent<NewBehaviourScript>().image.sprite = null;
//        discard.interactable = false;
//        use.interactable = false;
//        combine.interactable = false;
//        equip.interactable = false;


//    }

//    public void Use()
//    {
//        int index = selectedItem == "Button1" ? 1 : (selectedItem == "Button2" ? 2 : (selectedItem == "Button3" ? 3 : (selectedItem == "Button4" ? 4 :
//            (selectedItem == "Button5" ? 5 : 6))));




//        GameObject item = inventory[index - 1];
//        NewBehaviourScript script = item.GetComponent<NewBehaviourScript>();
//        if (script.cardName.text == "Green Herb")
//        {

//            healthPoints.SetText((Int32.Parse(healthPoints.text) + 2).ToString());
//        }
//        else if (
//               script.cardName.text == "Green + Green Mixture")
//        {
//            healthPoints.SetText((Int32.Parse(healthPoints.text) + 6).ToString());
//        }
//        else if (script.cardName.text == "Green + Red Mixture")
//        {
//            healthPoints.SetText((Int32.Parse(healthPoints.text) + 8).ToString());
//        }

//        inventory[index - 1].GetComponent<NewBehaviourScript>().card = null;
//        inventory[index - 1].GetComponent<NewBehaviourScript>().cardName.text = "";
//        inventory[index - 1].GetComponent<NewBehaviourScript>().quantity.text = "";
//        Color newColor = new Color(1, 1, 1, 0);
//        inventory[index - 1].GetComponent<NewBehaviourScript>().image.color = newColor;
//        inventory[index - 1].GetComponent<NewBehaviourScript>().image.sprite = null;
//        discard.interactable = false;
//        use.interactable = false;
//        combine.interactable = false;
//        equip.interactable = false;



//    }

//    public void Combine()
//    {


//    }

//    public void Equip()
//    {
//        int index = selectedItem == "Button1" ? 1 : (selectedItem == "Button2" ? 2 : (selectedItem == "Button3" ? 3 : (selectedItem == "Button4" ? 4 :
//           (selectedItem == "Button5" ? 5 : 6))));




//        GameObject item = inventory[index - 1];
//        NewBehaviourScript script = item.GetComponent<NewBehaviourScript>();
//        if (script.cardName.text == "Rifle" || script.cardName.text == "Shotgun" ||
//                script.cardName.text == "Revolver" || script.cardName.text == "Pistol")
//        {
//            equippedWeapon.SetText(script.cardName.text);

//        }
//        else if (script.cardName.text == "Hand Gerande" || script.cardName.text == "Flash Gerande")
//        {
//            equippedGrenade.SetText(script.cardName.text);

//        }
//        discard.interactable = false;
//        use.interactable = false;
//        combine.interactable = false;
//        equip.interactable = false;

//    }
//    public void CheckCardType(NewBehaviourScript script)
//    {

//        if (script.card != null)
//        {
//            Debug.Log(script.cardName.text);


//            if (script.cardName.text == "Green Herb" ||
//                script.cardName.text == "Green + Green Mixture" || script.cardName.text == "Green + Red Mixture")
//            {
//                use.interactable = true;
//            }
//            else
//            {
//                use.interactable = false;
//            }


//            if (script.cardName.text == "Green Herb" || script.cardName.text == "Red Herb")
//            {
//                combine.interactable = true;
//            }
//            else
//            {
//                combine.interactable = false;
//            }

//            if (script.cardName.text == "Rifle" || script.cardName.text == "Shotgun" ||
//                script.cardName.text == "Revolver" || script.cardName.text == "Pistol" ||
//                script.cardName.text == "Hand Gerande" || script.cardName.text == "Flash Gerande")
//            {
//                equip.interactable = true;
//            }
//            else
//            {
//                equip.interactable = false;
//            }

//            if (script.cardName.text == "Rifle" || script.cardName.text == "Shotgun" ||
//                script.cardName.text == "Revolver" || script.cardName.text == "Pistol" ||
//                script.cardName.text == "Key Card" || script.cardName.text == "Emblem" ||
//                script.cardName.text == "Spade Key" || script.cardName.text == "Diamond Key" ||
//                script.cardName.text == "Heart Key" || script.cardName.text == "Club Key")
//            {
//                discard.interactable = false;
//            }
//            else
//            {
//                discard.interactable = true;
//            }
//        }
//        else
//        {
//            discard.interactable = false;
//            use.interactable = false;
//            combine.interactable = false;
//            equip.interactable = false;
//        }



//    }
//}