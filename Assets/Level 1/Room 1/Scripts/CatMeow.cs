using System.Collections;
using UnityEngine;

public class CatMeow : MonoBehaviour {

    [SerializeField] private AudioClip[] catMeowingSounds;

    private AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        StartCoroutine(CatMeowDelay());
    }

    private void PlayMeowAudio() {
        audioSource.PlayOneShot(ChooseRandomMeowSound());
    }

    // Every 5 to 10 seconds (can be adjusted) a check to see if a cat meows will occur
    // It's random because I don't want every cat to check at the same time, as thing would sometimes result in overlapping meows
    private IEnumerator CatMeowDelay() {
        int delayTimer = Random.Range(5, 10);

        while (delayTimer > 0) {
            yield return new WaitForSeconds(1f);
            delayTimer--;
        }

        // If WillCatMeow return true, then play a meow sound
        if (WillCatMeow()) {
            PlayMeowAudio();
        }

        StartCoroutine(CatMeowDelay());
    }

    // There's a 10% chance for a cat to meow
    // This is to keep cats from meowing at the same time as much as possible
    // And make it feel more natural by randomising when the cat will meow
    private bool WillCatMeow() {
        int chanceToMeow = 10;
        int r = Random.Range(0, 100);

        if (r <= chanceToMeow) {
            return true;
        }

        return false;
    }

    // Chooses a random sound from the array
    private AudioClip ChooseRandomMeowSound() {
        int r = Random.Range(0, catMeowingSounds.Length);
        return catMeowingSounds[r];
    }
}
