using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour {

    GameObject prefab;
    public Vector3 Distance;
    public bool IsAttacking = false;
    public Rigidbody projectile;
    public Transform SpawnPoint;
    public float DistanceFrom;
    public Transform Player;
    public Transform enemy;
    public float fireRate;
    public float nextFire;
    public float lifetime;
    void Start () {
        prefab = Resources.Load("HomingMissile") as GameObject;
	}
    public void Update ()
    {
        Distance = (enemy.position - Player.position);
        Distance.y = 0;
        DistanceFrom = Distance.magnitude;
        Distance/=DistanceFrom;

        if (DistanceFrom < 200)
        {
            IsAttacking = true;
        }
        else
        {
            IsAttacking = false;
        }
    } 

    public void Attacking()
    {
        if (IsAttacking)
        {
            enemy.LookAt(Player);
            if(Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;

                Rigidbody HomingMissile = Instantiate(projectile,SpawnPoint.position,SpawnPoint.rotation);
              //  HomingMissile.transform.position = transform.position + Camera.main.transform.forward * 2;
             //   Rigidbody rb = HomingMissile.GetComponent<Rigidbody>();
                HomingMissile.velocity = enemy.transform.forward * 200                   ;
            }
        }
    }
	}
