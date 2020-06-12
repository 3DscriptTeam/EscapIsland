using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera_Action : MonoBehaviour
{
    public float offsetX = 0f;
    public float offsetY = 25f;
    public float offsetZ = -35f;

    Vector3 cameraPosition;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        cameraPosition.x = player.transform.position.x + offsetX;
        cameraPosition.y = player.transform.position.x + offsetY;
        cameraPosition.z = player.transform.position.x + offsetZ;

        transform.position = cameraPosition;
    }
}
