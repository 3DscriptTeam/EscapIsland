using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Vector3 movement;
    Quaternion Rotation = Quaternion.identity;

    Rigidbody playerRigidbody;
    public float speed = 10f;
    public float turnSpeed = 20f;
    public float jumpPower = 5f;
    bool isJumping;
    float horizontalMove;
    float verticalMove;
    private int desiredLane = 1; // 0 왼쪽 , 1 가운데 2 오른쪽
    public float laneDistance = 4; // the distance between two lane


    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log("플레이어가 아무 키를 눌렀습니다.");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("왼쪽으로 이동 중");

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("오른쪽 이동 중");
        }

        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
        
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement.Set(horizontal, 0f, vertical);
        movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);


        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.deltaTime, 0f);
        Rotation = Quaternion.LookRotation(desiredForward);
        
    }

    void FixedUpdate()
    {
        
        Run();
        Jump();
    }


    

    void Run()
    {
        movement.Set(horizontalMove, 0, verticalMove);
        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);

    }

    void Jump()
    {
        if (!isJumping)
            return;
        playerRigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

        isJumping = false;
    }

}

    