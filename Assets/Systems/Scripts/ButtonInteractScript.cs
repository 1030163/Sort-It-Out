using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ButtonInteractScript : MonoBehaviour
{

    public bool isPressable;   //Simple public bool to trigger from other script while player is close enough to press button
    [SerializeField]
    public ParticleSystem theParticleEffect;   //Ref to the Particle effect on the doorbell
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPressable && Input.GetKey(KeyCode.E))
        {
            theParticleEffect.Play();
            WhenPressed();
            print("Working?");
        }
        else
        {
            theParticleEffect.Stop();
            print("Why isn't this working, it's so damn simple");
        }
    }

    public void WhenPressed()
    {
        // CALL OUT TO WHATEVER METHOD YOU NEED!

    }


    IEnumerator WaitToDisable()
    {
        yield return new WaitForSeconds(.1f);
    }
}
