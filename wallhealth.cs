using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallhealth : MonoBehaviour
{

    [SerializeField]
    float Wallhealth = 100f;
    public void ApplyDamageToWall(float damage)
    {
        Wallhealth -= damage;


        if (Wallhealth <= 0f)
        {
            //health = 0f;
            Destroy(gameObject);
        }
    }
}
