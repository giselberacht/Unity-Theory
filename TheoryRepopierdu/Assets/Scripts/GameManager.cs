using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject crossPrefab;
    [SerializeField] public GameObject circlePrefab;
    [SerializeField] Animation endAnimation;

    public static GameManager Instance;

    [HideInInspector] public bool circleTurn;
    [HideInInspector] public bool crossTurn;
    [HideInInspector] public bool circleVictory=false;
    [HideInInspector] public bool crossVictory=false;
    [SerializeField] GameObject circleIndicator;
    [SerializeField] GameObject crossIndicator;
    public BoardSpace[] boardSpace  = new BoardSpace[10];
    string Victor;


    private void Awake()
    {
        Instance = this;
        NewGame();        
    }

    void Start()
    {
        RandomFirstPlayer();
    }

    void Update()
    {
        IndicatorActivator();
    }

    void RandomFirstPlayer()
    {
        int r = Random.Range(1, 3);
        if (r == 1)
        {
            crossTurn = true;
        }
        else
        {
            circleTurn = true;
        }
    }

    void IndicatorActivator()
    {
        if (circleTurn)
        {
            circleIndicator.gameObject.SetActive(true);
            crossIndicator.gameObject.SetActive(false);
        }
        if (crossTurn)
        {
            circleIndicator.gameObject.SetActive(false);
            crossIndicator.gameObject.SetActive(true);
        }
    }

    public void GameOverCheck()
    {
        LineCheck();
        ColumnCheck();
        CurveCheck();
        VictoryCheck();
    }

    void LineCheck()
    {
        for (int i = 0; i < 7; i += 3)
        {
            if(boardSpace[1+i].isCircle&& boardSpace[2+i].isCircle&& boardSpace[3+i].isCircle)
            {
                circleVictory = true;
                Debug.Log("Circle Line!!!");
            }

        }
        for (int i = 0; i < 7; i += 3)
        {
            if (boardSpace[1+i].isCross && boardSpace[2+i].isCross && boardSpace[3+i].isCross)
            {
                crossVictory = true;
                Debug.Log("Cross Line!!!");
            }

        }
    }

    void ColumnCheck() 
    {
        for (int i = 0; i < 4; i += 1)
        {
            if (boardSpace[i].isCircle && boardSpace[3 + i].isCircle && boardSpace[6 + i].isCircle)
            {
                circleVictory = true;
                Debug.Log("Circle Column!!!");
            }

        }
        for (int i = 0; i < 4; i += 1)
        {
            if (boardSpace[i].isCross && boardSpace[3 + i].isCross && boardSpace[6 + i].isCross)
            {
                crossVictory = true;
                Debug.Log("Cross Column!!!");
            }

        }
    }

    void CurveCheck()
    {
        if (boardSpace[1].isCircle && boardSpace[5].isCircle && boardSpace[9].isCircle || boardSpace[3].isCircle && boardSpace[5].isCircle && boardSpace[7].isCircle)
        {
            circleVictory = true;
            Debug.Log("Circle Curve!!!");
        }
        if (boardSpace[1].isCross && boardSpace[5].isCross && boardSpace[9].isCross || boardSpace[3].isCross && boardSpace[5].isCross && boardSpace[7].isCross)
        {
            crossVictory = true;
            Debug.Log("Cross Curve!!!");
        }
    }

    void VictoryCheck()
    {
        if (circleVictory)
        {
            endAnimation.Play();
            Victor = "Circle wins!";
        }
        if (crossVictory)
        {
            endAnimation.Play();
            Victor = "Cross wins!";
        }
    }

    void NewGame()
    {
        circleTurn = false;
        crossTurn = false;
    }

    void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    [System.Serializable]
    public struct BoardSpace
    {
        public int spaceIndex;
        public bool isCircle;
        public bool isCross;

        public BoardSpace(int spaceIndex, bool isCircle, bool isCross)
        {
            this.spaceIndex = spaceIndex;
            this.isCircle = isCircle;
            this.isCross = isCross;
        }
    }
}
