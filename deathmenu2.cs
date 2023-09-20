using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class deathmenu2 : MonoBehaviour {
    // Use this for initialization

    public Playerhealthcontroller health;

    void Start () {
		
	}
    public void lastlevel2()
    {
           SceneManager.LoadScene(4);       
    }
    public void playerhealth()
    {
        if (health.playerhealth == 0)
        {
            Cursor.visible = true;
            SceneManager.LoadScene(9);
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

