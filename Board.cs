using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public GameObject cellPregab;
    
    public Transform board;

    public string currentTurn = "x";
    private string[,] matrix;
    public GridLayoutGroup gridLayout;
    public int boardSize;
    public void Awake()
    {

    }
    public void Start()
    {
        matrix = new string[boardSize + 1,boardSize + 1];
        gridLayout.constraintCount = boardSize;
        CreateBoard();
    }
    private void CreateBoard()
    {
       for(int i = 1;i <= boardSize; i++)
       {
            for(int j = 1; j <= boardSize; j++)
            {
                GameObject cellTransform = Instantiate(cellPregab, board);
                Cell cell = cellTransform.GetComponent<Cell>();
                cell.row = i;
                cell.colum = j;
                matrix[i,j] ="";
            }       
       }
    }
    public bool Check(int row, int colum)
{
    matrix[row, colum] = currentTurn;
    bool result = false;

    // Check hang doc
    int count = 0;
    for (int i = row - 1; i >= 1; i--)
    {
        if (i >= 1 && matrix[i, colum] == currentTurn)
        {
            count++;
        }
        else
        {
            break;
        }
    }
    for (int i = row + 1; i <= boardSize; i++)
    {
        if (i <= boardSize && matrix[i, colum] == currentTurn)
        {
            count++;
        }
        else
        {
            break;
        }
    }
    if (count + 1 >= 5)
    {
        result = true;
    }

    // Check hang ngang
    count = 0;
    for (int i = colum - 1; i >= 1; i--) //trai
    {
        if (i >= 1 && matrix[row, i] == currentTurn)
        {
            count++;
        }
        else
        {
            break;
        }
    }
    for (int i = colum + 1; i <= boardSize; i++) //phai
    {
        if (i <= boardSize && matrix[row, i] == currentTurn)
        {
            count++;
        }
        else
        {
            break;
        }
    }
    if (count + 1 >= 5)
    {
        result = true;
    }

    // check hang cheo 1
    count = 0;
    for (int i = 1; row - i >= 1 && colum - i >= 1; i++) //Cheo tren trai
    {
        if (matrix[row - i, colum - i] == currentTurn)
        {
            count++;
        }
        else
        {
            break;
        }
    }
    for (int i = 1; row + i <= boardSize && colum + i <= boardSize; i++) //Cheo duoi phai
    {
        if (matrix[row + i, colum + i] == currentTurn)
        {
            count++;
        }
        else
        {
            break;
        }
    }
    if (count + 1 >= 5)
    {
        result = true;
    }

    // check hang cheo 2
    count = 0;
    for (int i = 1; row - i >= 1 && colum + i <= boardSize; i++) //Cheo tren phai
    {
        if (matrix[row - i, colum + i] == currentTurn)
        {
            count++;
        }
        else
        {
            break;
        }
    }
    for (int i = 1; row + i <= boardSize && colum - i >= 1; i++) //Cheo duoi trai
    {
        if (matrix[row + i, colum - i] == currentTurn)
        {
            count++;
        }
        else
        {
            break;
        }
    }
    if (count + 1 >= 5)
    {
        result = true;
    }

    return result;
}


    
}
