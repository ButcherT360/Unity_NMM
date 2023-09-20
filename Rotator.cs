using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
    public float X = 15;
        public float Y = 30;
    public float Z = 45;

    void Update()
    {
        transform.Rotate(new Vector3(X, Y, Z) * Time.deltaTime);
    }
}