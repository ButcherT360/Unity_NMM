using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Weapon : MonoBehaviour {

    private Animator anim;

    private AudioSource _AudioSource;

    public float range = 100f;    //max range for weapon
    public int bulletsPerMag = 30; // bullets per magazine
    public int bulletsLeft; // total bullets we have
    public int pickup = 30;

    public int currentBullets; // the current bullets in our magazine

    public enum ShootMode { Auto, Semi }
    public ShootMode shootingMode;

    public Text ammoText;
    public Transform shootPoint; //point where bullets leave
    public GameObject hitParticles;
    public GameObject bulletImpact;
    public GameObject bloodsplatter;

    public ParticleSystem muzzleFlash; // Muzzle flash
    public ParticleSystem GunSmoke; // Muzzle flash
    public AudioClip shootSound; 
    

    public float fireRate = 0.1f; // delay each shot
    public float damage = 20f;


    float fireTimer; //time counter for delay

    private bool isReloading;
    private bool shootInput;

    //  public Vector3 originalPosition;
    //  public Vector3 aimPosition;
    // public float adsSpeed = 8f;

    private void OnEnable()
    {
        // Update when active state is changed
        UpdateAmmoText(); //update ammo text
    }

    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();
        _AudioSource = GetComponent<AudioSource>();
        currentBullets = bulletsPerMag;
        bulletsLeft = 0;

        UpdateAmmoText(); //update ammo text
  //    originalPosition = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {

        switch (shootingMode)
        {
            case ShootMode.Auto:
                shootInput = Input.GetButton("Fire1");
            break;
                
            case ShootMode.Semi:
                shootInput = Input.GetButtonDown("Fire1");
                break;
        }
      
        if (shootingMode == ShootMode.Auto && Input.GetKeyDown(KeyCode.X))
            shootingMode = ShootMode.Semi;
        else { if (shootingMode == ShootMode.Semi && Input.GetKeyDown(KeyCode.X))
                shootingMode = ShootMode.Auto;

        
        // if (shootingMode == ShootMode.Semi && Input.GetKeyDown(KeyCode.X))
                //shootingMode = ShootMode.Auto;
           
        }

        if (shootInput)
        {
            if (currentBullets > 0)
                Fire(); // Execure fire function if pressing left mouse button
            else if(bulletsLeft > 0)
                DoReload();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if(currentBullets < bulletsPerMag && bulletsLeft > 0)
            DoReload();
        }
           


        if (fireTimer < fireRate)
            fireTimer += Time.deltaTime; //add into firetimer

       // AimDownSights();
	}

        void FixedUpdate()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);

        isReloading = info.IsName("Reload");
       // if (info.IsName("shoot")) anim.SetBool("Fire", false);
    }

    /*private void AimDownSights()
    {
        if (Input.GetButton("Fire2")&& !isReloading)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, aimPosition, Time.deltaTime * adsSpeed);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, Time.deltaTime * adsSpeed);
        }
    }*/

    private void Fire()
    {
        if (fireTimer < fireRate || currentBullets <=0 || isReloading)
            return;
        
        RaycastHit hit;

        if(Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name + " found!");

            GameObject hitParticleEffect = Instantiate(hitParticles, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            hitParticleEffect.transform.SetParent(hit.transform);
            GameObject bulletHole = Instantiate(bulletImpact, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
            bulletHole.transform.SetParent(hit.transform);
            Destroy(hitParticleEffect, 1f);
            Destroy(bulletHole, 2f);

            if (hit.transform.tag == "Enemy")
            {
                GameObject blood = Instantiate(bloodsplatter, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                bulletHole.transform.SetParent(hit.transform);
                Destroy(blood, 1f);
           }

            if (hit.transform.GetComponent<HealthController>())
            {
                hit.transform.GetComponent<HealthController>().ApplyDamage(damage);
            }

        }

        anim.CrossFadeInFixedTime("shoot", 0.01f);
        //anim.SetBool("Fire" , true);

        muzzleFlash.Play(); //välähtys piipusta
        GunSmoke.Play(); // savua
        PlayShootSound(); //pumpum ääni

        currentBullets--;

        UpdateAmmoText(); //update ammo text

        fireTimer = 0.0f; // Reset fire timer
    }




    public void Reload()
    {
        if (bulletsLeft <= 0) return;
        
        int bulletsToLoad = bulletsPerMag - currentBullets;
        //                              IF                   then      1st   else   2nd
        int bulletsToDeduct = (bulletsLeft >= bulletsToLoad) ? bulletsToLoad : bulletsLeft;

        bulletsLeft -= bulletsToDeduct;
        currentBullets += bulletsToDeduct;

        UpdateAmmoText(); //update ammo text

    }
    private void DoReload()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);

        if (isReloading) return;
        anim.CrossFadeInFixedTime("Reload", 0.01f);

    }

    private void PlayShootSound()
    {
        _AudioSource.PlayOneShot(shootSound);
       // _AudioSource.clip = shootSound;
      //  _AudioSource.Play();
    }

    public void UpdateAmmoText()
    {
        ammoText.text = currentBullets + " / " + bulletsLeft;
       }


    }
