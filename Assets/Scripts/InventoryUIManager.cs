using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public Transform slotParent;
    private Slot[] slots;
    void Start()
    {
        slots = new Slot[4];
        for (int i = 0; i < slots.Length; i++)
        {
            GameObject obj = Instantiate(slotPrefab, slotParent);
            slots[i] = obj.GetComponent<Slot>();
        }
    }

    public void AddItem(ItemDataSet item)
    {
        foreach(var i in slots)
        {
            if(i != null && i.image.sprite == null)
            {
                i.SetItem(item);
                break;
            }
        }
    }
     // ������ �÷��̾ ������ ȹ�� �� �κ��丮 ������ �ִ� �κ�

    // �߰��� �÷��̾ �������� ����Ͽ� �κ��丮�� ������� �κ� �����
    void Update()
    {
        
    }
}
