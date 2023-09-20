using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PANOSKET : MonoBehaviour {
    public Weapon ammo;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "It")
        {
            ammo.bulletsLeft += 16;
            Destroy(this.gameObject);
            ammo.UpdateAmmoText();
        }
    }
}
