// Ячейка сетки. Контейнер для предмета (для Item-а)

using System;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    [Header("External components")]
    [SerializeField] private Item _item;
    [SerializeField] private Effect _enterAnimationEffect;

    public event Action<GridCell> OnDestroying;

    public Item Item => _item;
    public Effect EnterAnimationEffect => _enterAnimationEffect;


    public void Initialize(ItemData data)
    {
        _item.Initialize(data);
    }


    private void OnDestroy()
    {
        OnDestroying?.Invoke(this);
    }
}
