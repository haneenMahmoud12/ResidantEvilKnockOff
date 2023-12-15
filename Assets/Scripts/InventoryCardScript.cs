using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryCardScript : MonoBehaviour
{
    public Card card;
    public TMP_Text cardName;
    public TMP_Text quantity;
    public Image image;
    public TMP_Text ammosAmmount;
    public GameObject ammoObject;



    // Start is called before the first frame update
    void Start()
    {
        
     if(card != null)
        {
            Initialize();
        }
      
        
    }

    public void Initialize()
    {
        if (card == null)
        {
            Color newColor1 = new Color(1, 1, 1, 0);
            image.color = newColor1;
            cardName.text = "";
            ammosAmmount.text = "";
            quantity.text = "";
            ammoObject.SetActive(false);
        }
        else
        {
          
            cardName.text = card.cardName;
            ammosAmmount.text = card.ammos.ToString();
            quantity.text = card.quantity.ToString();
            if (image != null)
            {
                Color newColor = new Color(1, 1, 1, 1);
                image.color = newColor;
                image.sprite = card.image;
            }
            if (cardName.text == "Pistol" || cardName.text == "Shotgun" || cardName.text == "Revolver" || cardName.text == "Rifle")
            {
                ammoObject.SetActive(true);
                Debug.Log("ff");
            }
            else
            {
                ammoObject.SetActive(false);
            }
        }


    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
