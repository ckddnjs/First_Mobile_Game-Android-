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
     // 위에는 플레이어가 아이템 획들 후 인벤토리 아이템 넣는 부분

    // 추가로 플레이어가 아이템을 사용하여 인벤토리가 비워지는 부분 만들기
    void Update()
    {
        
    }
}
