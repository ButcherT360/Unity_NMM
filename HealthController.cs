using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(AudioSource))]


public class HealthController : MonoBehaviour
{

    public Animator anime;
    //public Rigidbody rgbody;
    public float health;
   // public AudioSource aSource;
    //public AudioClip deathClip;

    private void Awake()
    {
        //aSource = GetComponent<AudioSource>();
    }

    public void ApplyDamage(float damage)

    {
        health -= damage;
    }

   // private void deathsound()
   // {
  //      aSource.PlayOneShot(deathClip);
  //  }
    private IEnumerator KillOnAnimationEnd()
    {
       // aSource.PlayOneShot(deathClip);
        yield return new WaitForSeconds(0.5f);        
        Destroy(transform.parent.gameObject);
        Destroy(transform.parent.parent.gameObject);
        Destroy(gameObject);
    }

    void Update()
    {
        if (health <= 0f)
        {
          
            StartCoroutine(KillOnAnimationEnd());      
            anime.Play("death");
           // deathsound();

        }

    }
}
