using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    List<int> numberList;
    public Transform[] fieldArray;
    public GameObject board;
    public List<List<Transform>> lineList;
    public List<Transform> line;
    public List<List<Transform>> columnList;
    public List<Transform> row;
    public List<List<Transform>> squareList;
    public List<Transform> square;
    List<int> error;
    //SpriteRenderer sprite;
    int agro;
    bool broken;
    int loopCount;
    bool done;

    void Start()
    {
        Debug.Log("start");
        lineList = new List<List<Transform>>();
        columnList = new List<List<Transform>>();
        squareList = new List<List<Transform>>();
        FieldArrayFill();
        LineListFill();
        ColumnListFill();
        SquareListFill();
        error = new List<int>();
        ValueFill();
        ErrorFixLoop();
        //StartCoroutine(ErrorFix());
        Debug.Break();
        
        Debug.Log($"liczba pêtli {loopCount}");
    }

    private bool ErrorFixLoop()
    {
        while (error.Capacity > 0)
        {
            loopCount++;
            foreach (int square in error)
            {
                FieldZeroing(square);
                Debug.Log($"kwadrat {square} posiada b³êdy");
            }
            error = new List<int>();
            ValueFill();
            if (loopCount >= 30)
            {
                Debug.Log("za duzo petli !!!");
                break;
            }
        }
        done = true;
        return done;
    }

    private void Update()
    {
        
    }

    bool ListCheck(int checkedValue, int index , List<List<Transform>> list)
    {
        index = index - 1;
        int temp;
        {
                foreach (Transform field in list[index])
                {
                    temp = field.GetComponent<FieldInfo>().value;
                    if (checkedValue != 0)
                    {

                        if (temp == checkedValue)
                        {
                            Debug.Log("Kurwa!");
                            return false;
                        }
                    }
                }
            return true;
        }
    }
    void ValueFill()
    {
        for(int i = 0; i <= 8; i++)
        {
            
            for (int s = 0; s <= 8; s++)
            {
                RandomValueFill(lineList[i][s]);
                RandomValueFill(columnList[i][s]);
                RandomValueFill(squareList[i][s]);
                if (broken)
                {
                    i--;
                    //Debug.Log(i + 1);
                    break;
                }
            }
        }
    }
    void RandomValueFill(Transform field)
    {
        FieldInfo fieldInfo = field.GetComponent<FieldInfo>();
        if (error.Capacity > 0)
            done = false;
        if(fieldInfo.value == 0 || broken)
        {
            broken = false;
            int temp;
        int i = 0;
        int tindex ;
        numberList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        bool test;
        tindex = UnityEngine.Random.Range(0, numberList.Count);
        temp = numberList[tindex];
        for(;i==0;)
        {
            tindex = UnityEngine.Random.Range(0, numberList.Count);
            temp = numberList[tindex];
            test = Dcheck(temp, field);
            fieldInfo.value = temp;
            if (test == true)
            {
                i = 5;
                field.GetComponent<TMPro.TextMeshPro>().text = fieldInfo.value.ToString();
            }
            else
            {
                Debug.Log("cut");
                numberList.RemoveAt(tindex);
                    if (numberList.Count == 0)
                    {
                        
                        if (!error.Contains((int)field.position.z) || error.Capacity == 0)
                        {
                            error.Add((int)field.position.z);
                        }

                        broken = true;
                        break; 
                    }

            }
        }
        }
    }


    bool Dcheck(int temp, Transform field)
    {
        bool test = false;
        if (ListCheck(temp, (int)field.position.x, columnList) == true)
        {
            //Debug.Log("uno " + "temp =" + temp + ListCheck(temp, (int)field.position.x, columnList));
            
            if(ListCheck(temp, Mathf.Abs((int)field.position.y), lineList) == true)
            {
                //Debug.Log("duo " + "temp =" + temp +  ListCheck(temp, (int)field.position.x, columnList));
                
                if(ListCheck(temp, (int)field.position.z, squareList) == true)
                {
                    //Debug.Log("tri " + "temp =" + temp +  ListCheck(temp, (int)field.position.x, columnList));
                    test = true;
                }
            }
        }    
        else
            test = false;

        if (test == true)
            return true;
        else
            return false;
    }
    void FieldArrayFill()
    {

        int x = 1;
        //Debug.Log("Field fill started...");
        foreach (Transform child in board.transform)
        {
            //Debug.Log((float)x / 82 * 100 + "%");
            fieldArray[x] = child;
            x++;
        }

    }
    void LineListFill()
    {
        line = new List<Transform>();
        for (int i = 1; i <= 9; i++)
        {
            //Debug.Log(i * 10 + "%");

            line = new List<Transform>();
            foreach (Transform field in fieldArray)
            {
               // Mathf.Floor(field.position.y);
                //Debug.Log(Mathf.Abs((int)field.position.y));
                if  (Mathf.Floor(Mathf.Abs((int)field.position.y)).Equals(i))
                {
                    line.Add(field);
                    //sprite = field.GetComponent<SpriteRenderer>();
                    //sprite.color = new Color(0, 100, 0);
                    //Debug.Log(line.Count);
                }
            }
            Debug.Log("linia");
            lineList.Add(line);
        }
    }
    void ColumnListFill()
    {
        row = new List<Transform>();
        for (int i = 1; i <= 9; i++)
        {
            //Debug.Log(i * 10 + "%");
            row = new List<Transform>();
            foreach (Transform field in fieldArray)
            {
                if (field.position.x.Equals(i))
                {
                    row.Add(field);
                    //Debug.Log(line.Count);
                }
            }
            Debug.Log("kolumna");
            columnList.Add(row);
        }
    }
    void SquareListFill()
    {
        square = new List<Transform>();
        for (int i = 1; i <= 9; i++)
        {
            //Debug.Log(i * 10 + "%");
            square = new List<Transform>();
            foreach (Transform field in fieldArray)
            {
                if (field.position.z.Equals(i))
                {
                    square.Add(field);
                    //Debug.Log(line.Count);
                }
            }
            Debug.Log("kwadrat");
            squareList.Add(square);
        }
    }

    void FieldZeroing(int z)
    {
        foreach (Transform field in squareList[z - 1])
        {
            field.GetComponent<FieldInfo>().value = 0;
            field.GetComponent<TMPro.TextMeshPro>().color = Color.red;
        }
    }

    IEnumerator ErrorFix()
    {
        while(error.Capacity > 0)
        {
        ErrorFixLoop();
        }
        yield return new WaitUntil(IsDone);
    }
    private void ColumnLog()
    {
        foreach (List<Transform> test in columnList)
        {
            agro++;
            foreach (Transform line in test)
                Debug.Log(line.position + " kolumna " + agro);
        }
    }

    private void SquareLog()
    {
        foreach (List<Transform> test in squareList)
        {
            agro++;
            foreach (Transform line in test)
                Debug.Log(line.position + " kwadrat " + agro);
        }
    }

    private void LineLog()
    {
        foreach (List<Transform> test in lineList)
        {
            agro++;
            foreach (Transform line in test)
                Debug.Log(line.position + " linia " + agro);
        }
    }

    bool IsDone()
    {
        return done;
    }

    
}