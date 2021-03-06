﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed=0;

    private int desiredLane = 1; // 0 왼쪽 , 1 가운데 2 오른쪽
    public float laneDistance = 4; // the distance between two lane

    public float jumpForce;
    private float timer;
    public GameObject item;
    int count = 0;

    bool booster;
    //중력 추가 구현을 위한 변수들
    public float gravity = -9.81f;
    Vector3 velocity;

    //허들 인식용
    bool isTouched;
    public GameEnding gameEnding;
    public bool portion;

    void Start()
    {
        controller = GetComponent<CharacterController>();

    }
    public void OnControllerColliderHit(ControllerColliderHit other)
    {
       // Debug.Log(other.gameObject.name.ToString() + "과 일단은 닿았다..");
        if (other.gameObject.tag == "obstacle")
        {
            //Debug.Log("player과 닿았다!");
            isTouched = true;
            forwardSpeed = 0f;
        }
        else if(other.gameObject.tag=="item")
        {
           // Debug.Log("물약마심!");
            forwardSpeed += 2f;
            booster = true;
            count++;
            other.gameObject.SetActive(false);
            portion = true;
        }
      
    }

    // Update is called once per frame
    void Update()
    {
     
        if (booster)
        {
            timer += Time.deltaTime;
            if (timer %5==0  && count>0)
            {
                if(count==0)
                    booster = false;
                forwardSpeed -= 2;
                count--;
            }
        }
        if (isTouched)
        {
            gameEnding.playerTouchedObstacles();
        }
        if (controller.isGrounded)
        {
            direction.y = -1;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime;

        }

        direction.z = forwardSpeed;
        // 우리가 있어야 할 라인
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }

        }

        //추가한것
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;


        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;

        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.deltaTime);
       
        controller.center = controller.center;


        //velocity.y += gravity * Time.deltaTime;
        //if (!controller.isGrounded)
        //{
        //    controller.Move(velocity * Time.deltaTime);
        //}


    }
    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);

    }

    private void Jump()
    {
        direction.y = jumpForce;
    }
}
