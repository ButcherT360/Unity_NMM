using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerhealthcontroller : MonoBehaviour
{

    private GameObject[] Player;
    [SerializeField]
    public float playerhealth = 100f;

    public void ApplyDamage(float damage)
    {
        playerhealth -= damage;
    }

    private void Update()
    {

        if (playerhealth <= 0f)
        {
            //health = 0f;
            Player = GameObject.FindGameObjectsWithTag("Player");
            Destroy(gameObject);
        }
    }
}

