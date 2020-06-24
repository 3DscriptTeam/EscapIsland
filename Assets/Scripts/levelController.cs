using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelController : MonoBehaviour
{
    //"랜덤한 장애물들"이 팝업한다 -> 랜덤한 위치지만 규칙적인 간격하에 놓여짐  5m -> 10m ->15m  
    // 왼쪽라인, 중간라인, 오른쪽라인 중 어디에 나올지 고른다
    // 몇개가 나오는건지 고른다


    [System.Serializable]
    public class LevelPiece
    {
        public string name;
        public GameObject prefab;
        public int probability = 1;
    }



    public LevelPiece[] obstacles;  //장애물 
    List<int> probabilityList= new List<int>();
    List<int> probabilityList_land = new List<int>();
    int numberOfObstacles;  // 팝업 개수        
    int locationOfObstacles;   // 장애물의 종류

    public LevelPiece[] levelPieces;
    public Transform _camera;
    public int drawDistance;
    public int drawObstacles;

    bool bridgeOnStage = true;   //다리가 있으면 블록이랑 철망 위치 조정해야함...

    public float pieceLength;
    public float speed;

    bool firstTimePlaying = false;

    Queue<GameObject> activePieces =new Queue<GameObject>();
    Queue<GameObject> activeObstacles = new Queue<GameObject>();
    int currentCamStep = 0;
    int lastCamStep = 0;

    float brigdgeLoc = 0;
    int i = 0;
    int j = 0;
    float logSaving;

    private void Start()
    {
        bridgeOnStage = true;
        BuidProbabilityList();
        for (int i = 0; i < drawDistance; i++)
        {
            SpawnNewLevelPiece();
            if(i>5)
                SpawnObstacles();
            bridgeOnStage = true;
        }

        currentCamStep = (int)(_camera.transform.position.z / pieceLength);
        lastCamStep = currentCamStep;

    }

    private void Update()
    {

         _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, _camera.transform.position + Vector3.forward, Time.deltaTime * speed);

        logSaving += _camera.transform.position.z;
        currentCamStep = (int)(_camera.transform.position.z / pieceLength);
        Debug.Log("camera distance:"+_camera.transform.position.z.ToString());
        Debug.Log("currentCamStep:" + currentCamStep.ToString());
        firstTimePlaying = logSaving > 4f ? true: false;
        if (currentCamStep != lastCamStep)
        {
            lastCamStep = currentCamStep;
            DespawnLevelPiece();
            
            SpawnNewLevelPiece();
            
            if (firstTimePlaying == true)
            {
                bridgeOnStage = false;
                SpawnObstacles();
                DespawnObstaclesPiece();
            }   
            
        }

    }

    void SpawnObstacles()   //장애물 배치
    {
        int pieceIndex = probabilityList[Random.Range(0, probabilityList.Count)];
        if (pieceIndex != 0)   //철조망 빼고 나머지 장애물의 경우      -1.37 ~1.37
        {
            int locationOfObstacles = Random.Range(-1,1);
            float loc = 1.37f * locationOfObstacles;
            if (bridgeOnStage==true)
            {
                loc = brigdgeLoc;
            }                                                                                                                                                                            
            GameObject hurdle = Instantiate(obstacles[pieceIndex].prefab, new Vector3(loc, 0f, pieceLength * (currentCamStep + activePieces.Count)), Quaternion.identity);
            hurdle.name = "hurdle"+i.ToString();
            i++;
            activeObstacles.Enqueue(hurdle);
        }
        else       //철조망
        {
            GameObject hurdle = Instantiate(obstacles[pieceIndex].prefab, new Vector3(0f, 0f, pieceLength * (currentCamStep + activePieces.Count)), Quaternion.identity);
            hurdle.name = "hurdle" + i.ToString();
            i++;
            activeObstacles.Enqueue(hurdle);
        }
        //activeObstacles.Enqueue(hurdle);
    }

    void SpawnNewLevelPiece()     // 지면 배치 -> 현재 끝없이 나오는버전
    {
        
        int pieceIndex = probabilityList_land[Random.Range(0, probabilityList_land.Count)];
        if (pieceIndex == 1) //Bridge 의 경우
        {
            bridgeOnStage = true;
            brigdgeLoc = Random.Range(-1, 1) * 1.37f;
        }
        else
            brigdgeLoc = 0f;
        GameObject newLevelPiece = Instantiate(levelPieces[pieceIndex].prefab, new Vector3(brigdgeLoc, 0f, pieceLength * (currentCamStep +activePieces.Count)), Quaternion.identity);
        newLevelPiece.name = "platform" + j.ToString();
        j++;
        activePieces.Enqueue(newLevelPiece);
    }

    void DespawnLevelPiece()    // 뒤에떨 없애주고 앞애껄 그만큼 만드는 방식
    {
        GameObject oldLevelPiece = activePieces.Dequeue(); 
        
        Destroy(oldLevelPiece);
    }

    void DespawnObstaclesPiece()
    {
        if (activeObstacles.Count > 0)
        {
            GameObject oldLevelObstacles = activeObstacles.Dequeue();
            if(oldLevelObstacles.transform.position.z-_camera.transform.position.z <0.1)
                Destroy(oldLevelObstacles);
        }
    }

    void BuidProbabilityList()      //장애물 확률 조정 함수
    {
        int index = 0;
        int index_ground = 0;
        foreach(LevelPiece piece in obstacles)           //probabilityList: 장애물
        {
            for(int i=0; i<piece.probability; i++)
            {
                probabilityList.Add(index);
            }
            index++;
        }

        foreach (LevelPiece piece in levelPieces)           //probabilityList_land : 바닥용
        {
            for (int i = 0; i < piece.probability; i++)
            {
                probabilityList_land.Add(index_ground);
            }
            index_ground++;
        }
    }

}

