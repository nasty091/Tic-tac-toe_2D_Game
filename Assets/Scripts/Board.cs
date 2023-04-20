using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public GameObject cellPrefab;

    public Transform board;
    public GridLayoutGroup gridLayout;

    public int boardSize;

    public string currentTurn = "x";

    private string[,] matrix;

    public void Awake()
    {
        
    }

    public void Start()
    {
        matrix = new string[boardSize + 1, boardSize + 1];

        gridLayout.constraintCount = boardSize;
        CreateBoard();
    }

    private void CreateBoard()
    {
        for(int i = 1; i <= boardSize; i++)
        {
            for(int j = 1; j <= boardSize; j++)
            {
                GameObject cellTransform = Instantiate(cellPrefab, board);
                Cell cell = cellTransform.GetComponent<Cell>();
                cell.row = i;
                cell.column = j;
                matrix[i, j] = "";
            }
        }
    }

    public bool Check(int row, int column)
    {
        matrix[row, column] = currentTurn;
        bool result = false;

        //Check Vertical
        int count = 0;
        for(int i = row - 1; i >= 1; i--) //Up
        {
            if (matrix[i, column] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        for (int i = row + 1; i <= boardSize; i++) //down
        {
            if (matrix[i, column] == currentTurn)
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

        //Check Horizontal
        count = 0;
        for (int i = column - 1; i >= 1; i--) //right
        {
            if (matrix[row, i] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        for (int i = column + 1; i <= boardSize; i++) //down
        {
            if (matrix[row, i] == currentTurn)
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

        //Check Left Diagonal
        count = 0;
        for (int i = column - 1; i >= 1; i--) // left up
        {
            if (matrix[row - (column - i), i] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        for (int i = column + 1; i <= boardSize; i++) // right down
        {
            if (matrix[row + (column - i), i] == currentTurn)
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

        //Check Right Diagonal
        count = 0;
        for (int i = column - 1; i >= 1; i--) // left down
        {
            if (matrix[row + (column - i), i] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        for (int i = column + 1; i <= boardSize; i++) //right up
        {
            if (matrix[row - (column - i), i] == currentTurn)
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
