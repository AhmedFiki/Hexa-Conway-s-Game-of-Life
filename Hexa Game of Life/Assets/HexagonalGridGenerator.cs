using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonalGridGenerator : MonoBehaviour
{
    public Vector2Int gridSize;
    public float cellSize = 1f;
    public float prefapSize = 2f;
    public bool flatTopped = false;
    public GameObject flatHexagonPrefab;
    public GameObject pointedHexagonPrefab;

    public Grid grid;


    private void Start()
    {
        if (flatTopped)
            GenerateFlatHexagonalGrid();
        else GeneratePointedHexagonalGrid();
        grid = new Grid(gridSize);

    }


    private void GeneratePointedHexagonalGrid()
    {


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
            }


        }
    }
    private void GenerateFlatHexagonalGrid()
    {
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
            }
        }
    }

}


