using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class deathmenu3 : MonoBehaviour {
    // Use this for initialization

    public  Playerhealthcontroller health;

    void Start () {
		
	}
    public void lastlevel3()
    {
           SceneManager.LoadScene(6);       
    }
    public void playerhealth()
    {
        if (health.playerhealth == 0)
        {
            SceneManager.LoadScene(14);
        }
    }
    // Update is called once per frame
    void Update () {
        playerhealth();
    }
    private void FixedUpdate()
    {
        playerhealth();
    }
}

