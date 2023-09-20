using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class winthegamesript : MonoBehaviour {

    public Text WinText;
    public GameObject boss;
    public GameObject wall;
    public GameObject spawnmorenemies;
    //public Slider slider1;
   // public Slider slider2;
	// Use this for initialization
	void Start () {
		
	}
    void nextlevel()
    {
        if (GameObject.FindWithTag("Enemy") == null){
            Cursor.visible = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    // Update is called once per frame
    void Update()
    {
        //look.lookSpeed = slider1.value;
       // look.RotSpeed = slider2.value;
        if (GameObject.FindWithTag("Enemy1") == null)
        {
            //trigger wall removeval and activate boss
            wall.gameObject.SetActive(false);
            spawnmorenemies.gameObject.SetActive(true);
            boss.gameObject.SetActive(true);
        }
    }
            private IEnumerator KillOnAnimationEnd()
    {
        yield return new WaitForSeconds(2f);
    }
    private void FixedUpdate()
    {

        if (GameObject.FindWithTag("Enemy") == null)
        
            WinText.gameObject.SetActive(true);
        StartCoroutine(KillOnAnimationEnd());
        
        nextlevel();


        WinText.text = "You Won! Press esc to go to mainmenu";
        
    }
}