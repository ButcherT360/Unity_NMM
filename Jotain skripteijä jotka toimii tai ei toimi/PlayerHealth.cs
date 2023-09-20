using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float maxHealth;
    private float currentHealth;
	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}
	
    public void TakeDamage (float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }
	// Update is called once per frame
	void Die () {
        Destroy(gameObject);
	}
}
