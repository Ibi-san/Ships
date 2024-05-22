using System;
using System.Collections.Generic;
using UnityEngine;

public class Battlefield : MonoBehaviour
{
    [SerializeField] private bool _isPlayer;
    private const int GridSize = 10;
    private readonly Cell[,] _grid = new Cell[GridSize, GridSize];

    [SerializeField] private List<CellView> _cellsView = new();

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        for (int x = 0; x < GridSize; x++)
        {
            for (int y = 0; y < GridSize; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                _grid[x, y] = new Cell(coordinates);
            }
        }

        foreach (var cellView in _cellsView)
        {
            cellView.Clicked += ClickCell;
        }
    }

    private void ClickCell(CellView cellView)
    {
        int index = _cellsView.IndexOf(cellView);
        var coords = GetCoordinatesFromIndex(index);
    }

    private void PlaceShip(int size, int startX, int startY, bool horizontal)
    {
        for (int i = 0; i < size; i++)
        {
            int x = startX + (horizontal ? i : 0);
            int y = startY + (horizontal ? 0 : i);

            if (x < GridSize && y < GridSize)
            {
                _grid[x, y].SetShip();
            }
            else
            {
                Debug.LogError("Ship placement is out of bounds!");
            }
        }
    }
    
    private int GetIndexFromCoordinates(int x, int y)
    {
        return x * GridSize + y;
    }
    
    private Vector2Int GetCoordinatesFromIndex(int index)
    {
        int x = index / GridSize;
        int y = index % GridSize;
        return new Vector2Int(x, y);
    }

    public void DisableCell(int x, int y)
    {
        int cellIndex = GetIndexFromCoordinates(x, y);
        _cellsView[cellIndex].gameObject.SetActive(false);
    }
}