using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="player")
        {
            Debug.Log("물약 마심!");
        }
    }
=======
public class item
{
    public enum ItemType
    {
        Speed,
        Plustime,
        answer
    }



    public ItemType itemType;
    public int amount;

>>>>>>> master
}
