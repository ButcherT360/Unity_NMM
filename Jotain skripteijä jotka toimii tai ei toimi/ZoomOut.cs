using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour {

    public Camera cam;
    [Range(-15f, 0f)]
    public float camDistance;

	void Start () {
        camDistance = 0;
	}
	
	
	void Update () {


        camDistance += Input.GetAxis("Mouse ScrollWheel");
        camDistance = Mathf.Clamp(camDistance, -10f, 0f);

        // instant firstperson
        if (Input.GetKeyDown(KeyCode.V))
            camDistance = 0f;
        //instant thirdperson
        else if (Input.GetKeyDown(KeyCode.B))
            camDistance = -30f;
        
        }

    void FixedUpdate()
    {

        cam.transform.localPosition = new Vector3(0, 0, camDistance);
    } 
}
