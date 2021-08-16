// —лужебный компонент дл€ инициализации €чеек (заполнени€ Item-ов данными)

using UnityEngine;

public class GridCellsFiller : MonoBehaviour
{
    [Header("External components")]
    [SerializeField] private Grid _grid;


    public void FillCells(ItemData[] itemDatas)
    {
        for (int i = 0; i < _grid.Cells.Count; i++)
        {
            int randomDataIndex = Random.Range(0, itemDatas.Length);

            FillCell(i, itemDatas[randomDataIndex]);
        }
    }


    public void FillRandomCell(ItemData data)
    {
        int randomCellIndex = Random.Range(0, _grid.Cells.Count);
        FillCell(randomCellIndex, data);
    }


    private void FillCell(int index, ItemData data)
    {
        _grid.Cells[index].Initialize(data);
    }
}
