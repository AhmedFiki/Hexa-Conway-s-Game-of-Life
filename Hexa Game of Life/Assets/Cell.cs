using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Cell
{
    public Vector2 position;
    public bool state;

    public Cell(Vector2 pos)
    {
        state = false;
        position = pos;
    }
}
