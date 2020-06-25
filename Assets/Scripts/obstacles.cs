using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacles : MonoBehaviour
{
    bool isTouched;
    public GameEnding gameEnding;
    // Start is called before the first frame update
    void Start()
    {
        //gameEnding = GameObject.Find("GameEnd").GetComponent<GameObject>().transform.Find("Wave").GetComponent<GameObject>();
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name.ToString()+"과 일단은 닿았다..");
        if (other.tag=="obstacle")
        {
            Debug.Log("player과 닿았다!");
            isTouched = true; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isTouched)
        {
            gameEnding.playerTouchedObstacles();
        }
    }

}
