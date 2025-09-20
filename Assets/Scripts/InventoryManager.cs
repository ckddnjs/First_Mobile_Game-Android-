using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public Transform slotParent;

    private List<Slot> slots = new List<Slot>();

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject slotObj = Instantiate(slotPrefab, slotParent);
            Slot slot = slotObj.GetComponent<Slot>();
            slots.Add(slot);
        }   
    }

    public void UpdateInventoryUI(ItemDataSet newItem)
    {
        foreach(var slot in slots)
        {
            if(slot.IsEmpty())
            {
                slot.AddItem(newItem);
                break;
            }
        }
    }

    void Update()
    {
        
    }
}
