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
        Debug.Log(item.name + "������ ȹ��"); // ���⼭ �޸� ���� ����
        ItemAddedToInvenory?.Invoke(item);
    }

    public bool HasItem(ItemType type) // ����� ���� @@
    {
        foreach (var i in items)
        {
            if (i.itemType == type)
            {
                return true;
            }
        }
        return false;
    } // �̰� ������ ����ϱ� �� Ȯ�� �ڵ�
}
