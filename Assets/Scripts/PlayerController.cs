using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private bool isMoving = false;
    private Vector2 input;
    private Animator animator;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (!isMoving) {
            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (input != Vector2.zero) {
                input.y = input.x != 0 ? 0 : input.y; // restrain diagonal movement
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                Vector3 targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;


                if (isWalkable(targetPos)) {
                    StartCoroutine(Move(targetPos));
                }
            }
        }
        animator.SetBool("isMoving", isMoving);
    }

    private bool isWalkable(Vector3 targetPos) {
        return Physics2D.OverlapCircle(targetPos, 0.2f, LayerMask.GetMask("SolidObjects")) == null;
    }

    private void CheckForEncounter() {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, LayerMask.GetMask("Grass")) != null) {
            if (Random.Range(1,101) <= 10) {
                Debug.Log("Encounter started");
            }
        }
    }

    IEnumerator Move(Vector3 targetPos) { // coroutine for smooth movement between tiles
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon) {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
        CheckForEncounter();
    }
}
