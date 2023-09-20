using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class deathmenu1 : MonoBehaviour
{
    // Use this for initialization

   public Playerhealthcontroller health;

    void Start()
    {
       
    }
    public void lastlevel1()
    {
        SceneManager.LoadScene(2);
    }
    public void playerhealth()
    {
        if (health.playerhealth == 0)
        {
            Cursor.visible = true;
            SceneManager.LoadScene(8);
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerhealth();
    }
    private void FixedUpdate()
    {
        playerhealth();
    }
}