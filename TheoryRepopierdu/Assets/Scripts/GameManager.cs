using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject crossPrefab;
    [SerializeField] public GameObject circlePrefab;
    [SerializeField] public Animation animation;

    public static GameManager Instance;

    [HideInInspector] public bool circleTurn;
    [HideInInspector] public bool crossTurn;
    [HideInInspector] public bool circleVictory=false;
    [HideInInspector] public bool crossVictory=false;
    [SerializeField] GameObject circleIndicator;
    [SerializeField] GameObject crossIndicator;
    [SerializeField] TMPro.TextMeshProUGUI victoryBanner;
    [SerializeField] GameObject[] lineDraw = new GameObject[3];
    [SerializeField] GameObject[] columnDraw = new GameObject[3];
    [SerializeField] GameObject[] curveDraw = new GameObject[2];

    public BoardSpace[] boardSpace  = new BoardSpace[10];
    string victor;
    int moves;


    private void Awake()
    {
        Instance = this;
        NewGame();        
    }

    void Start()
    {
        if(InterstitialAdExample.instance.repeats >= 5)
        {
            InterstitialAdExample.instance.repeats = 0;
            InterstitialAdExample.instance.LoadAd();
            InterstitialAdExample.instance.ShowAd();
        }
        RandomFirstPlayer();
        animation.Play("BoardSetup");        
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

    public void GameOverCheck() //dodac opcje remisu
    {
        DrawCheck();
        LineCheck();
        ColumnCheck();
        CurveCheck();
        VictoryCheck();
        victoryBanner.text = victor;
    }

    private void DrawCheck()
    {
        moves++;
        if (moves >= 9)
        {
            victor = "DRAW";
            animation.Play("EndGame");
            InterstitialAdExample.instance.repeats += 1;
        }
    }

    void LineCheck()
    {
        for (int i = 0; i < 7; i += 3)
        {
            int line = (i / 3);
            if(boardSpace[1+i].isCircle&& boardSpace[2+i].isCircle&& boardSpace[3+i].isCircle)
            {
                circleVictory = true;
                lineDraw[line].SetActive(true);
                Debug.Log("Circle Line!!!");
            }

        }
        for (int i = 0; i < 7; i += 3)
        {
            int line = (i / 3);
            if (boardSpace[1+i].isCross && boardSpace[2+i].isCross && boardSpace[3+i].isCross)
            {
                crossVictory = true;
                lineDraw[line].SetActive(true);
                Debug.Log("Cross Line!!!");
            }

        }
    }

    void ColumnCheck() 
    {
        for (int i = 0; i < 4; i += 1)
        {
            int line = (i-1);
            if (boardSpace[i].isCircle && boardSpace[3 + i].isCircle && boardSpace[6 + i].isCircle)
            {
                circleVictory = true;
                columnDraw[line].SetActive(true);
                Debug.Log("Circle Column!!!");
            }

        }
        for (int i = 0; i < 4; i += 1)
        {
            int line = (i-1);
            if (boardSpace[i].isCross && boardSpace[3 + i].isCross && boardSpace[6 + i].isCross)
            {
                crossVictory = true;
                columnDraw[line].SetActive(true);
                Debug.Log("Cross Column!!!");
            }

        }
    }

    void CurveCheck()
    {
        if (boardSpace[1].isCircle && boardSpace[5].isCircle && boardSpace[9].isCircle)
        {
            circleVictory = true;
            curveDraw[0].SetActive(true);
            Debug.Log("Circle Curve!!!");
        }
        if (boardSpace[3].isCircle && boardSpace[5].isCircle && boardSpace[7].isCircle)
        {
            circleVictory = true;
            curveDraw[1].SetActive(true);
            Debug.Log("Circle Curve!!!");
        }
        if (boardSpace[1].isCross && boardSpace[5].isCross && boardSpace[9].isCross)
        {
            curveDraw[0].SetActive(true);
            crossVictory = true;
            Debug.Log("Cross Curve!!!");
        }
        if (boardSpace[3].isCross && boardSpace[5].isCross && boardSpace[7].isCross)
        {
            curveDraw[1].SetActive(true);
            crossVictory = true;
            Debug.Log("Cross Curve!!!");
        }
    }

    void VictoryCheck()
    {
        if (circleVictory)
        {
            animation.Play("EndGame");
            victor = "Circle wins!";
            InterstitialAdExample.instance.repeats += 1;
        }
        if (crossVictory)
        {
            animation.Play("EndGame");
            victor = "Cross wins!";
            InterstitialAdExample.instance.repeats += 1;
        }
        
    }

    void NewGame()
    {
        circleTurn = false;
        crossTurn = false;
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
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
