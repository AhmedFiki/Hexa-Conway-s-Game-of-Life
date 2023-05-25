using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    public Cell cell=new Cell();
    public bool cellSet = false;
    public bool nextAlive = false;

    private void Start()
    {
        SetState(false);
    }

    public void SetState(bool alive)
    {
        if (alive)
        {
            SetColor(Color.white);
            cell.alive = true;
            
        }
        else
        {
            SetColor(Color.gray);
            cell.alive = false;

        }
    }

    public void ToggleState()
    {
        if(cell.alive)
        {
            SetState(false);
        }
        else
        {
            SetState(true);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log(cell.position);
        SetState(true);
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
    public bool IsAlive(Vector2 pos)
    {
        return cell.alive;
    }
    public void UpdateAlive()
    {
        SetState(nextAlive);
    }
}
