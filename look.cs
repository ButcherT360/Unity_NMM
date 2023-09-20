using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class look : MonoBehaviour
{

    //Kameran pysäytys ettei se mene ympäri hahmon.
    public static float lookSpeed = 5f;
    public static float RotSpeed = 500.0F;
    public float camDistance;
    public float minY = -50.0f;
    public float maxY = 50.0f;
   // public Slider slider;
   // public Slider slider2;

    Vector3 euler;
    float RotLeftRight;
    float RotUpDown;

    void Start()
    {

    }


    void Update()
    {

        camDistance = -2;
        transform.localEulerAngles = euler;
        RotLeftRight = Input.GetAxis("Mouse X") * RotSpeed * Time.deltaTime;
        RotUpDown = Input.GetAxis("Mouse Y") * lookSpeed;

        camDistance += Input.GetAxis("Mouse ScrollWheel");
        camDistance = Mathf.Clamp(camDistance, -5f, 0f);
      //  lookSpeed = slider.value;
      //  RotSpeed = slider2.value;
        euler.y += RotLeftRight;

        euler.x -= RotUpDown;

        if (euler.x >= maxY)
            euler.x = maxY;

        if (euler.x <= minY)
            euler.x = minY;
    }
}







