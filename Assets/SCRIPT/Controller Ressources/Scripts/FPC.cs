using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;



/*using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
*/


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

    

    public static bool canMove = true;
    public static bool canLook = true; // je l'ai passé en static pour l'appeler dans l'UI je sais pas faire autrement mdr
    public static bool canSidewalk = true;
    [SerializeField] public static bool canChange = true;
    public static bool fall = false;

    public GameObject target;

    public GameObject carried;


    public bool talkieDegaine;
    public bool haveToDegaine;


    public Animator animator;


    //sound design 
    [SerializeField] private AudioSource walkSound;




   //A VERIFIER QUE CA SERT ENCORE MAIS JE PENSE QUE NON 
    // lights
   // LightmapData[] _lightmapData;
    [SerializeField] private GameObject _redLigths;
    [SerializeField] private GameObject _naturalLigths;

    // doors
    [SerializeField] private Animator _stairs;
    [SerializeField] private Animator _security;
    [SerializeField] private Animator _archives;
    [SerializeField] private Animator _escalade;

    [SerializeField] private float climbDelay;
    ///////////////////////////////////




    private bool toMimic = false;

    public static float monster_pathDistance;

    public bool isScared = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();

        baseMoveSpeed = moveSpeed;
        //cam = transform.GetChild(0).GetComponent<Camera>();

        vCamFrequency = 0.2f;
        vCamAmplitude = 1f;


        climbDelay = 0.3f;

        _redLigths.gameObject.SetActive(false);

        talkieDegaine = false;
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
                yRotation = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensivity  /*+ Input.GetAxis("Gamepad X") * mouseSensivity*/;
                //yRotation = transform.localEulerAngles.y + Input.GetAxis("Gamepad X") * mouseSensivity;
                xRotation = xRotation - Input.GetAxis("Mouse Y") * mouseSensivity /*- Input.GetAxis("Gamepad Y") * mouseSensivity*/;
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

            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Joystick1Button2))
            {
                if (carried != null)
                {
                    if (carried.TryGetComponent(out Rigidbody rb))
                    {
                        //Debug.Log("patate");
                        //rb.isKinematic = false;
                    }
                    //carried.TryGetComponent<Rigidbody>().isKinematic = false;
                    carried.gameObject.transform.SetParent(null);
                    carried = null;
                    canSidewalk = true;
                    moveSpeed = baseMoveSpeed;
                }
                else
                {

                    target = null;
                    rayInteract();
                    interact(target);

                }
                
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                if(carried == null)
                {
                    target = null;
                    rayClimb();
                    if(target != null)
                    {
                        if (target.transform.tag == "climbable")
                        {
                            StartCoroutine(climb());
                        }
                    }
                    
                    
                }
            }

            #endregion

        }

        if(Input.GetKeyDown(KeyCode.Tab) || haveToDegaine)
        {
           haveToDegaine = false;
            //Trigger anim

            if(!talkieDegaine)
            {
                animator.SetTrigger("triggerTalkie");
                animator.ResetTrigger("triggerEndTalkie");
            }
            else
            {
                animator.SetTrigger("triggerEndTalkie");
                animator.ResetTrigger("triggerTalkie");
            }
            talkieDegaine = !talkieDegaine;
        }

        if (canChange && talkieDegaine)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button4))
            {
                /*
                state -= 1;
                if (state < 0)
                    state = 4;

                refreshFreq();

                _animator.SetTrigger("trigger");*/

                GameManager.instance.DownFreq();

                animator.SetTrigger("triggerTalkie-");

            }
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button5))
            {
                /*
                state += 1;
                state = state % 5;

                refreshFreq();*/

                //_animator.SetTrigger("trigger");

                GameManager.instance.UpFreq();

                animator.SetTrigger("triggerTalkie+");

            }
        }


        setBob();

        vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = vCamAmplitude;
        vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = vCamFrequency;

        checkMonsterDistance();
    }
    void FixedUpdate()
    {
        if (canMove)
        {
            #region move

            Vector3 targetVelocity = new Vector3(0, 0, Input.GetAxis("Vertical"));

            if (canSidewalk)
            {
                targetVelocity = new Vector3(Input.GetAxis("Horizontal"), targetVelocity.y, targetVelocity.z);

                if (targetVelocity != Vector3.zero) // bruits de pas
                {
                    //Debug.Log(targetVelocity);
                    //walkSound.enabled = true;
                }
                else
                {
                    //walkSound.enabled = false;
                }

            }


            targetVelocity = transform.TransformDirection(targetVelocity) * moveSpeed;

            //Apply a force
            Vector3 velocityChange = targetVelocity - rb.velocity;
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);



            velocityChange.y = 0;
            rb.AddForce(velocityChange, ForceMode.VelocityChange);



            #endregion

        }

        

        if (!fall)
        {
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
        }
           

        


    }

    private void setBob()
    {
        if(rb.velocity.magnitude > 3)
        {
            vCamFrequency = 1.4f;
            vCamAmplitude = 1f;

            walkSound.enabled = true;
            walkSound.pitch = 2;
        }
        else if (rb.velocity.magnitude > 0.5)
        {
            vCamFrequency = .7f;
            vCamAmplitude = 1f;
            walkSound.enabled = true;
            walkSound.pitch = 1;

        }
        else
        {
            vCamFrequency = .2f;
            vCamAmplitude = 1f;

            walkSound.enabled = false;
        }

    }

    private void rayInteract()
    {
        int layerMask = 1 << 6;
        layerMask = ~layerMask;
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,10,layerMask, QueryTriggerInteraction.Ignore))
        {
            if(Vector3.Distance(hit.transform.position, transform.position) < 3)
            {
                target = hit.transform.gameObject;
            }
            else
            {
                //Debug.Log("trop loin");
            }


        }
            
        
    }

    private void rayClimb()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (Vector3.Distance(hit.transform.position, transform.position) < 3)
            {
                //Debug.Log(hit.transform.gameObject.name);
                target = hit.transform.gameObject;
            }
        }
    }

    private void interact(GameObject target)
    {
        if(target != null)
        {
            switch (target.transform.tag)
            {
                /*case "climbable":

                    StartCoroutine(climb());

                    break;*/
                
                case "card":
                    card(target);
                    break;
                 
                case "pushable":
                    StartCoroutine(push());
                    break;
                case "carryable":
                    carry();
                    break;
                case "interactable":
                    
                    //target.TryGetComponent<IInteract>().OnInteract();
                    if (target.TryGetComponent(out IInteract _target))
                    {
                        //Debug.Log("patate");
                        _target.OnInteract();
                    }
                    break;
            }

            //Debug.Log("cet objet est " + target.transform.tag);
        }
        

        
    }

    IEnumerator goTo(Transform target)
    {
        Vector3 dir;

        rb.velocity = Vector3.zero;
        rb.useGravity = false;
        toMimic = false;
        do
        {
            
            dir = target.position - transform.position;
            dir = dir.normalized;
            //transform.Translate(dir * 2 * Time.deltaTime, Space.World);
            //Debug.Log(Vector3.Distance(target.position, transform.position));

            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime);

            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, 3f * Time.deltaTime);

            //Debug.Log("difference : " + Quaternion.Angle(target.rotation, transform.rotation));

            yield return null;
        }
        while (Vector3.Distance(target.position, transform.position) > 0.3f || Quaternion.Angle(target.rotation, transform.rotation) > 1 );
        rb.useGravity = true;
        transform.position = target.position;
        transform.rotation = target.rotation;

        toMimic = true;

        yield return null;
    }
    IEnumerator climb ()
    {
        //canMove = false;
        //canLook = false;
        lockAbilities("climb");

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

        rb.useGravity = false;

        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            targetPos = new Vector3(hit.point.x, target.GetComponent<Collider>().bounds.max.y, hit.point.z) + new Vector3(0, 1.3f, 0);
        }

        //_escalade.SetTrigger("trigger");

        animator.SetTrigger("triggerChair");
        yield return new WaitForSeconds(climbDelay);

        

        do
        {
            transform.Translate(Vector3.up * 1 * Time.deltaTime, Space.World);
            //Debug.Log("first phase");
            yield return null;
        }
        while (transform.position.y < target.GetComponent<Collider>().bounds.max.y + 0.5);

        do
        {
            /*
            dir = targetPos - transform.position;
            dir = dir.normalized;
            transform.Translate(dir * 1 * Time.deltaTime, Space.World);*/
            //Debug.Log("first phase"+ Vector3.Distance(targetPos, transform.position));

            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime);

            yield return null;
        }
        while (Vector3.Distance(targetPos, transform.position) > 0.1f);

        recover();
        //canMove = true;
        //canLook = true;
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
        target.GetComponent<Rigidbody>().isKinematic = true;

        Transform mimic = target.transform.GetChild(0);

        //canMove = false;
        //canLook = false;
        lockAbilities("push");

        StartCoroutine(goTo(mimic));
        /*transform.position = mimic.position;
        transform.rotation = mimic.rotation;
        */

        do
        {
            yield return null;
        }
        while (toMimic == false);

        //canMove = true;
        //canLook = true;
        recover();

        setchild(target);
        canSidewalk = false;

        moveSpeed = baseMoveSpeed * 0.6f;

        
    }

    private void carry()
    {
        //target.GetComponent<Rigidbody>().isKinematic = true;
        setchild(target);
        moveSpeed = baseMoveSpeed * 0.7f;
    }

    

    private void card(GameObject _target)
    {
        //_security.SetTrigger("trigger");
    }
    
    public void checkMonsterDistance()
    {
        /*
        if (!isScared && monster_pathDistance < 15)
        {
            Debug.Log("déclanchement mains devant les yeux");
            isScared = true;
            terrify();
        }
        if (isScared && monster_pathDistance > 25)
        {
            isScared = false;
            Debug.Log("n'as plus peur");
            recover();
        }
        */
    }
    public void terrify()
    {
        lockAbilities("scared");
    }

    public void lockAbilities(string _situation)
    {
        switch(_situation)
        {
            case "climb":
                canLook = false;
                canMove = false;
                rb.velocity = Vector3.zero;
                canChange = false;
                break;

            case "push":
                canLook = false;
                canMove = false;
                rb.velocity = Vector3.zero;
                canChange = false;
                break;

            case "scared":
                canMove = false;
                canLook = false;
                canSidewalk=false;
                if(!isCrouching)
                {
                    fall = true;
                }
                
                rb.velocity = Vector3.zero;
                canChange = false;

                break;
            case "listening":
                canMove = false;
                rb.velocity = Vector3.zero;
                break;


        }
    }

    public void recover()
    {
        canLook = true;
        canMove = true;
        canSidewalk = true;
        rb.useGravity = true;
        fall = false;
        canChange = true;
    }

    public void Die()
    {
        Debug.Log("T mort");
    }
    
}

// boutons intéragir
// pièce test
// baisser, escalader
// viualiser
// exemple rencontre monstre
