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

    

    public bool canMove = true;

    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
        //cam = transform.GetChild(0).GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            #region move
            yRotation = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensivity;
            //yRotation = transform.localEulerAngles.y + Input.GetAxis("Gamepad X") * mouseSensivity;
            xRotation = xRotation - Input.GetAxis("Mouse Y") * mouseSensivity;
            //xRotation = xRotation - Input.GetAxis("Gamepad Y") * mouseSensivity;

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

            if (Input.GetKeyDown(KeyCode.E))
            {
                target = null;
                rayLook();
                interact(target);
            }

            #endregion
        }


        


        
    }
    void FixedUpdate()
    {
        if(canMove)
        {
            #region move
            Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            targetVelocity = transform.TransformDirection(targetVelocity) * moveSpeed;

            //Apply a force
            Vector3 velocityChange = targetVelocity - rb.velocity;
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            rb.AddForce(velocityChange, ForceMode.VelocityChange);

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

            #endregion
        }


    }

    private void rayLook()
    {
        
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            target = hit.transform.gameObject;
            //print("I'm looking at " + hit.transform.name);
            //Debug.Log(hit.transform.name + " est à " +Vector3.Distance(hit.point, transform.position));
            /*Debug.Log(obj.transform.name);
            Debug.Log(obj.GetComponent<Collider>().bounds.min.y);
            Debug.Log(obj.GetComponent<Collider>().bounds.max.y);
            Debug.Log(obj.GetComponent<Collider>().bounds.size);
            */


        }
            
        
    }

    private void interact(GameObject target)
    {
        if(target != null)
        {
            switch (target.transform.tag)
            {
                case "climbable":

                    StartCoroutine(climb());

                    break;
                case "lever":

                    break;
                case "button":

                    break;
                case "pushable":

                    break;
                case "chair":

                    break;
            }
        }
        

        Debug.Log("cet objet est " + target.transform.tag);
    }

    IEnumerator climb ()
    {
        canMove = false;
        rb.useGravity = false;
        rb.velocity = new Vector3(0,0,0);
        
        Transform mimic = target.transform.GetChild(0);
        Vector3 targetPos = new Vector3(0,0,0);
        Vector3 dir;

        transform.position = mimic.position;
        transform.rotation = mimic.rotation;

        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            targetPos = new Vector3 (hit.point.x, target.GetComponent<Collider>().bounds.max.y, hit.point.z) + new Vector3 (0,1.3f,0);
        }

        do
        {
            transform.Translate(Vector3.up * 1 * Time.deltaTime, Space.World);
            //Debug.Log("first phase");
            yield return null;
        }
        while (transform.position.y < target.GetComponent<Collider>().bounds.max.y + 0.5);
        dir = targetPos - transform.position;
        dir = dir.normalized;
        do
        {
            transform.Translate(dir * 1 * Time.deltaTime, Space.World);
            //Debug.Log("first phase"+ Vector3.Distance(targetPos, transform.position));
            yield return null;
        }
        while (Vector3.Distance(targetPos, transform.position) > 0.1f);

        canMove = true;
        rb.useGravity = true;
        yield return null;
    }

}
// boutons intéragir
// pièce test
// baisser, escalader
// viualiser
// exemple rencontre monstre