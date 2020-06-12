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


    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Run(h, v);
    }



    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            Debug.Log("플레이어가 아무 키를 눌렀습니다.");
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("왼쪽으로 이동 중");

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("오른쪽 이동 중");
        }
        /*
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement.Set(horizontal, 0f, vertical);
        movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);


        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.deltaTime, 0f);
        Rotation = Quaternion.LookRotation(desiredForward);
        */
    }

    void Run(float h, float v)
    {
        movement.Set(h, 0, v);
        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);

    }

    

}

