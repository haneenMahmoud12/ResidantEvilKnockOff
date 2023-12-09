using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Card card;
    public Text cardName;
    public Text quantity;
    public Image image;
    public Button use;
    public Button equip;
    public Button discard;
    public Button combine;

    // Start is called before the first frame update
    void Start()
    {
        
        cardName.text = card.cardName;
        quantity.text = card.quantity.ToString();
        image.sprite = card.image;
        use = card.Use;
        equip = card.Equip;
        discard = card.Discard;
        combine = card.Combine;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
