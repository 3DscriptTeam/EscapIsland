using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeMoving : MonoBehaviour
{
    private Transform bridgeLoc;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        bridgeLoc = GetComponent<GameObject>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(bridgeLoc.transform.position.x)
        bridgeLoc.transform.position += new Vector3(Time.deltaTime*speed,0,0);    
    }
}
