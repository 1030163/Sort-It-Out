using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPackage : MonoBehaviour
{

    [Header("Exclamation Mark")]
    public GameObject exclamationMark;

    private bool taskDone;

    private Vector3 previousPosition;
    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != previousPosition)
        {
            if (!taskDone)
            {
                Debug.Log("Box has been moved");
                exclamationMark.SetActive(false);
                taskDone = true;
            }
        }
    }
}
