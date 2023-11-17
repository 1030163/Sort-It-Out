using UnityEngine;

public class AudioSyncToAnimation : MonoBehaviour {

    private AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudioOneShotEvent(AudioClip audioClip) {
        audioSource.PlayOneShot(audioClip);
    }
}
