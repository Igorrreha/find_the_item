// ScriptableObject ��� �������� ������������ ������ ��������� � ���������

using UnityEngine;

[CreateAssetMenu(fileName = "ItemBundleData", menuName = "Items/Item Bundle Data", order = 10)]
public class ItemBundleData : ScriptableObject
{
    [SerializeField] private ItemData[] _items;


    public ItemData[] Items => _items;


    private void Awake()
    {
        if (_items.Length < 2)
        {
            throw new UnityException("ItemBundleData can't contain less than 2 items");
        }
    }
}
