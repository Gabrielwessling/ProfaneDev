using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public int ammoActual = 10;
    public int ammoMax = 10;

    public float timePerShot;
    float timePerShotIndex;
    bool isShooting = false;

    public bool isAutomatic;

    public GameObject fpsControl;
    public GameObject camcam;
    public Camera cam;

    public float reloadTime = 10;
    float reloadingTime;

    public bool rifleAmmo;
    public bool pistolAmmo;
    public bool heavyAmmo;
    public bool shotgunShell;

    bool isReloading;

    void Awake()
    {
        camcam = GameObject.FindGameObjectWithTag("CameraGun");
        fpsControl = GameObject.FindGameObjectWithTag("Player");
        cam = camcam.GetComponent<Camera>();
    }

    void Start()
    {
        timePerShotIndex = timePerShot;
    }

    void Update()
    {
        #region Selecionador de munição código feio pra caralho
        if (pistolAmmo)
        {
            rifleAmmo = false;
            heavyAmmo = false;
            shotgunShell = false;
        }
        if (rifleAmmo)
        {
            pistolAmmo = false;
            heavyAmmo = false;
            shotgunShell = false;
        }
        if (heavyAmmo)
        {
            pistolAmmo = false;
            rifleAmmo = false;
            shotgunShell = false;
        }
        if (shotgunShell)
        {
            pistolAmmo = false;
            heavyAmmo = false;
            rifleAmmo = false;
        }
        #endregion

        if (timePerShot <= 0)
        {
            isShooting = false;
            timePerShot = timePerShotIndex;
        }
        if (isShooting && timePerShot > 0)
        {
            timePerShot -= 1 * Time.deltaTime;
        }
        fpsControl.GetComponent<FPSControl>().actualAmmo = ammoActual;

        if (Input.GetButtonDown("Reload") && !isReloading)
        {
            ReloadGun();
        }

        if (isReloading)
        {
            reloadingTime += 1 * Time.deltaTime;
        }
        if (reloadingTime >= reloadTime)
        {
            ReloadGun();
        }

        fpsControl.GetComponent<FPSControl>().reloadTime = reloadingTime;
        fpsControl.GetComponent<FPSControl>().maxReloadTime = reloadTime;

        if (isAutomatic)
        {
            if (Input.GetButton("Fire1") && fpsControl.GetComponent<FPSControl>().canShoot)
            {
                if (ammoActual > 0 && !isShooting)
                {
                    ammoActual -= 1;
                    Shoot();
                }
                else
                {
                    if (ammoActual == 0)
                    {
                        ReloadGun();
                    }
                }
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && fpsControl.GetComponent<FPSControl>().canShoot)
            {
                if (ammoActual > 0 && !isShooting)
                {
                    ammoActual -= 1;
                    Shoot();
                }
                else
                {
                    if (ammoActual == 0)
                    {
                        ReloadGun();
                    }
                }
            }
        }
    }

    void Shoot()
    {
        isShooting = true;
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            if (target.healthActual > 0)
            {
                Debug.Log(hit.transform.name + ", "+ target.healthActual + " Health Remaining");
            }
            else
            {
                Debug.Log(hit.transform.name + " is dead as fuck, congratulations motherfucker");
            }
        }

    }
    void ReloadGun()
    {
        if (reloadingTime < reloadTime)
        {
            isReloading = true;
            fpsControl.GetComponent<FPSControl>().reloadSlider.gameObject.SetActive(true);
        }
        else
        {
            #region Munições

            #region Rifle
            if (rifleAmmo)
            {
                if (fpsControl.GetComponent<FPSControl>().rifleAmmo >= ammoMax - ammoActual)
                {
                    fpsControl.GetComponent<FPSControl>().rifleAmmo -= ammoMax - ammoActual;
                    ammoActual = ammoMax;
                }
                else
                {
                    ammoActual += fpsControl.GetComponent<FPSControl>().rifleAmmo; ;
                    fpsControl.GetComponent<FPSControl>().rifleAmmo = 0;
                }
                isReloading = false;
                reloadingTime = 0;
                fpsControl.GetComponent<FPSControl>().reloadSlider.gameObject.SetActive(false);
            }
            #endregion
            #region Pistol
            if (pistolAmmo)
            {
                if (fpsControl.GetComponent<FPSControl>().pistolAmmo >= ammoMax - ammoActual)
                {
                    fpsControl.GetComponent<FPSControl>().pistolAmmo -= ammoMax - ammoActual;
                    ammoActual = ammoMax;
                }
                else
                {
                    ammoActual += fpsControl.GetComponent<FPSControl>().pistolAmmo; ;
                    fpsControl.GetComponent<FPSControl>().pistolAmmo = 0;
                }
                isReloading = false;
                reloadingTime = 0;
                fpsControl.GetComponent<FPSControl>().reloadSlider.gameObject.SetActive(false);
            }
            #endregion
            #region Heavy
            if (heavyAmmo)
            {
                if (fpsControl.GetComponent<FPSControl>().heavyAmmo >= ammoMax - ammoActual)
                {
                    fpsControl.GetComponent<FPSControl>().heavyAmmo -= ammoMax - ammoActual;
                    ammoActual = ammoMax;
                }
                else
                {
                    ammoActual += fpsControl.GetComponent<FPSControl>().heavyAmmo; ;
                    fpsControl.GetComponent<FPSControl>().heavyAmmo = 0;
                }
                isReloading = false;
                reloadingTime = 0;
                fpsControl.GetComponent<FPSControl>().reloadSlider.gameObject.SetActive(false);
            }
            #endregion
            #region Shotgun
            if (shotgunShell)
            {
                if (fpsControl.GetComponent<FPSControl>().shotgunShell >= ammoMax - ammoActual)
                {
                    fpsControl.GetComponent<FPSControl>().shotgunShell -= ammoMax - ammoActual;
                    ammoActual = ammoMax;
                }
                else
                {
                    ammoActual += fpsControl.GetComponent<FPSControl>().shotgunShell; ;
                    fpsControl.GetComponent<FPSControl>().shotgunShell = 0;
                }
                isReloading = false;
                reloadingTime = 0;
                fpsControl.GetComponent<FPSControl>().reloadSlider.gameObject.SetActive(false);
            }
            #endregion

            #endregion
        }
    }

}
