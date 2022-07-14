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
    public int difficulty;
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
        StartCoroutine(ErrorFix());
    }

    private void ErrorFixLoop()
    {
        loopCount++;
        foreach (int square in error)
        {
            FieldZeroing(square);
            Debug.Log($"kwadrat {square} posiada b³êdy");
           
        }
        error = new List<int>();
        ValueFill();
        Debug.Log($"loop count = {loopCount}");
       
    }

    private void Update()
    {
        if (IsDone())
        {

            foreach (Transform field in fieldArray)
            {
                if (field.GetComponent<TMPro.TextMeshPro>() == null)
                    continue;
                field.GetComponent<TMPro.TextMeshPro>().color = Color.green;
            }
        }
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
                if (broken)
                {
                    break;
                }
            }
        }
    }
    void RandomValueFill(Transform field)
    {
        FieldInfo fieldInfo = field.GetComponent<FieldInfo>();
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
                    field.GetComponent<TMPro.TextMeshPro>().text = "0";
                    fieldInfo.value = 0;
                    if (numberList.Count == 0)
                    {
                        
                        if (!error.Contains((int)field.localPosition.z) || error.Capacity == 0)
                        {
                            error.Add((int)field.localPosition.z);
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
        if (ListCheck(temp, (int)field.localPosition.x, columnList) == true)
        {
            
            if(ListCheck(temp, Mathf.Abs((int)field.localPosition.y), lineList) == true)
            {
                
                if(ListCheck(temp, (int)field.localPosition.z, squareList) == true)
                {
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
        foreach (Transform child in board.transform)
        {
            fieldArray[x] = child;
            x++;
        }
    }
    void LineListFill()
    {
        line = new List<Transform>();
        for (int i = 1; i <= 9; i++)
        {
            line = new List<Transform>();
            foreach (Transform field in fieldArray)
            {
                if  (Mathf.Floor(Mathf.Abs((int)field.localPosition.y)).Equals(i))
                {
                    line.Add(field);
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
            row = new List<Transform>();
            foreach (Transform field in fieldArray)
            {
                if (field.localPosition.x.Equals(i))
                {
                    row.Add(field);
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
            square = new List<Transform>();
            foreach (Transform field in fieldArray)
            {
                if (field.localPosition.z.Equals(i))
                {
                    square.Add(field);
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
        }
    }
    void BoardVipe()
    {
        foreach(Transform field in fieldArray)
        {
            field.GetComponent<FieldInfo>().value = 0;
        }
    }

    IEnumerator ErrorFix()
    {
        while(error.Capacity > 0)
        {
            if (loopCount >= 15 /*|| error.Capacity >=6*/)
            {
                loopCount = 0;
                Debug.Log($"za duzo petli!");
                BoardVipe();
                ValueFill();
            }
            ErrorFixLoop();
            //Debug.Break();
        yield return null;
        }
        done = true;
        StopCoroutine(ErrorFix());
    }
    private void ColumnLog()
    {
        foreach (List<Transform> test in columnList)
        {
            agro++;
            foreach (Transform line in test)
                Debug.Log(line.localPosition + " kolumna " + agro);
        }
    }

    private void SquareLog()
    {
        foreach (List<Transform> test in squareList)
        {
            agro++;
            foreach (Transform line in test)
                Debug.Log(line.localPosition + " kwadrat " + agro);
        }
    }

    private void LineLog()
    {
        foreach (List<Transform> test in lineList)
        {
            agro++;
            foreach (Transform line in test)
                Debug.Log(line.localPosition + " linia " + agro);
        }
    }

    bool IsDone()
    {
        return done;
    }

    public void Reset()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    public List<int> indexList = new List<int> { };
    
    
    public void HiddenFieldGeneretor()
    {
        for (int i = 1; i <= 82; i++)
        {
            indexList.Add(i);
        }
        switch (difficulty)
        {
            case 0:     //Easy
                FieldSelection(20);
                break;
            case 1:     //Normal
                FieldSelection(25);
                break;
            case 2:     //Hard
                FieldSelection(30);
                break;
        }

    }
    public void EasyMode()
    {
        difficulty = 0;
        HiddenFieldGeneretor();
    }
    public void Mediummode()
    {
        difficulty = 1;
        HiddenFieldGeneretor();
    }
    public void HardMode()
    {
        difficulty = 2;
        HiddenFieldGeneretor();
    }

    void FieldSelection(int hiddenAmount)
    {
        for (int i = 1; i != hiddenAmount; i++)
        {
            int index;
            index = indexList[Random.Range(1, indexList.Count)];
            indexList.Remove(index);
            fieldArray[index].GetComponent<TMPro.TextMeshPro>().enabled = false;
        }
    }

}
