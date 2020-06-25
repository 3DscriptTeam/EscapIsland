using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text _text;
    float timeleft = 100;
   

    void Start()
    {
        _text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        _text.text = "TIME LEFT : " + Math.Truncate(timeleft*10)/10;
        if (timeleft <= 0 )
        {
          
            timeleft = 0;
        }

    }

}





