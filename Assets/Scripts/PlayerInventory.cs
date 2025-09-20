using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<ItemDataSet> items = new List<ItemDataSet>();

    public InventoryManager inventoryManager;

    void Update()
    {
        //PrintInventory(); /// 단지 인벤토리 확인을 위한 코드
    }

    public void AddItem(ItemDataSet item)
    {
        items.Add(item);
        Debug.Log(item.name + "아이템 획득");

        if(inventoryManager != null)
        {
            inventoryManager.UpdateInventoryUI(item);
        }
    }

    public bool HasItem(ItemType type)
    {
        foreach (var i in items)
        {
            if (i.itemType == type)
            {
                return true;
            }
        }
        return false;
    } // 이건 아이템 사용하기 전 확인 코드

    //public void PrintInventory()
    //{
    //    Debug.Log("현재 인벤토리:");
    //    foreach (var item in items)
    //    {
    //        Debug.Log(" - " + item.itemName + " (" + item.itemType + ")");
    //    }
    //}
}
