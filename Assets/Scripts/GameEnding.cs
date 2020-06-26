using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{

    public Transform player;

    public float fadeDuration = 1f;
    public float imageDisplayDuration = 3f;
    float timer;

    public CanvasGroup gameEndingImageCanvasGroup;
    public CanvasGroup playerWinImageCanvasGroup;

    bool isPlayerDead = false;
    bool isPlayerExit=false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void playerTouchedObstacles()
    {
        isPlayerDead = true;
    }

    public void playerWin()
    {
        isPlayerExit = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="player")
        {
            isPlayerDead = true;
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestat)
    {
        timer = timer + Time.deltaTime;
        imageCanvasGroup.alpha = timer / fadeDuration;

        if(timer> fadeDuration+ imageDisplayDuration)
        {
             SceneManager.LoadScene("StartMenu");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerDead)  // 플레이어 죽음
        {
            EndLevel(gameEndingImageCanvasGroup, true);
        }
        else if(isPlayerExit)   // 플레이어가 탈출함(성공)
        {
            EndLevel(playerWinImageCanvasGroup,false);
        }
    }
}
