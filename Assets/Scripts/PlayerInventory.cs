using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<ItemDataSet> items = new List<ItemDataSet>();

    public static event Action<ItemDataSet> ItemAddedToInvenory;

    public void AddItem(ItemDataSet item)
    {
        items.Add(item);
        Debug.Log(item.name + "아이템 획득"); // 여기서 메모리 누수 나옴
        ItemAddedToInvenory?.Invoke(item);
    }

    public bool HasItem(ItemType type) // 사용을 안함 @@
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
}
