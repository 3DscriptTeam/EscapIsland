using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text _text;
    public float timeleft = 100;
    public GameEnding gameEnding;

    void Start()
    {
        _text = GetComponent<Text>();
    }




    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        _text.text = "TIME LEFT : " + (Math.Truncate(timeleft*10)/10);
        if (timeleft <= 80 )
        {
            timeleft = 0;
            gameEnding.playerWin();
        }

    }

}