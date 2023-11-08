using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterDetector : MonoBehaviour
{
    public ParticleSystem fanfareParticles;
    [Header("Letter Information")]
    public bool isAnyLetter;
    public bool isCorrectLetter;
    public string letterName;

    [Header("Letter That Goes Here?")]
    public string intendedLetterName;

    [Header("Graphics")]
    public bool showOutline;

    [Header("Successful Delivery")]
    public string printOnSuccess;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Letter"))
        {
            isAnyLetter = true;
            letterName = other.gameObject.name;
            if (letterName == intendedLetterName)
            {
                isCorrectLetter = true;
                fanfareParticles.Play();
            }
            else
            {
                isCorrectLetter = false;
            }

            if (isCorrectLetter)
            {
                print(printOnSuccess);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Letter") && other.gameObject.name == letterName)
        {
            isAnyLetter = false;
            letterName = "";
        }
    }
}
