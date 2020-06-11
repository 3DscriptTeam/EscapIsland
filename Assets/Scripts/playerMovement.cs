using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Vector3 movement;
    Quaternion Rotation = Quaternion.identity;
    // Start is called before the first frame update
    void Start()
    {
        
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


    }
}
