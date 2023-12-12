using UnityEngine;

public class CameraRaycast : MonoBehaviour {

    [SerializeField] private Transform packageHoldPoint;
    [SerializeField] private int interactDistance;
    [SerializeField] private float maxAngleUp = 60f; // Maximum angle the player can look up
    [SerializeField] private float maxAngleDown = 60f; // Maximum angle the player can look down
    [SerializeField] private float holdPointVerticalOffset = 1f; // How high above the default position the package can go

    private GameObject heldObject;
    private bool isHoldingObject = false;
    private Vector3 defaultHoldPointPosition;

    private Outline packageOutline;

    private void Start()
    {
        defaultHoldPointPosition = packageHoldPoint.localPosition;
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * interactDistance, Color.red);

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

            // Set the held object's position to the packageHoldPoint position
            heldObject.transform.position = packageHoldPoint.position;
        }

        if (Input.GetMouseButtonDown(0))
        {
            SendRaycast();
        }

        if (Input.GetMouseButtonDown(1) && isHoldingObject)
        {
            // Before releasing the object, reset the Rigidbody's velocity.
            Rigidbody rb = heldObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            isHoldingObject = false;
            heldObject = null;
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
                    rb.isKinematic = true;
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
