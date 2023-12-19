using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.Playables;
public enum PlayerState
{
    walk,
    attack
    
}
public class Player_Controller : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    private Vector3 change;
    private Animator animator;
    public PlayerState currentState;

    private void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
        if (Input.GetButtonDown("attack"))
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }


    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("MoveXIdle", change.x);
            animator.SetFloat("MoveYIdle", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 20f;

            animator.SetBool("Shift", true);
            animator.SetFloat("RunHorizontal", change.x);
            animator.SetFloat("RunVertical", change.y);
        }
        else
        {
            speed = 10f;
            animator.SetBool("Shift", false);
        }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.7f);
        currentState = PlayerState.walk;
    }

    void MoveCharacter()
    {
        rb.MovePosition(transform.position + change * speed * Time.deltaTime);
    }





















}
//{
//    public float moveSpeed = 5f;
 
//    public Rigidbody2D rb;
//    public Animator animator;
//    public PlayerState currentState;
//    Vector2 movement;

//    void Start()
//    {
//        currentState = PlayerState.walk;
//    }

//    void Update()
//    {
//        movement.x = Input.GetAxisRaw("Horizontal");
//        movement.y = Input.GetAxisRaw("Vertical");
        
//        if (Input.GetButtonDown("attack") )
//        {
//            StartCoroutine(AttackCo());
//        }
      
//        animator.SetFloat("Horizontal", movement.x);
//        animator.SetFloat("Vertical", movement.y);
//        animator.SetFloat("Speed", movement.sqrMagnitude);

//        if (movement.x != 0 || movement.y != 0)
//        {
//            animator.SetFloat("LastHorizontal", Input.GetAxisRaw("Horizontal"));
//            animator.SetFloat("LastVertical", Input.GetAxisRaw("Vertical"));
//        }

//        if (Input.GetKey(KeyCode.LeftShift))
//        {
//            moveSpeed = 10f;

//            animator.SetBool("Shift", true);
//            animator.SetFloat("RunHorizontal", movement.x);
//            animator.SetFloat("RunVertical", movement.y);
//        }
//        else
//        {
//            moveSpeed = 5f;
//            animator.SetBool("Shift", false);
//        }
      




//    }

//    private IEnumerator AttackCo()
//    {
//        animator.SetBool("attacking", true);
//        currentState = PlayerState.attack;
//        yield return null;
//        animator.SetBool("attacking", false);
//        yield return new WaitForSeconds(.33f); 
//        currentState = PlayerState.walk;
//    }

//    void FixedUpdate()
//    {
//        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
//        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);



//    }

    
//}