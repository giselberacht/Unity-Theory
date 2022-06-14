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
        //ValueFill();
        //LineLog();
        //SquareLog();
        //RowLog();
        ValueFill();


        //RowCheck();
    }

    // Update is called once per frame
    void Update()
    {

    }

    bool LineCheck(int checkedValue, float index)
    {
        
        int temp;
        index = index - 1;
        {
            foreach (List<Transform> square in rowList)
            {

                foreach (Transform field in square[(int)index - 1])
                {
                    temp = field.GetComponent<FieldInfo>().value;

                      //if (temp != 0)
                        if (temp == checkedValue)
                        {
                            Debug.Log("Kurwa!");
                        break;
                        }
                }
            }
            return true;
        }
    }
    bool RowCheck(int checkedValue, float index)
    {
        int temp;
        index = index - 1;
        {
            foreach (List<Transform> square in rowList)
            {

                foreach (Transform field in square[(int)index])
                {
                    temp = field.GetComponent<FieldInfo>().value;
                    //if (temp != 0)
                        if (temp == checkedValue)
                        {
                            Debug.Log("Kurwa!");
                        break;
                        }
                        

                }

            }
            return false;
        }
    }
    bool SquareCheck(int checkedValue, float index)
    {
        index = index - 1;
        int temp;
        {
            foreach (List<Transform> square in squareList)
            {

                foreach (Transform field in square[(int)index])
                {
                    temp = field.GetComponent<FieldInfo>().value;
                    //if (temp != 0)
                        if (temp == checkedValue)
                        {
                            Debug.Log("Kurwa!");
                            break;
                        }
                }
            }
            return true;
        }
    }
    void ValueFill()
    {
        for (int i = 1; i < 82; i++)
        {
            RandomValueFill(fieldArray[i]);
            //Debug.Log(i);
        }

    }
    void RandomValueFill(Transform field)
    {
        int temp = 0;
        int i = 0;
        int tindex = 0;
        FieldInfo fieldInfo = field.GetComponent<FieldInfo>();
        numberList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        bool test = false;
            tindex = UnityEngine.Random.Range(0, numberList.Count);
            temp = numberList[tindex];
            test = ZeroTest(field, temp, ref i, tindex);
        for(;i==0;)
        {


            tindex = UnityEngine.Random.Range(0, numberList.Count);
            temp = numberList[tindex];
            Debug.Log(temp);
            field.GetComponent<FieldInfo>().value = temp;
        }

        //SquareCheck(fieldInfo.value, field.position.z);

    }

    private bool ZeroTest(Transform field, int temp, ref int i, int tindex)
    {
        bool test = !Dcheck(temp, field);
        if (temp != 0)
            if (test == false)
            {
                Debug.Log("cut");
                numberList.RemoveAt(tindex);
            }
            else
            {
                sprite = field.GetComponent<SpriteRenderer>();
                sprite.color = new Color(100, 0, 0);
                i = 5;
            }

        return test;
    }

    bool Dcheck(int temp, Transform field)
    {
        if (SquareCheck(temp, field.position.z) && LineCheck(temp, field.position.y) && RowCheck(temp, field.position.x))
        {
            return true;
        }    
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
        for (int i = 9; i >= 1; i--)
        {
            //Debug.Log(i * 10 + "%");
            line = new List<Transform>();
            foreach (Transform field in fieldArray)
            {
                if (field.position.y.Equals(i))
                {
                    line.Add(field);
                    //Debug.Log(line.Count);
                }
            }
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