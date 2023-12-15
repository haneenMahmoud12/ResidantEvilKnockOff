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
    public int sellPrice;
    public int buyPrice;
    public int capacityAmmo;
    public bool canSell = false;
    public int ammos;


    

}
