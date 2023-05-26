using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class HexagonalGridGenerator : MonoBehaviour
{
    public static HexagonalGridGenerator Instance;
    public Vector2Int gridSize;
    public float cellSize = 1f;
    public float prefapSize = 2f;
    public bool flatTopped = false;
    public GameObject flatHexagonPrefab;
    public GameObject pointedHexagonPrefab;

    public Grid grid;
    public Hexagon[,] hexagons;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InitGrid();
        if (flatTopped)
            GenerateFlatHexagonalGrid();
        else GeneratePointedHexagonalGrid();
        //PrintGrid();

    }

    [ContextMenu("InitGrid")]
    public void InitGrid()
    {
        grid = new Grid(gridSize);
        hexagons = new Hexagon[gridSize.x,gridSize.y];
    }

    [ContextMenu("Print Grid")]
    public void PrintGrid()
    {
        for (int row = 0; row < gridSize.x; row++)
        {
            for (int col = 0; col < gridSize.y; col++)
            {
                Cell cell = grid.GetCell(row, col);

                Debug.Log(cell.position);
            }
        }
    }

    [ContextMenu("GeneratePointedHexagonalGrid")]
    private void GeneratePointedHexagonalGrid()
    {
        ClearGrid();
        InitGrid();


        float yOffset = cellSize * 0.75f;
        float xOffset = cellSize * Mathf.Sqrt(3f) / 2f;

        for (int row = 0; row < gridSize.x; row++)
        {
            float offset = row % 2 == 0 ? 0f : xOffset;

            for (int col = 0; col < gridSize.y; col++)
            {
                float xPos = col * xOffset * 2f + offset;
                float yPos = row * yOffset * 2f;

                Vector3 position = new Vector3(xPos, yPos, 0);
                GameObject hexagon = Instantiate(pointedHexagonPrefab, position, Quaternion.identity);

                hexagon.transform.localScale = new Vector3(prefapSize, prefapSize, prefapSize);
                hexagon.transform.SetParent(transform);
                hexagon.GetComponent<Hexagon>().SetCell(grid.GetCell(col, row));
                hexagons[row,col]= hexagon.GetComponent<Hexagon>();

            }


        }
    }

    [ContextMenu("GenerateFlatHexagonalGrid")]
    private void GenerateFlatHexagonalGrid()
    {
        ClearGrid();
        InitGrid();

        float xOffset = cellSize * 0.75f;
        float yOffset = cellSize * Mathf.Sqrt(3f) / 2f;

        for (int row = 0; row < gridSize.x; row++)
        {

            for (int col = 0; col < gridSize.y; col++)
            {
                float offset = col % 2 == 0 ? 0f : yOffset;

                float xPos = col * xOffset * 2f;
                float yPos = row * yOffset * 2f + offset;

                Vector3 position = new Vector3(xPos, yPos, 0);

                GameObject hexagon = Instantiate(flatHexagonPrefab, position, Quaternion.identity);
                hexagon.transform.localScale = new Vector3(prefapSize, prefapSize, prefapSize);
                hexagon.transform.SetParent(transform);
                hexagon.GetComponent<Hexagon>().SetCell(grid.GetCell(col, row));
                hexagons[row, col] = hexagon.GetComponent<Hexagon>();
            }
        }
    }

    [ContextMenu("ClearGrid")]
    public void ClearGrid()
    {
        int childCount = transform.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            GameObject child = transform.GetChild(i).gameObject;
            Destroy(child);
        }
    }
}


