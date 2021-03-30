using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 7f;
    public float jumpHeight = 2f;
    public float gravity = 9.81f;

    public Transform groundCheck;
    public LayerMask groundMask;
   

    private float horizontalInput;
    private float verticalInput;

    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;
    private float groundDistance = 0.1f;
    private bool isAbleToJump;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        ReadInputs();
        CheckGround();
        Movement();
    }

    //Comprobamos si el personaje coge la llave

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject);
			LevelManager.Instance.levelComplete = true;
        }
    }


    private void ReadInputs()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            isAbleToJump = true;
        }
        else
        {
            isAbleToJump = false;
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    
    private void Movement()
    {
      
        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = 0f;
        }


        Vector3 forwardMovement = transform.forward * verticalInput;
        Vector3 rightMovement = transform.right * horizontalInput;


        Vector3 movementDirection = Vector3.ClampMagnitude(forwardMovement + rightMovement, 1.0f);

        characterController.Move(movementDirection * playerSpeed * Time.deltaTime);

        if (isAbleToJump && isGrounded) 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * -gravity);
        }

        velocity.y -= gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
