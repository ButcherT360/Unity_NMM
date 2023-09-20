using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime1 : MonoBehaviour {

    public float lifetime;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
