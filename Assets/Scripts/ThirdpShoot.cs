using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class ThirdpShoot : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask=new LayerMask();
  //  [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform vfxHitGreen;
    
    public string weapontag;
    //weapons 
    public GameObject Shotgun;
    public GameObject Rifle;
    public GameObject Revolver;
    public GameObject pistol;
    public GameObject knife;

    public Gun weapon;
    //public ParticleSystem hiteffect;

    //private Inventory inventory;
    //private EquipmentManager manager;
    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController;
    private Animator animator;
    public InventoryScript inventoryScript;
    public Grenades grenadesScript;
    public AudioSource OpenDoor;

    private void Awake()
    {
        starterAssetsInputs=GetComponent<StarterAssetsInputs>();
        thirdPersonController=GetComponent<ThirdPersonController>();
        animator=GetComponent<Animator>();
       // if (FindAnyObjectByType<Gun>()!=null)
       // weapon = FindAnyObjectByType<Gun>();
        

        // inventory = GetComponent<Inventory>();
        // manager = GetComponent<EquipmentManager>();

    }
   
    /*void Start()
    {
      
    }*/

    // Update is called once per frame
    void Update()
    {
        //if(inventoryScript.leonEquippedWeapon != "" && inventoryScript.leonEquippedGrenade == "" )
        //{
        //    animator.SetLayerWeight(1, 1f);
        //}
        //else
        //{
        //    animator.SetLayerWeight(1, 0f);
        //}
       
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryScript.OpenInventory();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            inventoryScript.GoldCheat();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            inventoryScript.HealCheat();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryScript.InvincibilityCheat();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (Time.timeScale == 1)
                Time.timeScale = 0.5f;
            else
                Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && inventoryScript.isActiveAndEnabled)
        {
            inventoryScript.CloseInventory();
        }

        weapontag = inventoryScript.leonEquippedWeapon;
        if (weapontag.Equals("Rifle"))
        {

            Shotgun.SetActive(false);
            Rifle.SetActive(true);
            pistol.SetActive(false);
            Revolver.SetActive(false);
            knife.SetActive(false);
            weapon = FindAnyObjectByType<Gun>();
        }
        if (weapontag.Equals("Shotgun"))
        {

            Shotgun.SetActive(true);
            Rifle.SetActive(false);
            pistol.SetActive(false);
            Revolver.SetActive(false);
            knife.SetActive(false);
            weapon = FindAnyObjectByType<Gun>();
        }
        if (weapontag.Equals("Revolver"))
        {

            Shotgun.SetActive(false);
            Rifle.SetActive(false);
            pistol.SetActive(false);
            Revolver.SetActive(true);
            knife.SetActive(false);
            weapon = FindAnyObjectByType<Gun>();
        }
        if (weapontag.Equals("Pistol"))
        {

            Shotgun.SetActive(false);
            Rifle.SetActive(false);
            pistol.SetActive(true);
            Revolver.SetActive(false);
            knife.SetActive(false);
            weapon = FindAnyObjectByType<Gun>();
        }

        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999999f, aimColliderLayerMask))
        {
            // debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;
        }



        //Aim
        if (starterAssetsInputs.aim && inventoryScript.leonEquippedWeapon != "" && inventoryScript.leonEquippedGrenade == "" &&!animator.GetBool("isGrappled"))
        {
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
            aimVirtualCamera.transform.forward = transform.forward;
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
       
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);
            animator.SetLayerWeight(1, 1f);

            
            
            PlayerInput pi = GetComponent<PlayerInput>();
            pi.actions.FindAction("Sprint").Disable();

            //Shoot
            //removed-> starterAssetsInputs.shoot
            if (Input.GetKeyDown(KeyCode.Mouse0) && !weapon.gunData.Automatic && inventoryScript.leonEquippedGrenade == "" )
            {

                weapon.Shoot();
                //if (weapon.CanShoot())
                //{
                //    Debug.Log("canshoot");
                //    if (Physics.Raycast(ray, out RaycastHit hitInfo, weapon.gunData.maxDistance, aimColliderLayerMask))
                //    {
                //        weapon.Shoot();
                //        hiteffect.transform.position = raycastHit.point;
                //        hiteffect.transform.forward = raycastHit.normal;
                //        hiteffect.Emit(1);
                //        Debug.Log(hitInfo.transform.name);
                //    }
                //    weapon.gunData.currentAmmo--;
                //    weapon.timeSinceLastShot = 0;
                //    weapon.timeSinceLastShot += Time.deltaTime;
                //    //  weapon.OnGunShot();
                //}
                //if (hitTransform != null)
                //{
                //    if (hitTransform.GetComponent<BulletTarget>() != null)
                //    {
                //        Instantiate(vfxHitGreen, hitTransform.position, Quaternion.identity);
                //    }
                //    else
                //    {
                //        Instantiate(vfxHitRed, hitTransform.position, Quaternion.identity);
                //    }
                //}

                starterAssetsInputs.shoot = false;


            }
            // while (Input.GetKey(KeyCode.Mouse0) && weapon.gunData.Automatic)

            if ((Input.GetKey(KeyCode.Mouse0) && weapon.gunData.Automatic))
            {

                // Space key is being held down
                weapon.ShootAuto();


            }



        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);
            animator.SetLayerWeight(1, 0f);
            PlayerInput pi = GetComponent<PlayerInput>();
            pi.actions.FindAction("Sprint").Enable();

        }



        if (starterAssetsInputs.reload)
        {
            if (inventoryScript.ReloadWeapon())
            {
                weapon.StartReload();
            }
        }

    }
    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Door") && Input.GetKey(KeyCode.E))
        {
            Animator dooranim = other.GetComponent<Animator>();
            dooranim.SetBool("unlock", true);
            OpenDoor.Play();
        }
        if (other.CompareTag("DoorDiamond") && Input.GetKey(KeyCode.E))
        {
            if (inventoryScript.DiamondKeyFound())
            {
                Animator dooranim = other.GetComponent<Animator>();
                dooranim.SetBool("unlock", true);
                OpenDoor.Play();
            }
            else
            {
                Debug.Log("DOOR CANNOT OPEN WITHOUT KEY");
            }

        }
        if (other.CompareTag("DoorSpade") && Input.GetKey(KeyCode.E))
        {
            if (inventoryScript.SpadeKeyFound())
            {
                Animator dooranim = other.GetComponent<Animator>();
                dooranim.SetBool("unlock", true);
                OpenDoor.Play();
            }
            else
            {
                Debug.Log(" spadeDOOR CANNOT OPEN WITHOUT KEY");
            }


        }

        if (other.CompareTag("DoorKeyCard") && Input.GetKey(KeyCode.E))
        {
            if (inventoryScript.KeycardFound())
            {
                Animator dooranim = other.GetComponent<Animator>();
                dooranim.SetBool("unlock", true);
                OpenDoor.Play();
            }
            else
            {
                Debug.Log(" DoorKeyCard CANNOT OPEN WITHOUT KEY");
            }


        }
        if (other.CompareTag("DoorEmblem") && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Emblem");
            if (inventoryScript.EmblemFound())
            {
                Animator dooranim = other.GetComponent<Animator>();
                dooranim.SetBool("unlock", true);
                OpenDoor.Play();
                Debug.Log("Congrats u escaped the zombies");
            }
            else
            {
                Debug.Log(" Emblem CANNOT OPEN WITHOUT KEY");
            }


        }
    }

}
