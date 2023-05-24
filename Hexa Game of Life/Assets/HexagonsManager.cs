using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonsManager : MonoBehaviour
{
    public List<Hexagon> hexagons = new List<Hexagon>();

    private void Start()
    {
        hexagons = GetComponent<HexagonalGridGenerator>().hexagons;
        UpdateColors();
    }

    [ContextMenu("UpdateColors")]
    public void UpdateColors()
    {
       foreach (var hexagon in hexagons)
        {
            hexagon.SetState(false);
        }
    }
    public Hexagon HexagonAt(Vector2 position)
    {
        return hexagons[(int)position.x* (int)position.y];
    }
    public List<Vector2> GetNeighbors(Hexagon hexagon)
    {
        List<Vector2> neighbors = new List<Vector2>();

        //6 neighbors


        return neighbors;
    }

}
