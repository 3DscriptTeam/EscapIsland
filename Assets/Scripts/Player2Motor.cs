using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Motor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;
    
    private float speed = 5.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController> ();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = Vector3.zero;

        if(controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity* Time.deltaTime;
        }



        //X - 왼쪽 오른쪽
        moveVector.x = Input.GetAxisRaw("Horizontal")* speed;
        //Y - 위 아래
        moveVector.y = verticalVelocity;
        //Z-  앞뒤이긴 한데 여기선 안쓰지
        moveVector.z = speed;

        controller.Move(Vector3.forward * Time.deltaTime);
    }
}
