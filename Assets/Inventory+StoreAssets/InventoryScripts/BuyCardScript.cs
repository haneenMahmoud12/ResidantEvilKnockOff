using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyCardScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Card card;
    public TMP_Text cardName;
    public TMP_Text buyPrice;
    public Image image;
    public TMP_Text quantity;


    void Start()
    {

        if (card != null)
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
        }
        else
        {

            cardName.text = card.cardName;
            buyPrice.text = card.buyPrice.ToString();
            quantity.text = card.quantity.ToString();

            Color newColor = new Color(1, 1, 1, 1);
            image.color = newColor;
            image.sprite = card.image;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
