using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New Card", menuName ="Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public int quantity;
    public Sprite image;
    public Button Use;
    public Button Equip;
    public Button Combine;
    public Button Discard;

    

}
