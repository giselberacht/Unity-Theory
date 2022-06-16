using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    List<int> numberList;
    public Transform[] fieldArray;
    public GameObject board;
    public List<List<Transform>> lineList;
    public List<Transform> line;
    public List<List<Transform>> rowList;
    public List<Transform> row;
    public List<List<Transform>> squareList;
    public List<Transform> square;
    SpriteRenderer sprite;
    int agro;

    void Start()
    {

        lineList = new List<List<Transform>>();
        rowList = new List<List<Transform>>();
        squareList = new List<List<Transform>>();
        FieldArrayFill();
        LineListFill();
        RowListFill();
        SquareListFill();
        
        //LineLog();
        //SquareLog();
        //RowLog();
        ValueFill();


        //RowCheck();
    }


    bool ListCheck(int checkedValue, int index , List<List<Transform>> list)
    {
        index = index - 1;
        Debug.Log(index + list.Count);
        int temp;
        {
            //foreach (List<Transform> square in list)
            //{
            
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
            
            //}
            return true;
        }
    }
    void ValueFill()
    {
        Debug.Log("start wartosci");
        for (int i = 1; i <= 82; i++)
        {
            Debug.Log(i + "pozycja");
            RandomValueFill(fieldArray[i]);
        }

    }
    void RandomValueFill(Transform field)
    {
        int temp;
        int i = 0;
        int tindex ;
        FieldInfo fieldInfo = field.GetComponent<FieldInfo>();
        numberList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        bool test;
        tindex = UnityEngine.Random.Range(0, numberList.Count);
        temp = numberList[tindex];
        Debug.Log(field);
            
        for(;i==0;)
        {
            
            tindex = UnityEngine.Random.Range(0, numberList.Count);
            temp = numberList[tindex];
            //Debug.Log(temp);
            test = Dcheck(temp, field);
            field.GetComponent<FieldInfo>().value = temp;
            //Dcheck(temp, field);
            if (test == true)
            {
                i = 5;
                sprite = field.GetComponent<SpriteRenderer>();
                sprite.color = new Color(100, 0, 0);
            }

            else
            {
                Debug.Log("cut");
                numberList.RemoveAt(tindex);
            }
           
        }

    }


    bool Dcheck(int temp, Transform field)
    {
        bool test = false;
        if (ListCheck(temp, (int)field.position.x, rowList) == true)
        {
            Debug.Log("uno " + "temp =" + temp + ListCheck(temp, (int)field.position.x, rowList));
            
            if(ListCheck(temp, Mathf.Abs((int)field.position.y), lineList) == true)
            {
                Debug.Log("duo " + "temp =" + temp +  ListCheck(temp, (int)field.position.x, rowList));
                
                if(ListCheck(temp, (int)field.position.z, squareList) == true)
                {
                    Debug.Log("tri " + "temp =" + temp +  ListCheck(temp, (int)field.position.x, rowList));
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
    public void FieldArrayFill()
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
    public void LineListFill()
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
    public void RowListFill()
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
            rowList.Add(row);
        }
    }
    public void SquareListFill()
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
    private void RowLog()
    {
        foreach (List<Transform> test in rowList)
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

    
}