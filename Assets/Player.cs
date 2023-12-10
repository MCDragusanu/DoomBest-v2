using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  
    public float movementSpeed;
    public Transform playerOrientation; // Rename the variable
    public Transform playerCamera;
    public Transform gunPosition;
    public LayerMask whatIsGround;
 
    int score;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float jumpMultiplier;
    public KeyCode jumpingKey = KeyCode.Space;
    bool readyToJump = true;
    bool grounded = true;
    public float playerHeight;


    [Header("Weapons")]
    GunSystem gun;
    

   

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        // hitable.healthBar.SetHealth(hitable.hpAmount);
    }

    void getInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpingKey) && readyToJump && grounded)
        {
            readyToJump = false;
            rb.AddForce(playerOrientation.up * jumpForce, ForceMode.Impulse);
            Invoke(nameof(ResetJump), jumpCooldown);
        }

        
    }
    



    
    void movePlayer()
    {
        moveDirection = playerOrientation.forward * verticalInput + playerOrientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * movementSpeed, ForceMode.Force);

    }

    void Update()
    {

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.25f, whatIsGround);
        getInput();
        movePlayer();
        //hitable.healthBar.SetHealth(hitable.hpAmount);
    }

    void speedControl()
    {
        Vector3 flatSpeed = rb.velocity;
        if (flatSpeed.magnitude > movementSpeed)
        {
            Vector3 limited = flatSpeed.normalized * movementSpeed;
            rb.velocity = new Vector3(limited.x, flatSpeed.y, limited.z);
        }
    }

    

    private void ResetJump()
    {
        grounded = false;
        readyToJump = true;
    }

  
    public void incrementScore(int score)
    {
        this.score += score;
    }
}
