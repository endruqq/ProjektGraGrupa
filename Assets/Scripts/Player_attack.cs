//using UnityEngine;

//public class Player_attack : MonoBehaviour
//{
//    private Animator animator;
//    private GameObject attackArea = default;

//    private bool attacking = false;

//    private float timeToAttack = 0.25f;

//    private float timer = 0f;

//    void Start()
//    {
//        attackArea = transform.GetChild(0).gameObject;
//        animator = GetComponent<Animator>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            Attack();
//            animator.SetBool("Attack", true);
//        }
//        else if (Input.GetMouseButtonUp(0) && attacking)
//        {
//            // Reset the "IsAttacking" parameter to false when the mouse button is released
//            animator.SetBool("Attack", false);
//            attacking = false;
//            attackArea.SetActive(attacking);
//        }

//        if (attacking)
//        {


//            timer += Time.deltaTime;

//            if (timer > timeToAttack)
//            {
//                timer = 0;
//                attacking = false;
//                attackArea.SetActive(attacking);
//                animator.SetBool("Attack", false);
//            }
//        }
//    }

//    private void Attack()
//    {
//        attacking = true;
//        attackArea.SetActive(attacking);
//    }
//}
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public AttackArea attackArea;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack"); // Trigger attack animation
        attackArea.gameObject.SetActive(true); // Activate the attack area during the attack
    }
}
