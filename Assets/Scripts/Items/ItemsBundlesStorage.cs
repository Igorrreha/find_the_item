using System.Collections.Generic;
using UnityEngine;

public class ItemsBundlesStorage : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private ItemBundleData[] _bundles;


    public ItemBundleData[] Bundles => _bundles;


    public List<ItemData>[] CloneBundlesToItemDataListArray()
    {
        List<ItemData>[] result = new List<ItemData>[_bundles.Length];
        for (int i = 0; i < _bundles.Length; i++)
        {
            result[i] = new List<ItemData>(_bundles[i].Items.Length);
            foreach (ItemData itemData in _bundles[i].Items)
            {
                result[i].Add(itemData.Clone());
            }
        }

        return result;
    }
}
