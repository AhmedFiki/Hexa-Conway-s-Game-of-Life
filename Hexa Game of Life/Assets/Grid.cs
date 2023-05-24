using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Grid 
{
    Vector2Int size;
    public Cell[,] cells;

    public Grid(Vector2Int size)
    {
        this.size = size;
        cells = new Cell[size.x,size.y];
        InitGrid();
    }

    public void InitGrid()
    {
        for (int row = 0; row < size.y; row++)
        {
            for (int col = 0; col < size.x; col++)
            {
                Vector2 position= new Vector2(row, col);
                cells[row,col] = new Cell(position);
            }
        }
    }

    public Cell GetCell(int x, int y)
    {
        return cells[x,y];
    }

}
