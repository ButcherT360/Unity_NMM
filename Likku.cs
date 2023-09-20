using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Likku : MonoBehaviour {

    //liikkumis scripti

    public float walkSpeed;
    public float lookSpeed;
    public float gravity = 50.0F;
    public float jumpSpeed = 10F;

    private Rigidbody rb;
    private Camera cam;
    private Vector3 moveDirection = Vector3.zero;
    private float h;
    private float v;
    private float mh;
    private float mv;
    public float shift;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal") * walkSpeed * Time.deltaTime;
        v = Input.GetAxisRaw("Vertical") * walkSpeed * Time.deltaTime;
        mh = Input.GetAxis("Mouse X") * lookSpeed;
        mv = Input.GetAxis("Mouse Y") * lookSpeed;
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= walkSpeed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        //nopeus nousee mutta vielä on niin että jos molempia shiftejä painaa niin nouseekin liikaa..
        bool isShiftKeyPressed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        if (Input.GetKeyDown(KeyCode.LeftShift) || (Input.GetKeyDown(KeyCode.RightShift)))
        {
            walkSpeed = walkSpeed + 5;

        }
        else if (isShiftKeyPressed == false)
            walkSpeed = 10;


    }
    void FixedUpdate()
    {
        rb.transform.Translate(new Vector3(h, 0, v));

        transform.Rotate(new Vector3(0, mh, 0));
        cam.transform.Rotate(new Vector3(-mv, 0, 0));
    }

}
