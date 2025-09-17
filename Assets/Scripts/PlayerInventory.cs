using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<ItemDataSet> items = new List<ItemDataSet>();
    void Start()
    {
        
    }

    void Update()
    {
        PrintInventory(); /// 단지 인벤토리 확인을 위한 코드
    }

    public void AddItem(ItemDataSet item)
    {
        items.Add(item);
        Debug.Log(item.name + "아이템 획득");
    }

    public bool HasItem(ItemType type)
    {
        foreach(var i in items)
        {
            if(i.itemType == type)
            {
                return true;
            }
        } 
        return false;
    }

    public void PrintInventory()
    {
        Debug.Log("현재 인벤토리:");
        foreach (var item in items)
        {
            Debug.Log(" - " + item.itemName + " (" + item.itemType + ")");
        }
    }
}
