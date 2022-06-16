using System.Collections.Generic;
using UnityEngine;

public class GameManagerBin : MonoBehaviour
{/*
    List<int> numberList;
    public Transform[] fieldArray;
    public GameObject board;
    public List<List<Transform>> lineList;
    public List<Transform> line;
    public List<List<Transform>> rowList;
    public List<Transform> row;
    public List<List<Transform>> squareList;
    public List<Transform> square;
    bool DoubleCheck(int checkedValue, char group, int index)
    {

        if (group == 'x')
        {
            RowDCheck(checkedValue, index);
        }
        if (group == 'y')
        {
            LineDCheck(checkedValue, index);
        }
        if (group == 'z')
        {
            SquareDCheck(checkedValue, index);
        }
        return true;
    }
    bool RowDCheck(int checkedValue, float index)
    {
        bool error;
        error = false;
        if (checkedValue == 0)
            return false;
        foreach (Transform value in rowList[(int)index])
        {
            int temp;
            temp = value.GetComponent<FieldInfo>().value;
            if (temp == checkedValue)
            {
                error = false;
            }
            else
                error = true;
        }
        if (error)
            return false;
        else
            return true;
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



    bool LineDCheck(int checkedValue, float index)
    {
        bool error;
        error = false;
        int temp;
        if (checkedValue == 0)
            return false;
        foreach (Transform value in lineList[(int)index])
        {
            temp = value.GetComponent<FieldInfo>().value;
            if (temp == checkedValue)
            {
                error = false;
            }
            else
                error = true;
        }
        if (error)
            return false;
        else
            return true;
    }
    bool SquareDCheck(int checkedValue, float index)
    {
        bool error;
        error = false;
        int temp;
        if (checkedValue == 0)
            return false;
        foreach (Transform value in rowList[(int)index])
        {
            temp = value.GetComponent<FieldInfo>().value;
            if (temp == checkedValue)
                error = false;
            else
                error = true;
        }
        if (error)
            return false;
        else
            return true;
    }
    bool DError(int temp, Transform field)
    {
        if (SquareDCheck(temp, field.position.z) && LineDCheck(temp, field.position.y) && RowDCheck(temp, field.position.x))
            return false;
        else
            return true;
    }

    void ValueFill()
    {
        for (int i = 1; i < 82; i++)
        {
            RandomValueFill(fieldArray[i]);
            //Debug.Log(i);
        }
        //foreach(Transform field in fieldArray)
        //{
        //    RandomValueFill(field);
        //}
    }
    void RandomValueFill(Transform field)
    {
        numberList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int temp = 0;
        //while(DError(temp, field))
        //Debug.Log("test");
        {
            int tindex = UnityEngine.Random.Range(0, numberList.Count);
            temp = numberList[tindex];
            numberList.RemoveAt(tindex);
            //Debug.Log(tindex);
        }
        field.GetComponent<FieldInfo>().value = temp;
        foreach (Transform test in lineList[temp])
        {
            Debug.Log(test);
        }


    }
    void NewNumberList()
    {
        numberList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    }
*/}