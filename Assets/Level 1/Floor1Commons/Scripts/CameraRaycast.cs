using UnityEngine;

public class CameraRaycast : MonoBehaviour {

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
    }
}
