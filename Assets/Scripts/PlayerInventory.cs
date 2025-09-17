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
        PrintInventory(); /// ���� �κ��丮 Ȯ���� ���� �ڵ�
    }

    public void AddItem(ItemDataSet item)
    {
        items.Add(item);
        Debug.Log(item.name + "������ ȹ��");
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
        Debug.Log("���� �κ��丮:");
        foreach (var item in items)
        {
            Debug.Log(" - " + item.itemName + " (" + item.itemType + ")");
        }
    }
}
