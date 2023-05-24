using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    public Cell cell=new Cell();
    public bool cellSet = false;

    private void Start()
    {
        SetState(cellSet);
    }
    public void SetState(bool alive)
    {
        if (alive)
        {
            SetColor(Color.white);
        }
        else
        {
            SetColor(Color.gray);
        }
    }

    public void SetColor(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
    }
    public void SetCell(Cell c)
    {
        cellSet = true;
        cell = new Cell(c.position);
    }

}
