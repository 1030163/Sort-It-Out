using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectTag : MonoBehaviour
{                                      //To define them as such

    public enum InspectableItems     //Enum so options are available in a dropdown list format
    {                               //If you would like to add new options please list them within this Enum
        Letter,
        Buttons,
        Elevator_Button,
        Doorbell,
        Other
    }

    public InspectableItems chosenInspectableItem;         //Publicly accessible Chosen Item for other scripts to detect
}

