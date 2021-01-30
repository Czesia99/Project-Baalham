using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public float speed = 30f;
    // public float sprint = 60f;
    float rotation = 0f;
    public float rotationSpeed = 30;
    Vector3 moveDir = Vector3.zero;
    // private bool onSprint = false;
    private bool attacking = false;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        GetInput();
    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow))
        {
            // if (animator.GetBool("attacking") == true)
            // {
            //     return;
            // } else 
            if (animator.GetBool("attacking") == false)
            {
                animator.SetBool("running", true);
                // animator.SetInteger("state", 1);
                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }
        }
        if (Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.SetBool("running", false);
            // animator.SetInteger("state", 0);
            moveDir = new Vector3(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("back_run", true);
            // animator.SetInteger("state", 2);
            moveDir = new Vector3(0, 0, -1);
            moveDir *= speed;
            moveDir = transform.TransformDirection(moveDir);
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetBool("back_run", false);
            // animator.SetInteger("state", 0);
            moveDir = new Vector3(0, 0, 0);
        }

        rotation += horizontal * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rotation, 0);
        controller.Move(moveDir * Time.deltaTime);
    }

    void GetInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if(animator.GetBool("running") == true)
            {
                animator.SetBool("running", false);
                // animator.SetInteger("state", 0);
                Attacking();
            } 
            if (animator.GetBool("running") == false) {
                Attacking(); 
            }
        }
    }

    void Attacking()
    {
        animator.SetBool("attacking", true);
        // animator.SetInteger("state", 3);
        StartCoroutine("AttackRoutine");
        Debug.Log("out routine");
        // animator.SetInteger("state", 0);
        animator.SetBool("attacking", false);
    }

    IEnumerator AttackRoutine()
    {
        Debug.Log("in routine");
        yield return new WaitForSeconds(3);
    }
}