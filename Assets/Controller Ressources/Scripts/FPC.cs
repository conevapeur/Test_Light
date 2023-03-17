using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPC : MonoBehaviour
{

    private Rigidbody rb;

    #region Camera Movement Variables

    public Camera playerCamera;
    

    public float mouseSensivity = 3f;
    
    public float maxLookAngle = 90f;

    //Internal
    private float xRotation = 0f;
    private float yRotation = 0f;

    #endregion   

    #region Movement

    public float moveSpeed = 2f;
    public float maxVelocityChange = 7f;

    #endregion

    public GameObject joint;
    public bool isCrouching = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        yRotation = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensivity;
        xRotation = xRotation - Input.GetAxis("Mouse Y") * mouseSensivity;

        xRotation = Mathf.Clamp(xRotation , -maxLookAngle, maxLookAngle);

        transform.localEulerAngles = new Vector3(0, yRotation, 0);
        joint.transform.localEulerAngles = new Vector3(xRotation, 0, 0);

        

        if(Input.GetKeyDown(KeyCode.E))
        {
            moveSpeed = 4f;
        }
        if(Input.GetKeyUp(KeyCode.E))
        {
            moveSpeed = 2f;
        }
    }

    void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0 ,Input.GetAxis("Vertical"));
        targetVelocity = transform.TransformDirection(targetVelocity) * moveSpeed;

        //Apply a force
        Vector3 velocityChange = targetVelocity - rb.velocity;
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;
        rb.AddForce(velocityChange, ForceMode.VelocityChange);

        Vector3 gravity = new Vector3(0, -9.81f, 0);
        float gravityMultiplier = 5f;
        gravity *= gravityMultiplier;

        if (rb.velocity.y < 0)
        {
            rb.AddForce(gravity, ForceMode.Force);
        }

        
    }
}
