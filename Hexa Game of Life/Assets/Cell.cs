using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Cell
{
    public Vector2 position;
    public bool alive=false;

    public Cell()
    {
        alive = false;
        position = Vector2.zero;
    }
    public Cell(Vector2 pos)
    {
        alive = false;
        position = pos;
    }
}
