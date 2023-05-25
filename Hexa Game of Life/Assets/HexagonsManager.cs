using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HexagonsManager : MonoBehaviour
{
    public List<Hexagon> hexagons = new List<Hexagon>();

    private void Start()
    {
        hexagons = GetComponent<HexagonalGridGenerator>().hexagons;
        //UpdateColors();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            Iterate();
        }
    }
    [ContextMenu("Iterate")]
    public void Iterate()
    {
        foreach (Hexagon i in hexagons)
        {

            List<Vector2> neighbors = GetNeighbors(i);
            //RULES... WITHOUT THEM WE LIVE WITH THE ANIMALS
            //Each cell with one or no neighbors dies from isolation.
            //Each cell with three or more neighbors dies from overpopulation.
            //Only the cells with two neighbors survives.
            //Each cell with two neighbors revives.

            if (AliveNeighborsCount(neighbors) == 2)
            {
                //live
                i.nextAlive=true;
            }
            else
            {
                //die
                i.nextAlive=false;
            }
        }
        UpdateColors();

        foreach (Hexagon i in hexagons)
        {

            i.UpdateAlive();
        }
        
    }
    
    public int AliveNeighborsCount(List<Vector2> list)
    {
        int count = 0;
        foreach(Vector2 v in list)
        {
            if (IsAlive(v))
            {
                count++;
            }

        }

       if(count>0) Debug.Log(count);
        return count;
    }
    public bool IsAlive(Vector2 v)
    {
        foreach ( Hexagon hexagon in hexagons)
        {
            if(hexagon.cell.position==v)
            return hexagon.IsAlive(v);

        }

        return false;
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
        return hexagons[(int)position.x * (int)position.y];
    }
    public List<Vector2> GetNeighbors(Hexagon hexagon)
    {

        List<Vector2> neighbors = new List<Vector2>();
        //Debug.Log(hexagon.cell.position);

        if (hexagon.cell.position.y % 2 == 0)
        {
            foreach (Vector2Int offset in NeighborOffsetsEven)
            {
                Vector2 neighborPosition = hexagon.cell.position + offset;
                neighbors.Add(neighborPosition);
                //Debug.Log(neighborPosition);
            }

        }
        else
        {

            foreach (Vector2Int offset in NeighborOffsetsOdd)
            {
                Vector2 neighborPosition = hexagon.cell.position + offset;
                neighbors.Add(neighborPosition);
                //Debug.Log(neighborPosition);
            }

        }


        return neighbors;
    }
    private static readonly Vector2Int[] NeighborOffsetsOdd = new Vector2Int[]
    {
        //spiked top
        //If(odd)
        new Vector2Int(1, 0),   // Right
        new Vector2Int(1, 1),  // Top Right
        new Vector2Int(0, 1),  // Top Left
        new Vector2Int(-1, 0),  // Left
        new Vector2Int(0, -1),  // Bottom Left
        new Vector2Int(1, -1)    // Bottom Right

    }; private static readonly Vector2Int[] NeighborOffsetsEven = new Vector2Int[]
    {
        //spiked top
        //If(odd)
        new Vector2Int(1, 0),   // Right
        new Vector2Int(0, 1),  // Top Right
        new Vector2Int(-1, 1),  // Top Left
        new Vector2Int(-1, 0),  // Left
        new Vector2Int(-1, -1),  // Bottom Left
        new Vector2Int(0, -1)    // Bottom Right

    };
}
