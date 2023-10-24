using UnityEngine;

public class SpeechBubbleRotation : MonoBehaviour
{
    private Transform player;

    private void Awake() {
        player = GameObject.FindWithTag("MainCamera").transform;
    }

    private void Update() {
        transform.LookAt(player);
    }
}
