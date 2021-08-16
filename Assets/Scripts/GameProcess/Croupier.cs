// " рупье", подготавливает набор предметов дл€ заполнени€ €чеек

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Croupier : MonoBehaviour
{
    [Header("External components")]
    [SerializeField] private ItemsBundlesStorage _bundlesStorage;

    private List<ItemData>[] _unusedTargetItemsBundles;
    private bool _initiated;

    private int _currentBundleIndex;


    [Header("Events")]
    public UnityEvent<ItemData[]> OnBundleForLevelPrepared;
    public UnityEvent<ItemData> OnTargetItemSelected;


    public void Initialize()
    {
        FillUnusedTargetItemsBundles();
        _initiated = true;
    }


    public void PrepareBundleForLevel()
    {
        if (!_initiated)
            Initialize();
        

        ChooseRandomBundle();

        ItemData targetItem = ExtractRandomItemFromCurrentBundle();
        targetItem.MarkAsTarget();


        ItemData[] filteredBundle = GetItemsFromBundle(_bundlesStorage.Bundles[_currentBundleIndex], targetItem);


        OnBundleForLevelPrepared?.Invoke(filteredBundle);
        OnTargetItemSelected?.Invoke(targetItem);
    }


    private void FillUnusedTargetItemsBundles()
    {
        _unusedTargetItemsBundles = _bundlesStorage.CloneBundlesToItemDataListArray();
    }


    private void ChooseRandomBundle()
    {
        int randomBundleIndex = Random.Range(0, _bundlesStorage.Bundles.Length);
        _currentBundleIndex = randomBundleIndex;
    }


    public ItemData ExtractRandomItemFromCurrentBundle()
    {
        int randomItemIndex = Random.Range(0, _unusedTargetItemsBundles[_currentBundleIndex].Count);
        ItemData extractedData = _unusedTargetItemsBundles[_currentBundleIndex][randomItemIndex];

        _unusedTargetItemsBundles[_currentBundleIndex].RemoveAt(randomItemIndex);

        return extractedData;
    }


    public ItemData[] GetItemsFromBundle(ItemBundleData itemBundleData, ItemData ignoredItem)
    {
        List<ItemData> filteredItemDatas = new List<ItemData>(itemBundleData.Items.Length);
        foreach(ItemData itemData in itemBundleData.Items)
        {
            if (itemData.Id != ignoredItem.Id)
            {
                filteredItemDatas.Add(itemData);
            }
        }

        return filteredItemDatas.ToArray();
    }
}
