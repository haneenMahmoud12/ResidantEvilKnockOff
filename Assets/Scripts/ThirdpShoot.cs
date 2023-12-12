using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;

public class ThirdpShoot : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask=new LayerMask();
  //  [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;
    
    public Gun weapon;
    public ParticleSystem hiteffect;

    //private Inventory inventory;
    //private EquipmentManager manager;
    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController;
    private Animator animator;

    private void Awake()
    {
        starterAssetsInputs=GetComponent<StarterAssetsInputs>();
        thirdPersonController=GetComponent<ThirdPersonController>();
        animator=GetComponent<Animator>();
        if (FindAnyObjectByType<Gun>()!=null)
        weapon = FindAnyObjectByType<Gun>();


        // inventory = GetComponent<Inventory>();
        // manager = GetComponent<EquipmentManager>();

    }
   
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
           // debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;
        }



        //Aim

        if (starterAssetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);
            animator.SetLayerWeight(1, 1f);

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
            PlayerInput pi = GetComponent<PlayerInput>();
            pi.actions.FindAction("Sprint").Disable();

            //Shoot

            if (starterAssetsInputs.shoot && !weapon.gunData.Automatic)
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
            if (Input.GetKey(KeyCode.B) && weapon.gunData.Automatic)
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



      
        


    }
}
