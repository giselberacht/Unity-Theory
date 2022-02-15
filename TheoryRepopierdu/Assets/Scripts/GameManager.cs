using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject crossPrefab;
    [SerializeField] public GameObject circlePrefab;

    public static GameManager Instance;

    public bool circleTurn;
    public bool crossTurn;
    [SerializeField] GameObject circleIndicator;
    [SerializeField] GameObject crossIndicator;
    public BoardSpace[] boardSpace  = new BoardSpace[10];
    


    private void Awake()
    {
        Instance = this;
        circleTurn = false;
        crossTurn = false;
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
    void LineCheck()
    {

    }
    void ColumnCheck() 
    {
        
    }
    void CurveCheck()
    {

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
