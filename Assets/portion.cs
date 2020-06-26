using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class portion : MonoBehaviour
{
    public Image img;
    public float cooltime = 5f;
    public PlayerController PC;
    float leftTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        if(PC.portion)
        {
            leftTime -= Time.deltaTime; 
            float ratio = 1.0f - (leftTime/ cooltime);
            img.fillAmount= ratio;
        }
        if(leftTime==0 && PC.portion==true)
            leftTime = 60.0f;

    }                

}
