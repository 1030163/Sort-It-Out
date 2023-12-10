using UnityEngine;

public class CameraRaycastNEW : MonoBehaviour
{

    [SerializeField] private Transform packageHoldPoint;
    [SerializeField] private int interactDistance;
    [SerializeField] private float maxAngleUp = 60f; // Maximum angle the player can look up
    [SerializeField] private float maxAngleDown = 60f; // Maximum angle the player can look down
    [SerializeField] private float holdPointVerticalOffset = 12f; // How high above the default position the package can go


    [SerializeField] private float correctionForce = 1f; // The force/speed with which to correct the object when held

    private GameObject heldObject;
    [SerializeField] private bool isHoldingObject = false;
    private Vector3 defaultHoldPointPosition;


    public bool rotationHappening = false; //Bool for rmb down / currently rotating
    private Vector3 mousePosMovement = Vector3.zero;
    private Vector3 mousePrevmovement = Vector3.zero;


    [SerializeField] private GameObject parentPlayer;   //Reference to the player object with the Movement script on it.   Using this method to ensure funtionality if any changes occur to player hierarchal structure


    private void Start()
    {
        defaultHoldPointPosition = packageHoldPoint.localPosition;
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * interactDistance, Color.red);


        if (Input.GetMouseButtonDown(1) && isHoldingObject)
        {
            rotationHappening = true;
            parentPlayer.GetComponent<NonVrCharacterControllerNEW>().canRotate = false;

            Cursor.lockState = CursorLockMode.None;

        }
        else if (Input.GetMouseButtonUp(1))
        {
            rotationHappening = false;
            parentPlayer.GetComponent<NonVrCharacterControllerNEW>().canRotate = true;
        Cursor.lockState = CursorLockMode.Locked;
        }


        if (Input.GetMouseButtonDown(0))
        {

            if (isHoldingObject)
            {
                if (Input.GetMouseButtonDown(0) && isHoldingObject)
                {
                    // Before releasing the object, reset the Rigidbody's velocity.
                    Rigidbody rb = heldObject.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        /*  rb.isKinematic = false;
                          rb.velocity = Vector3.zero;                              //Butchered by Woody
                          rb.angularVelocity = Vector3.zero;*/
                        rb.useGravity = true;
                    }
                    isHoldingObject = false;
                    heldObject = null;
                }
            }
            else
            {
                SendRaycast();
            }

        }

    }

    private void FixedUpdate()
    {
        if (heldObject)
        {
            // Get the pitch of the camera/player view and convert it to a range between -180 and 180
            float pitch = transform.eulerAngles.x;
            if (pitch > 180f) pitch -= 360f;

            // Apply the cutoffs directly to the pitch value
            pitch = Mathf.Clamp(pitch, -maxAngleUp, maxAngleDown);

            // Normalize the pitch into a 0-1 range where 0 is maxAngleUp and 1 is maxAngleDown
            float normalizedPitch = (pitch - (-maxAngleUp)) / (maxAngleDown - (-maxAngleUp));

            // Calculate the new y position for the packageHoldPoint based on the normalized pitch
            // We use normalizedPitch directly to interpolate between the lower and upper bounds
            float newYPos = Mathf.Lerp(defaultHoldPointPosition.y + holdPointVerticalOffset,
                                       defaultHoldPointPosition.y - holdPointVerticalOffset,
                                       normalizedPitch);

            // Set the packageHoldPoint's position to follow the camera's pitch within the clamped range
            packageHoldPoint.localPosition = new Vector3(
                defaultHoldPointPosition.x,
                newYPos,
                defaultHoldPointPosition.z
            );

            // Move the held object's position to the packageHoldPoint position via Rigidbody Physics                                                           //Edited by Woody J. Wyche 1024800
            // Using LERP                                                                            
            //float t = Mathf.SmoothStep(0, 1, Time.deltaTime * correctionForce);


            Vector3 moveToHeldPos = Vector3.Lerp(heldObject.transform.position, packageHoldPoint.position, Time.deltaTime * correctionForce);

            

            heldObject.GetComponent<Rigidbody>().MovePosition(moveToHeldPos);


        }


        if (rotationHappening)
        {
            mousePosMovement = Input.mousePosition - mousePrevmovement;
            print("mouse variance is "+mousePosMovement);
            heldObject.transform.Rotate(transform.up, Vector3.Dot(mousePosMovement, Camera.main.transform.right), Space.World);
            heldObject.transform.Rotate(Camera.main.transform.right, Vector3.Dot(mousePosMovement, Camera.main.transform.up), Space.World);
            mousePrevmovement = Input.mousePosition;
//            print(Vector3.Dot(mousePosMovement, Camera.main.transform.up));
        }
    }

    private void SendRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance))
        {
            if (hit.collider.CompareTag("Package"))
            {
                isHoldingObject = true;
                heldObject = hit.collider.gameObject;

                // Make the object's Rigidbody kinematic to remove it from physics simulation
                Rigidbody rb = heldObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    //rb.isKinematic = true;                                 //Butchered by Woody 
                    rb.useGravity = false;
                }
            }
        }
    }


    //Cam's original script if I break everything :)
    /*
    [SerializeField] private Transform packageHoldPoint;
    [SerializeField] private int interactDistance;

    private GameObject heldObject;
    private bool isHoldingObject = false;

    private void Update() {
        Debug.DrawRay(transform.position, transform.forward * interactDistance, Color.red);
        if (heldObject) {
            heldObject.transform.position = packageHoldPoint.position;
        }

        if (Input.GetMouseButtonDown(0)) {
            SendRaycast();
        }

        if (Input.GetMouseButtonDown(1) && isHoldingObject) {
            heldObject = null;
        }
    }

    private void SendRaycast() {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance)) {
            if (hit.collider.tag == "Package") {
                isHoldingObject = true;
                heldObject = hit.collider.gameObject;
            }
        }
    }*/
}
