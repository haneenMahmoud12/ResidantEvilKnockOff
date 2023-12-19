using Cinemachine;
using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Gun : MonoBehaviour
{

    [Header("References")]
    [SerializeField] public GunData gunData;
    public ParticleSystem muzleFlash;
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    public Transform pfBullet;
    public Transform SpawnBullet;
    public InventoryScript inventoryScript;
    public Animator animator;
    public TMP_Text t;
    // [SerializeField] private Transform debugTransform;

    //[SerializeField] private Transform cam;




    public float timeSinceLastShot;

    private void Start()
    {
        t.text = inventoryScript.GetAmmoCount();
        gunData.reloading = false;

    }

    private void Awake()
    {
        
    }

    public void OnDisable() => gunData.reloading = false;

    public void StartReload()
    {
        if (!gunData.reloading && this.gameObject.activeSelf)
            StartCoroutine(Reload());
    }

    public IEnumerator Reload()
    {
        gunData.reloading = true;
        animator.SetBool("reload", true);
        yield return new WaitForSeconds(gunData.reloadTime);

      


        gunData.reloading = false;
    }

    public bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);

    public void Shoot()
    {

        if (CanShoot())
        {
            if (inventoryScript.FireWeapon())
            {
                t.text = inventoryScript.GetAmmoCount();

                muzleFlash.Emit(1);

                // Debug.Log("canshoot");
                //Transform hitTransform = null;
                Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
                Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
                if (Physics.Raycast(ray, out RaycastHit hitInfo, gunData.maxDistance, aimColliderLayerMask))
                {  // debugTransform.position = hitInfo.point;
                   // hitTransform = hitInfo.transform;
                   // ray.origin = hitInfo.point;
                   //  Debug.DrawLine(ray.origin, hitInfo.point,Color.red,2.0f);
                  //  Instantiate(vfxHitGreen, hitInfo.point, Quaternion.identity);
                    //EnemyStats enemy = hitInfo.transform.GetComponent<EnemyStats>();
                    //if (enemy != null)
                    //    Debug.Log("hi" + enemy.tag);
                    //EnemyStats enemy1 = hitInfo.collider.transform.GetComponent<EnemyStats>();
                    //if (enemy1 != null)
                    //    Debug.Log("hello" + enemy1.tag);
                    Vector3 aimDir = (hitInfo.point - SpawnBullet.position).normalized;

                    Instantiate(pfBullet, SpawnBullet.position, Quaternion.LookRotation(aimDir, Vector3.up));
                    BulletProjectile bullet = pfBullet.GetComponent<BulletProjectile>();

                    bullet.damage = gunData.damage;
                    bullet.speed = gunData.maxDistance;

                    // string hitTag = hitInfo.collider.gameObject.tag;
                    // Debug.Log(hitTag);
                    // Debug.Log(hitInfo.transform.tag);
                    // var hitBox=hitInfo.collider.GetComponent<EnemyStats>();
                    // if (hitBox != null)
                    {
                        // Debug.Log(hitBox.transform.tag);
                        //    hitBox.TakeDamage(gunData.damage);
                    }
                    // EnemyStats enemy = hitInfo.transform.GetComponent<EnemyStats>();
                    //  if(enemy != null) {
                    //    Debug.Log("GI");
                    //  Debug.Log(enemy.transform.tag);
                    //   enemy.TakeDamage(gunData.damage);

                    // }
                    // if (hitTransform.GetComponent<EnemyStats>() != null)
                    {
                        //        Debug.Log("k");
                    }
                }
                // gunData.currentAmmo--;
                timeSinceLastShot = 0;
                // Debug.Log(gunData.currentAmmo);

                //  weapon.OnGunShot();
            }
        }
    }
        public void ShootAuto()
        {

        if (CanShoot())
        {
            if (inventoryScript.FireWeapon())
            {
                muzleFlash.Emit(1);
                t.text = inventoryScript.GetAmmoCount();
                // Debug.Log("canshoot");
                //Transform hitTransform = null;
                Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
                Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
                if (Physics.Raycast(ray, out RaycastHit hitInfo, gunData.maxDistance, aimColliderLayerMask))
                {  // debugTransform.position = hitInfo.point;
                   // hitTransform = hitInfo.transform;
                   // ray.origin = hitInfo.point;
                   //  Debug.DrawLine(ray.origin, hitInfo.point,Color.red,2.0f);
                   // Instantiate(vfxHitGreen, hitInfo.point, Quaternion.identity);
                    //EnemyStats enemy = hitInfo.transform.GetComponent<EnemyStats>();
                    //if (enemy != null)
                    //    Debug.Log("hi" + enemy.tag);
                    //EnemyStats enemy1 = hitInfo.collider.transform.GetComponent<EnemyStats>();
                    //if (enemy1 != null)
                    //    Debug.Log("hello" + enemy1.tag);
                    Vector3 aimDir = (hitInfo.point - SpawnBullet.position).normalized;

                    Instantiate(pfBullet, SpawnBullet.position, Quaternion.LookRotation(aimDir, Vector3.up));
                    BulletProjectile bullet = pfBullet.GetComponent<BulletProjectile>();

                    bullet.damage = gunData.damage;
                    bullet.speed = gunData.maxDistance;

                    // string hitTag = hitInfo.collider.gameObject.tag;
                    // Debug.Log(hitTag);
                    // Debug.Log(hitInfo.transform.tag);
                    // var hitBox=hitInfo.collider.GetComponent<EnemyStats>();
                    // if (hitBox != null)
                    {
                        // Debug.Log(hitBox.transform.tag);
                        //    hitBox.TakeDamage(gunData.damage);
                    }
                    // EnemyStats enemy = hitInfo.transform.GetComponent<EnemyStats>();
                    //  if(enemy != null) {
                    //    Debug.Log("GI");
                    //  Debug.Log(enemy.transform.tag);
                    //   enemy.TakeDamage(gunData.damage);

                    // }
                    // if (hitTransform.GetComponent<EnemyStats>() != null)
                    {
                        //        Debug.Log("k");
                    }
                }
                // gunData.currentAmmo--;
                timeSinceLastShot = 0;
                // Debug.Log(gunData.currentAmmo);

                //  weapon.OnGunShot();
            }
        }
        }



    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        
        // Debug.DrawRay(cam.position, cam.forward * gunData.maxDistance);
        //Vector3 mouseWorldPosition = Vector3.zero;
        //Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        //Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        //Transform hitTransform = null;
        //if (Physics.Raycast(ray, out RaycastHit raycastHit, gunData.maxDistance, aimColliderLayerMask))
        //{
        //    debugTransform.position = raycastHit.point;
        //    mouseWorldPosition = raycastHit.point;
        //    hitTransform = raycastHit.transform;
        //}







        ////Shoot
        //if (starterAssetsInputs.shoot)
        //{
        //    if (gunData.currentAmmo > 0)
        //    {
        //        if (CanShoot())
        //        {
        //            if (hitTransform != null)
        //            {
        //                if (hitTransform.GetComponent<BulletTarget>() != null)
        //                {
        //                    Instantiate(vfxHitGreen, transform.position,Quaternion.identity);
        //                }
        //                else
        //                {
        //                    Instantiate(vfxHitRed, transform.position, Quaternion.identity);
        //                }
        //            }

        //        //if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hitInfo, gunData.maxDistance))
        //        //{
        //        //  //  IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
        //        //  //  damageable?.TakeDamage(gunData.damage);
        //        //}

        //        gunData.currentAmmo--;
        //            timeSinceLastShot = 0;
        //            OnGunShot();
        //        }
        //    }
        //    starterAssetsInputs.shoot = false;
        //}

        //Reload
        //if (starterAssetsInputs.reload)
        //{
        //    StartReload();
        //}


    }

    public void OnGunShot() { }
}