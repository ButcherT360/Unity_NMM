using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    private float damage = 10;
    private Camera cam;
    public GameObject hitparticle;
    GameObject prefab;
    // Use this for initialization
    void Start()
    {
        prefab = Resources.Load("projectile") as GameObject;
        cam = GetComponentInChildren<Camera>();
        Debug.Log(cam);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject projectile = Instantiate(prefab) as GameObject;
            projectile.transform.position = transform.position + Camera.main.transform.forward * 2;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = Camera.main.transform.forward * 40;
            shoot();
        }
    }
    void shoot()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            MakeParticle(hit.point);
            if (hit.collider.CompareTag("Player"))
            {
                hit.collider.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
        }
    }
    void MakeParticle(Vector3 origin)
    {
        Instantiate(hitparticle, origin, Quaternion.identity);
    }
}