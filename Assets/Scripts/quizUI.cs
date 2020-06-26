using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quizUI : MonoBehaviour
{
    public GameObject quizCanvas;
    public bool quizActivated;
    // Start is called before the first frame update
    void Start()
    {
        //quizCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (quizActivated)
        {
            quizCanvas.SetActive(quizActivated);
        }
    }

    public void ShowUp()
    {
        quizActivated = true;
    }
}
