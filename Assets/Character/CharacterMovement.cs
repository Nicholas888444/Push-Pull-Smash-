using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    //Movement
    public float moveSpeed;
    public float groundDrag;

    //Ground Check
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    //Jumping
    public float jumpForce;
    public float jumpCoolDown;
    public float airMultiplier;
    bool readyToJump;
    public KeyCode jumpKey = KeyCode.Space;


    public Transform orienation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;
    public bool grappling, booped;
    public bool working;
    private Transform currentPlatform;
    private Vector3 previousPlatformPosition;
    private bool oneFrame = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
    }

    private void MyInput() {
        if(!working)
            return;
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(jumpKey) && readyToJump && grounded) {
            //print("It worked");
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCoolDown);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        grounded = Physics.Raycast(transform.position, Vector3.down, out hit, playerHeight*0.5f + 0.2f, whatIsGround);
        currentPlatform = hit.transform;
        
        
        //print(grounded);
        MyInput();
        //SpeedControl();
        MovePlayer();
        //handle drag
        if(grounded && !grappling && !booped) {
            rb.drag = groundDrag;
            //SpeedControl();
        } else {
            rb.drag = 0;
        }
        //CheckMovingPlatforms();
    }

    void FixedUpdate() {
        CheckMovingPlatforms();
    }

    private void MovePlayer() {

        // calaculate movement direction
        moveDirection = orienation.forward * verticalInput + orienation.right * horizontalInput;
        
        if(grounded) {
            rb.AddForce(moveDirection * moveSpeed * 10.0f * Time.deltaTime, ForceMode.Force);
        } 
        else if(!grounded) {
            rb.AddForce(moveDirection * moveSpeed * 10.0f * airMultiplier * Time.deltaTime, ForceMode.Force);
        }
            

    }

    private void SpeedControl() {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed) {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;

            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump() {
        //Reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);


    }

    private void ResetJump() {
        readyToJump = true;
    }

    public void DelaySpeed() {
        booped = true;
        Invoke("TurnSpeed", 1.0f);
    }

    private void TurnSpeed() {
        booped = false;
    }

    private void CheckMovingPlatforms() {
        if(grounded) {
            if(oneFrame) {
                Vector3 platformPosition = currentPlatform.position;

                Vector3 positionDifference = previousPlatformPosition - platformPosition;
                transform.position -= positionDifference;
                
                previousPlatformPosition = platformPosition;
            } else {
                oneFrame = true;
                previousPlatformPosition = currentPlatform.position;
            }
            

        } else {
            oneFrame = false;
        }
    }



}
