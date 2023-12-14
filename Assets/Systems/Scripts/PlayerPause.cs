using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPause : MonoBehaviour
{
    [SerializeField] private NonVrCharacterControllerNEW vrCont;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.gamePaused)
        {
            vrCont.enabled = false;
        }
        else
        {
            vrCont.enabled = true; 
        }
    }
}
