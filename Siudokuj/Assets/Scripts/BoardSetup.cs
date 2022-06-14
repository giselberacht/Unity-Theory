using System.Collections.Generic;
using UnityEngine;

public class BoardSetup2 : MonoBehaviour
{
    public Transform[] fieldArray;
    public GameObject board;
    public List<List<Transform>> lineList;
    public List<Transform> line;
    public List<List<Transform>> rowList;
    public List<Transform> row;
    public List<List<Transform>> squareList;
    public List<Transform> square;

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
}