using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class briefmenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
