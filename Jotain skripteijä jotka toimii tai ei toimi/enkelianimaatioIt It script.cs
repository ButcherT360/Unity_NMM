using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public Animator anim;
    public Rigidbody rbody;

    private float inputH;
    private float inputV;
    private bool run;
    // Use this for initialization
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rbody = GetComponent<Rigidbody>();
        run = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            anim.Play("Potku", -1, 0f);
        }
        if (Input.GetKeyDown("2"))
        {
            anim.Play("Jump", -1, 0f);
        }
        if (Input.GetKeyDown("3"))
        {
            anim.Play("Walk", -1, 0f);
        }
        if (Input.GetKeyDown("4"))
        {
            anim.Play("weev", -1, 0f);
        }
        if (Input.GetMouseButtonDown(0))
        {
            int n = Random.Range(0, 2);
            if (n == 0)
            {
                anim.Play("damaged");
            }
            else
            {
                anim.Play("falldown", -1, 0f);
            }
            if (Input.GetMouseButtonDown(1))
            {
                anim.Play("falldown", -1, 0f);
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
        }
        else
        {
            run = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetBool("jump", false);
        }

            inputH = Input.GetAxisRaw("Horizontal");
            inputV = Input.GetAxisRaw("Vertical");

            anim.SetFloat("inputH", inputH);
            anim.SetFloat("inputV", inputV);
            anim.SetBool("run", run);

        float moveX = inputH * 20f * Time.deltaTime;
        float moveZ = inputV * 50f * Time.deltaTime;
        if(moveZ <= 0f)
        {
            moveX = 0f;
        }
        else if (run)
        {
            moveX *= 3f;
            moveZ *= 3f;
        }
        rbody.velocity = new Vector3(moveX, 0f, moveZ);
        }
    }
