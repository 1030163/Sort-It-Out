using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.Rendering.DebugUI;


[System.Serializable]
public class ShakeEvent
{
    [Tooltip("How long the player has to shake the object before the event triggers and the audio is player.")]
    public int howManyShakesToTrigger;  //RENAME TO MAKE OBVIOUS 'Amount of shakes to make noise'  //every shake should mak enoise
    [Tooltip("This text box is just for debugging, so you can see it being triggerred without your headphones on.")]
    public string whatHappens;
    [Tooltip("The sound you would like to play when this event takes place.")]
    public AudioClip soundAffect;
}
public class ShakeableObject : MonoBehaviour
{
    [Header("Shake-Based Audio Events")]
    [Tooltip("These are the default sounds that play at random upon shaking. Min require 0.")]
    public AudioClip[] defaultShakeSounds;
    [Tooltip("This Array lets you add as many shake events as you want.")]
    public ShakeEvent[] shakeEventsList;

    [Header("Shaking Parameters")]
    [Tooltip("This is the \"distance\" an object has to move or rotation to count as being shaken, 4 by default. ")]
    public float shakeDist = 4f;

    [Tooltip("This the interval of how often it checks the movement that's taken place, every 0.2 seconds by default.")]
    public float whenToUpdate = 0.2f;

    private int shakeWeight;

    private Vector3 lastPosition;
    private Quaternion lastRotation;
    private float lastUpdateTime;

    private int curShakeEventItem;

    [SerializeField]
    private bool playingMain;
    [SerializeField]
    private bool playingDefault;

    void Start()
    {
        lastPosition = transform.position;
        lastRotation = transform.rotation;
        lastUpdateTime = Time.time;
    }

    void Update()
    {
        float deltaTime = Time.time - lastUpdateTime;

        if (deltaTime > whenToUpdate)
        {
            Vector3 currentPosition = transform.position;
            Quaternion currentRotation = transform.rotation;

            float displacement = Vector3.Distance(currentPosition, lastPosition);
            float rotationChange = Quaternion.Angle(currentRotation, lastRotation);

            float speed = displacement / deltaTime;
            float angularSpeed = rotationChange / deltaTime;

            if (speed > shakeDist || angularSpeed > shakeDist)
            {
                shakeWeight++;
                for (int i = 0; i < shakeEventsList.Length; i++)
                {
                    curShakeEventItem = i;
                    if (defaultShakeSounds.Length > 0 && !playingDefault && !playingMain)
                    {
                        DefaultShakeEvent();
                    }
                    if (shakeEventsList.Length > 0 && shakeEventsList[i].howManyShakesToTrigger == shakeWeight)
                    {



                        CurrentShakeEvent(shakeEventsList[curShakeEventItem].soundAffect);

                        return;
                    }
                }
            }

            lastPosition = currentPosition;
            lastRotation = currentRotation;
            lastUpdateTime = Time.time;
        }
    }

    void CurrentShakeEvent(AudioClip playMe)
    {
        print("" + shakeEventsList[curShakeEventItem].whatHappens);
        GetComponent<AudioSource>().clip = playMe;
        playingMain = true;
        GetComponent<AudioSource>().Play();
        StartCoroutine(MainSoundCountdown(GetComponent<AudioSource>().clip.length));
    }

    void DefaultShakeEvent()
    {
        GetComponent<AudioSource>().clip = defaultShakeSounds[Random.Range(0, defaultShakeSounds.Length)];
        playingDefault = true;
        print("Check");
        GetComponent<AudioSource>().Play();
        StartCoroutine(DefaultSoundCountdown(GetComponent<AudioSource>().clip.length));
    }



    IEnumerator MainSoundCountdown(float soundLength)
    {
        playingMain = true;
        yield return new WaitForSeconds(soundLength);
        playingMain = false;
    }
    IEnumerator DefaultSoundCountdown(float soundLength)
    {
        playingDefault = true;
        yield return new WaitForSeconds(soundLength);
        playingDefault = false;
    }


}


