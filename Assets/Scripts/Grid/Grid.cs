// Сетка для размещения ячеек

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Grid : MonoBehaviour
{
    [Header("External components")]
    [SerializeField] private GridCellsSpawner _cellsSpawner;
    private List<GridCell> _cells = new List<GridCell>();


    [Header("Events")]
    [SerializeField] private UnityEvent OnSizeReseted;


    public List<GridCell> Cells => _cells;

    
    public void SetSizeFromLevelData(LevelData levelData)
    {
        SetSize(levelData.CellsCount);
    }


    private void SetSize(int newSize)
    {
        int deltaSize = _cells.Count - newSize;

        if (deltaSize < 0)
        {
            CreateCells(-deltaSize);
        }
        else if (deltaSize > 0)
        {
            RemoveCells(deltaSize);
        }

        OnSizeReseted?.Invoke();
    }


    private void CreateCells(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _cells.Add(_cellsSpawner.Spawn().GetComponent<GridCell>());
        }
    }


    private void RemoveCells(int count)
    {
        int targetSize = _cells.Count - count;

        for (int i = _cells.Count; i > targetSize; i--)
        {
            Destroy(_cells[i - 1].gameObject);
            _cells.RemoveAt(i - 1);
        }
    }
}
