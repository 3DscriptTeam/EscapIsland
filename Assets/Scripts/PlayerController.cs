using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;

    private int desiredLane = 1; // 0 왼쪽 , 1 가운데 2 오른쪽
    public float laneDistance = 4; // the distance between two lane


     //중력 추가 구현을 위한 변수들
    public float gravity= -9.81f;
    Vector3 velocity;

    //허들 인식용
    bool isTouched;
    public GameEnding gameEnding;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }
    public void OnControllerColliderHit(ControllerColliderHit other)
    {
        Debug.Log(other.gameObject.name.ToString() + "과 일단은 닿았다..");
        if (other.gameObject.tag == "obstacle")
        {
            Debug.Log("player과 닿았다!");
            isTouched = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouched)
        {
            gameEnding.playerTouchedObstacles();
        }

        direction.z = forwardSpeed;
        // 우리가 있어야 할 라인
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if(desiredLane == 3)
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
        
        
        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;

        }
        else if(desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.deltaTime);
        controller.center = controller.center;

        velocity.y += gravity * Time.deltaTime;
        if (!controller.isGrounded)
        {
            controller.Move(velocity * Time.deltaTime);
        }


    }
    private void FixedUpdate()
    {
        controller.Move(direction* Time.fixedDeltaTime);
    

    }
}
