// Набор свойств для отрисовки Item-а

using System;
using UnityEngine;

[Serializable]
public struct ItemRenderData
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] [Range(-180, 180)] private float _rotation;
    [SerializeField] private bool _flipH;
    [SerializeField] private bool _flipV;

    public Sprite Sprite => _sprite;
    public float Rotation => _rotation;
    public bool FlipH => _flipH;
    public bool FlipV => _flipV;
}
