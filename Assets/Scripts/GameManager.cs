using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Questions[] questions;  //모든 질문 담은 array
    private static List<Questions> unansweredQuestions; 

    private Questions currentQuestions;

    [SerializeField]
    private Text factText;

    [SerializeField]
    private Text resultText;
    //[SerializeField]
    //private Text number2Text;
    //[SerializeField]
    //private Text number3Text;


    [SerializeField]
    private float timeBetweenQuestions = 2f;  // 1 sec


    private void Start()
    {
        resultText.enabled = false;
        if (unansweredQuestions ==null || unansweredQuestions.Count==0)
         {
            unansweredQuestions = questions.ToList<Questions>();
         }

        SetCurrentQuestions();

    }

    void SetCurrentQuestions()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestions = unansweredQuestions[randomQuestionIndex];

        factText.text = currentQuestions.fact;
        //if(currentQuestions.answer==1)
        //{
        //    number1Text.text = "정답!";
        //    number2Text.text = "땡!";
        //    number3Text.text = "땡!";
        //}
        //else if(currentQuestions.answer == 2)
        //{
        //    number2Text.text = "정답!";
        //    number1Text.text = "땡!";
        //    number3Text.text = "땡!";
        //}
        //else if (currentQuestions.answer == 3)
        //{
        //    number3Text.text = "정답!";
        //    number1Text.text = "땡!";
        //    number2Text.text = "땡!";
        //}

    }

    IEnumerator TransitionsToNextQuestions()            // 한문제가 끝난 이후 
    {
        if (currentQuestions.isTrue == true)
        {
            resultText.text = "ㅇ";
            resultText.color = Color.blue;
        }
        else if (currentQuestions.isTrue == false)
        {
            resultText.text = "X";
            resultText.color = Color.red;
        }
        unansweredQuestions.Remove(currentQuestions);
        resultText.enabled = true;
        yield return new WaitForSeconds(timeBetweenQuestions);

        resultText.enabled = false;
        //SceneManager.LoadScene("StarterScene");               
        //동영상에선 다시 자기자신의 화면으로 돌아오라함


    }


    public void UserSelecT_1()
    {
        if (currentQuestions.answer == 1)
            currentQuestions.isTrue = true;
        else
            currentQuestions.isTrue = false;

        StartCoroutine(TransitionsToNextQuestions());
    }

    public void UserSelecT_2()
    {
        if (currentQuestions.answer == 2)
        {
            currentQuestions.isTrue = true;

        }
        else
            currentQuestions.isTrue = false;

        StartCoroutine(TransitionsToNextQuestions());
    }

    public void UserSelecT_3()
    {
        if (currentQuestions.answer == 3)
            currentQuestions.isTrue = true;
        else
            currentQuestions.isTrue = false;

        StartCoroutine(TransitionsToNextQuestions());
    }

}
