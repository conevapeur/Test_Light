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

    [SerializeField] float Height = 1f;
    [SerializeField] float Force = 10f;
    [SerializeField] float SpringDamper = 1f;

    [SerializeField] float floatHeight = 1f;
    [SerializeField] float floatForce = 10f;
    [SerializeField] float floatSpringDamper = 1f;


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
        yRotation = transform.localEulerAngles.y + Input.GetAxis("Gamepad X") * mouseSensivity;
        xRotation = xRotation - Input.GetAxis("Mouse Y") * mouseSensivity;
        xRotation = xRotation - Input.GetAxis("Gamepad Y") * mouseSensivity;

        xRotation = Mathf.Clamp(xRotation, -maxLookAngle, maxLookAngle);

        transform.localEulerAngles = new Vector3(0, yRotation, 0);
        joint.transform.localEulerAngles = new Vector3(xRotation, 0, 0);


        // sprint
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Joystick1Button8))
        {
            moveSpeed = 4f;
        }

        if (moveSpeed != 2f)
        {
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                moveSpeed = 2f;
            }
        }

        

    }
    void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        targetVelocity = transform.TransformDirection(targetVelocity) * moveSpeed;

        //Apply a force
        Vector3 velocityChange = targetVelocity - rb.velocity;
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;
        rb.AddForce(velocityChange, ForceMode.VelocityChange);


        /*
        Vector3 gravity = new Vector3(0, -9.81f, 0);
        float gravityMultiplier = 5f;
        gravity *= gravityMultiplier;

        if (rb.velocity.y < 0)
        {
            rb.AddForce(gravity, ForceMode.Force);
        }
        */

        RaycastHit hit;

        Vector3 rayDir = transform.TransformDirection(Vector3.down);

        int layerMask = 1 << 6;

        layerMask = ~layerMask;
        if (Physics.Raycast(transform.position, rayDir, out hit, floatHeight, layerMask))
        {

            Vector3 velocity = rb.velocity;

            Vector3 otherVelocity = Vector3.zero;

            Rigidbody contactBody = hit.rigidbody;

            if (contactBody != null)
            {
                otherVelocity = contactBody.velocity;
            }

            float rayDirVelocity = Vector3.Dot(rayDir, velocity);
            float otherDirVelocity = Vector3.Dot(rayDir, otherVelocity);

            float relativeVelocity = rayDirVelocity - otherDirVelocity;

            float x = hit.distance - floatHeight;

            float springForce = (x * floatForce) - (relativeVelocity * floatSpringDamper);

            rb.AddForce(rayDir * springForce);

            if (contactBody != null)
            {
                contactBody.AddForceAtPosition(rayDir * -springForce, hit.point);
            }
        }

    }
    
}
// boutons intéragir
// pièce test
// baisser, escalader
// viualiser
// exemple rencontre monstre