using UnityEngine;

public class LookAtPlayerOnActiveDialogue : MonoBehaviour {

    private Animator animator;
    [SerializeField] private Camera playerCamera;

    public bool ikActive = false;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK() {
        if(ikActive) {
            animator.SetLookAtWeight(1);
            animator.SetLookAtPosition(playerCamera.transform.position);
        }

        else {
            animator.SetLookAtWeight(0);
        }
    }
}
