using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

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

    public CinemachineVirtualCamera vCam;

    [SerializeField] float vCamAmplitude;
    [SerializeField] float vCamFrequency;

    #region Movement

    public float moveSpeed = 2f;
    public float maxVelocityChange = 7f;
    private float baseMoveSpeed;

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
    public bool canLook = true;
    public bool canSidewalk = true;

    public GameObject target;

    public GameObject carried;

    public LightmapData[] _lightmapData;

    private bool toMimic = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();

        baseMoveSpeed = moveSpeed;
        //cam = transform.GetChild(0).GetComponent<Camera>();

        vCamFrequency = 0.2f;
        vCamAmplitude = 1f;

    _lightmapData = LightmapSettings.lightmaps;
    LightmapSettings.lightmaps = new LightmapData[] { };
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rb.velocity.magnitude);
        if(canLook)
        {
            #region move
            if(canSidewalk)
            {
                yRotation = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensivity;
                //yRotation = transform.localEulerAngles.y + Input.GetAxis("Gamepad X") * mouseSensivity;
                xRotation = xRotation - Input.GetAxis("Mouse Y") * mouseSensivity;
                //xRotation = xRotation - Input.GetAxis("Gamepad Y") * mouseSensivity;

                xRotation = Mathf.Clamp(xRotation, -maxLookAngle, maxLookAngle);

                transform.localEulerAngles = new Vector3(0, yRotation, 0);
                joint.transform.localEulerAngles = new Vector3(xRotation, 0, 0);
            }
            


            // sprint
            if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Joystick1Button8)) && carried == null)
            {
                moveSpeed = 4f;
                
            }

            if (moveSpeed != 2f)
            {
                if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && carried == null)
                {
                    moveSpeed = 2f;
                    
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (carried != null)
                {
                    carried.gameObject.transform.SetParent(null);
                    carried = null;
                    canSidewalk = true;
                    moveSpeed = baseMoveSpeed;
                }
                else
                {
                    target = null;
                    rayLook();
                    interact(target);

                }
                
            }

            #endregion

        }


        setBob();

        vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = vCamAmplitude;
        vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = vCamFrequency;


    }
    void FixedUpdate()
    {
        if(canMove)
        {
            #region move

            Vector3 targetVelocity = new Vector3(0, 0, Input.GetAxis("Vertical"));

            if(canSidewalk)
            {
                targetVelocity = new Vector3(Input.GetAxis("Horizontal"), targetVelocity.y, targetVelocity.z);
            }
            

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
            if (Physics.Raycast(transform.position, rayDir, out hit, floatHeight, layerMask, QueryTriggerInteraction.Ignore))
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

    private void setBob()
    {
        if(rb.velocity.magnitude > 3)
        {
            vCamFrequency = 1.4f;
            vCamAmplitude = 1f;
        }
        else if (rb.velocity.magnitude > 0.5)
        {
            vCamFrequency = .7f;
            vCamAmplitude = 1f;
        }
        else
        {
            vCamFrequency = .2f;
            vCamAmplitude = 1f;
        }

    }

    private void rayLook()
    {
        
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if(Vector3.Distance(hit.transform.position, transform.position) < 3)
            {
                target = hit.transform.gameObject;
            }
            else
            {
                //Debug.Log("trop loin");
            }
            
            //print("I'm looking at " + hit.transform.name);
            //Debug.Log(hit.transform.name + " est � " +Vector3.Distance(hit.point, transform.position));
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
                    lever(target);
                    break;
                case "button":

                    break;
                case "pushable":
                    StartCoroutine(push());
                    break;
                case "carryable":
                    carry();
                    break;
            }

            Debug.Log("cet objet est " + target.transform.tag);
        }
        

        
    }

    IEnumerator goTo(Transform target)
    {
        Vector3 dir;

        toMimic = false;
        do
        {
            dir = target.position - transform.position;
            dir = dir.normalized;
            transform.Translate(dir * 2 * Time.deltaTime, Space.World);
            //Debug.Log(Vector3.Distance(target.position, transform.position));

            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, 1f * Time.deltaTime);

            yield return null;
        }
        while (Vector3.Distance(target.position, transform.position) > 0.5f);

        transform.position = target.position;
        transform.rotation = target.rotation;

        toMimic = true;

        yield return null;
    }
    IEnumerator climb ()
    {
        canMove = false;
        canLook = false;
        rb.useGravity = false;
        rb.velocity = new Vector3(0,0,0);
        
        Transform mimic = target.transform.GetChild(0);
        Vector3 targetPos = new Vector3(0,0,0);
        Vector3 dir;

        

        StartCoroutine(goTo(mimic));

        do
        {
            yield return null;
        }
        while (toMimic == false);
        
        
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            targetPos = new Vector3(hit.point.x, target.GetComponent<Collider>().bounds.max.y, hit.point.z) + new Vector3(0, 1.3f, 0);
        }

        do
        {
            transform.Translate(Vector3.up * 1 * Time.deltaTime, Space.World);
            //Debug.Log("first phase");
            yield return null;
        }
        while (transform.position.y < target.GetComponent<Collider>().bounds.max.y + 0.5);

        do
        {
            dir = targetPos - transform.position;
            dir = dir.normalized;
            transform.Translate(dir * 1 * Time.deltaTime, Space.World);
            //Debug.Log("first phase"+ Vector3.Distance(targetPos, transform.position));
            yield return null;
        }
        while (Vector3.Distance(targetPos, transform.position) > 0.1f);

        canMove = true;
        canLook = true;
        rb.useGravity = true;
        yield return null;
            
        
    }

    private void setchild(GameObject target)
    {
        target.transform.SetParent(transform/*.GetChild(0)*/);
        carried = target;
    }

    IEnumerator push()
    {
        Transform mimic = target.transform.GetChild(0);

        canMove = false;
        canLook = false;

        StartCoroutine(goTo(mimic));
        /*transform.position = mimic.position;
        transform.rotation = mimic.rotation;
        */

        do
        {
            yield return null;
        }
        while (toMimic == false);

        canMove = true;
        canLook = true;

        setchild(target);
        canSidewalk = false;

        moveSpeed = baseMoveSpeed * 0.6f;

        
    }

    private void carry()
    {
        setchild(target);
        moveSpeed = baseMoveSpeed * 0.7f;
    }

    private void lever(GameObject _target)
    {
        // pick a random color
        Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        // apply it on current object's material
        _target.GetComponent<MeshRenderer>().material.color = newColor;

        LightmapSettings.lightmaps = _lightmapData;
    
    }
}
// boutons int�ragir
// pi�ce test
// baisser, escalader
// viualiser
// exemple rencontre monstre
