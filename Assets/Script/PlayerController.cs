using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private float moveSpeed;
    //[SerializeField] private float walkSpeed;
    //[SerializeField] private float runSpeed;
    

    Transform cameraObject;
    InputHandler inputHandler;
    private Vector3 moveDirection;

    public Transform player;

    public new Rigidbody rigidbody;
    public GameObject normalCamera;

    float movementSpeed = 5;
    float rotationSpeed = 10;




    //private Vector3 velocity;

    //[SerializeField] private bool isGounded;
    //[SerializeField] private float groundDistance;
    //[SerializeField] private LayerMask groundMask;
    //[SerializeField] private float gravity;
    //[SerializeField] private float jumpHeight;

    [HideInInspector]
    public AnimatorHandler AnimatorHandler;

    //private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        
        rigidbody= GetComponent<Rigidbody>();
        inputHandler = GetComponent<InputHandler>();
        cameraObject = Camera.main.transform;
        player = transform;
        //controller= GetComponent<CharacterController>();
        AnimatorHandler = GetComponentInChildren<AnimatorHandler>();
        AnimatorHandler.Initialize();

    }

    // Update is called once per frame
    public void Update()
    {
        //InputKeys();
        float delta = Time.deltaTime;
        inputHandler.TickInput(delta);



        moveDirection = cameraObject.forward * inputHandler.vertical;
        moveDirection += cameraObject.right * inputHandler.horizontal;
        moveDirection.Normalize();


        float speed = movementSpeed;
        moveDirection *= speed;

        Vector3 projectedVelocity = Vector3.ProjectOnPlane(moveDirection, normalVector);
        rigidbody.velocity = projectedVelocity;

        AnimatorHandler.UpdateAnimatorValues(inputHandler.moveAmount, 0);

        if (AnimatorHandler.canRotate)
        {
            HandleRotation(delta);
        }

    }

    //private void InputKeys()
    //{
        //isGounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);

        //if (isGounded && velocity.y<0 ) 
        //{
        //    velocity.y = -2f;
        //}




        //if (moveForward != 0)
        //{
        //    moveDirection = new Vector3(0, 0, moveForward);
        //    anim.SetBool("Move", true);
        //}

        //if (moveRight!= 0)
        //{
        //    moveDirection = new Vector3(moveRight, 0, 0);
        //    //player.Rotate(Vector3.up, moveRight);
        //    anim.SetBool("Move", true);
        //}

        //if (moveForward!=0 & moveRight!= 0)
        //{
        //    moveDirection = new Vector3(moveRight, 0, moveForward);
        //}

        //if (moveForward == 0 & moveRight == 0)
        //{
        //    moveDirection = Vector3.zero;
        //    anim.SetBool("Move", false);
        //}

        //moveDirection = new Vector3(0, 0, moveForward);
        //moveDirection+= new Vector3(moveRight, 0, 0);
        //moveDirection.Normalize();
        //moveDirection = transform.TransformDirection(moveDirection);

        //Quaternion tr = Quaternion.LookRotation(moveDirection);
        //Quaternion targetRotation = Quaternion.Slerp(player.rotation, tr, rotationSpeed* delta);
        //player.rotation = targetRotation;


        //    if (isGounded)
        //    {
        //        //if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        //        //{
        //        //    // move
        //        //    Move();


        //        //}
        //        //else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        //        //{
        //        //    // run
        //        //    Run();
        //        //}
        //        //else if (Input.GetKeyDown(KeyCode.Space))
        //        //{
        //        //    //jump
        //        //    Jump();
        //        //}
        //        //else if (moveDirection == Vector3.zero)
        //        //{
        //        //    //idle
        //        //    Idle();
        //        //}
        //        //moveDirection *= moveSpeed;
        //    }


        //    //controller.Move(moveDirection * Time.deltaTime);

        //    //velocity.y += gravity * Time.deltaTime;
        //    //controller.Move(velocity * Time.deltaTime);

        //}
    //}
    Vector3 normalVector = Vector3.up;
    Vector3 targetPostion;

    private void HandleRotation(float delta)
    {
        Vector3 targetDir = Vector3.zero;
        float moveOverride = inputHandler.moveAmount;

        targetDir = cameraObject.forward * inputHandler.vertical;
        targetDir += cameraObject.right * inputHandler.horizontal;

        targetDir.Normalize();
        targetDir.y = 0;

        if(targetDir == Vector3.zero)
        {
            targetDir = player.forward;
        }

        float rs = rotationSpeed;

        Quaternion tr = Quaternion.LookRotation(targetDir);
        Quaternion targetRotation = Quaternion.Slerp(player.rotation, tr, rs * delta);

        player.rotation = targetRotation;
    }
       
        //private void Move()
        //{

        //    moveSpeed = walkSpeed;
        //    anim.SetFloat("Blend", 0.5f);
        //}

        //private void Run()
        //{
        //    moveSpeed= runSpeed;
        //    anim.SetFloat("Blend", 1f);
        //} 
        //private void Jump()
        //{
        //    velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        //}

        //private void Idle()
        //{
        //    moveSpeed= 0;
        //}
     
}

