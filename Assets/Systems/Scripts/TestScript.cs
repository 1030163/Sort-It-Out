using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update

    public string bird = "The Word";
    Vector3 mousePosMovement = Vector3.zero;
    Vector3 mousePrevmovement = Vector3.zero;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosMovement = Input.mousePosition - mousePrevmovement;
        print("mouse variance is " + mousePosMovement);
        this.transform.Rotate(transform.up, -Vector3.Dot(mousePosMovement, Camera.main.transform.right), Space.World);
        this.transform.Rotate(Camera.main.transform.right, Vector3.Dot(mousePosMovement, Camera.main.transform.up), Space.World);
        mousePrevmovement = Input.mousePosition;
    }
}
