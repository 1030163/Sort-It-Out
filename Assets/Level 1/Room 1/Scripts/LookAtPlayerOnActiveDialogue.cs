using UnityEngine;

public class LookAtPlayerOnActiveDialogue : MonoBehaviour {

    private Animator animator;
    [SerializeField] private Camera playerCamera;

    [SerializeField] private float distanceToPlayer;
    [SerializeField] private float lookAtWeight = 0;

    public bool ikActive = false;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        distanceToPlayer = Vector3.Distance(transform.position, playerCamera.transform.position);
    }

    private void OnAnimatorIK() {
        if(ikActive && distanceToPlayer <= 3f) {
            animator.SetLookAtWeight(lookAtWeight += Time.deltaTime);
            animator.SetLookAtPosition(playerCamera.transform.position);
        }

        else {
            animator.SetLookAtWeight(lookAtWeight -= Time.deltaTime);

            if (lookAtWeight < 0)
                lookAtWeight = 0;
        }
    }
}
