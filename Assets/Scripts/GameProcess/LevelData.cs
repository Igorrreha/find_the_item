// �������� �� ������. �������������� ������� �������� ���������� �����/�������

using System;
using UnityEngine;

[Serializable]
public class LevelData
{
    [SerializeField] [Min(1)] private int _cellsCount = 1;


    public int CellsCount => _cellsCount;
}
