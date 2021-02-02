using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool openingChest = false;
    private float chestTimer = 2f;
    private Vector3 initPos;

    // Start is called before the first frame update
    void Start()
    {
        initPos = this.transform.position;
        Debug.Log(initPos);
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
                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }
        }
        if (Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.SetBool("running", false);
            moveDir = new Vector3(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("back_run", true);
            moveDir = new Vector3(0, 0, -1);
            moveDir *= speed;
            moveDir = transform.TransformDirection(moveDir);
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetBool("back_run", false);
            moveDir = new Vector3(0, 0, 0);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            openingChest = true;
        }

        if (chestTimer <= 0)
        {
            openingChest = false;
            chestTimer = 0.5f;
        }
        chestTimer = chestTimer -= Time.deltaTime;
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
        StartCoroutine("AttackRoutine");
        Debug.Log("out routine");
        animator.SetBool("attacking", false);
    }

    IEnumerator AttackRoutine()
    {
        yield return new WaitForSeconds(3);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
           // Debug.Log("TEST");
            //SceneManager.LoadScene(1);
        }
    }
}