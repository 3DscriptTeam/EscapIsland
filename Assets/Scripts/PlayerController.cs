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


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
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
        
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;

        }
        else if(desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
       transform.position = targetPosition;
        //Vector3.Lerp(transform.position, targetPosition, 80 * Time.deltaTime);

    }
    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }
}
