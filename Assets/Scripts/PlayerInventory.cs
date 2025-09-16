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
        
    }

    public void AddItem(ItemDataSet item)
    {
        items.Add(item);
        Debug.Log(item.name + "æ∆¿Ã≈€ »πµÊ");
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
}
