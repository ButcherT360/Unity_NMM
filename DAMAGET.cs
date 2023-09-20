using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DAMAGET : MonoBehaviour
{
    public Playerhealthcontroller heal;
    public HealthController heale;
    private void OnTriggerEnter(Collider collider)

    {

        if (collider.gameObject.name == "It")
        {
            heal.playerhealth -= 10;
        }



        if (collider.gameObject.tag == "Enemy")
        {
            heale.health -= 25;
        }
    }


            public void destroy()
    {

        if (heal.playerhealth == 0f)
        {
            //health = 0f;
            Destroy(this.gameObject);
        }
    }
}
