using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class deathmenu5 : MonoBehaviour {
    // Use this for initialization

    public Playerhealthcontroller health;

    void Start () {
		
	}
    public void lastlevel5()
    {
           SceneManager.LoadScene(10);       
    }
    public void playerhealth()
    {
        if (health.playerhealth == 0)
        {
            SceneManager.LoadScene(16);
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

