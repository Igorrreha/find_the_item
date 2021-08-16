// Набор изменяемых свойств Item-а

using System;
using UnityEngine;

[Serializable]
public class ItemData
{
    [SerializeField] private string _id;
    [SerializeField] private ItemRenderData _renderData;
    private bool _isTarget;


    public string Id => _id;
    public ItemRenderData RenderData => _renderData;
    public bool IsTarget => _isTarget;


    public ItemData(string id, ItemRenderData renderData)
    {
        _id = id;
        _renderData = renderData;
    }


    public ItemData Clone()
    {
        return new ItemData(_id, _renderData);
    }


    public void MarkAsTarget()
    {
        _isTarget = true;
    }


    public override string ToString()
    {
        return this._id;
    }
}
