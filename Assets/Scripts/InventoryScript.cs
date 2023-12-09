using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    [SerializeField] List<GameObject> inventory;
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
    
    // Start is called before the first frame update
    void Start()
    {
     
    }
    private void Update()
    {
        if (inventory != null)
        {
            inventory[0].transform.GetChild(7).gameObject.SetActive(false);
        }
        
    }
    public void CheckCardType()
    {
        if(inventory != null)
        {
            for(int i=0; i<inventory.Count; i++)
            {
                NewBehaviourScript script = inventory[i].GetComponent<NewBehaviourScript>();
                if(script.cardName.ToString()=="Green Herb"|| script.cardName.ToString()=="Red Herb"|| 
                    script.cardName.ToString() == "Green + Green Mixture" || script.cardName.ToString() == "Green + Red Mixture"||
                    script.cardName.ToString() == "Red + Red Mixture")
                {
                    inventory[i].transform.GetChild(4).gameObject.SetActive(true);
                }
                else
                {
                    inventory[i].transform.GetChild(4).gameObject.SetActive(false);
                }


                if (script.cardName.ToString() == "Green Herb" || script.cardName.ToString() == "Red Herb" )
                {
                    inventory[i].transform.GetChild(6).gameObject.SetActive(true);
                }
                else
                {
                    inventory[i].transform.GetChild(6).gameObject.SetActive(false);
                }

                if (script.cardName.ToString() == "Rifle" || script.cardName.ToString() == "Shotgun" ||
                    script.cardName.ToString() == "Revolver" || script.cardName.ToString() == "Pistol" ||
                    script.cardName.ToString() == "Hand Gerande" || script.cardName.ToString() == "Flash Gerande")
                {
                    inventory[i].transform.GetChild(7).gameObject.SetActive(true);
                }
                else
                {
                    inventory[i].transform.GetChild(7).gameObject.SetActive(false);
                }

                if (script.cardName.ToString() == "Rifle" || script.cardName.ToString() == "Shotgun" ||
                    script.cardName.ToString() == "Revolver" || script.cardName.ToString() == "Pistol"||
                    script.cardName.ToString() == "Key Card" || script.cardName.ToString() == "Emblem" ||
                    script.cardName.ToString() == "Spade Key" || script.cardName.ToString() == "Diamond Key" ||
                    script.cardName.ToString() == "Heart Key" || script.cardName.ToString() == "Club Key" )
                {
                    inventory[i].transform.GetChild(5).gameObject.SetActive(false);
                }
                else
                {
                    inventory[i].transform.GetChild(5).gameObject.SetActive(true);
                }
            }
        }
    }
}
