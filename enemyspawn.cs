﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawn : MonoBehaviour
{
    public Playerhealthcontroller playerHealth;      
    public GameObject enemy;               
    public float spawnTime = 6f;            
    public Transform[] spawnPoints;         


    void Start()
    {      
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {       
        if (playerHealth.playerhealth <= 0f)
        {
       
            return;
        }
      
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
     
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}