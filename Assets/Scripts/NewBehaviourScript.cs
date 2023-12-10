using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public Card card;
    public TMP_Text cardName;
    public TMP_Text quantity;
    public Image image;
    public Button use;
    public Button equip;
    public Button discard;
    public Button combine;

    // Start is called before the first frame update
    void Start()
    {
        
     if(card != null)
        {
            Initialize();
        }
      
        
    }

    private void Initialize()
    {
        cardName.text = card.cardName;
        quantity.text = card.quantity.ToString();
        Color newColor = new Color(1, 1, 1, 0);
        image.color = newColor;
        image.sprite = card.image;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
