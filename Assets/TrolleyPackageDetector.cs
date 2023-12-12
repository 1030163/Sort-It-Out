using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrolleyPackageDetector : MonoBehaviour
{

    public List<GameObject> packagesInTrolley = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Package"))
        {
            packagesInTrolley.Add(other.gameObject);
        }    

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Package"))
        {
            packagesInTrolley.Remove(other.gameObject);
        }

    }

    private void OnTriggerStay(Collider other)
    {
       if (other.gameObject.CompareTag("Package"))
        {
            other.gameObject.transform.SetParent(this.transform);
        }
    }
}
