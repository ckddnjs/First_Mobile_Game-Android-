using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public Transform slotParent;
    public Player player;
    public PlayerHealth pHealth;

    public List<ItemDataSet> uiItems = new List<ItemDataSet>();
    public List<GameObject> slots = new List<GameObject>();

    private void OnEnable() // 아이템 삭제도 고려
    {
        PlayerInventory.ItemAddedToInvenory += AddItemInUI;
    }

    private void OnDisable()
    {
        PlayerInventory.ItemAddedToInvenory -= AddItemInUI;
    }

    void AddItemInUI(ItemDataSet item)
    {
        uiItems.Add(item);
        GameObject slot = Instantiate(slotPrefab, slotParent);
        Image image = slot.transform.Find("ItemButton/ItemImage").GetComponent<Image>();
        image.sprite = item.sprite;

        Button button = slot.transform.Find("ItemButton").GetComponent<Button>();
        button.onClick.AddListener( () => ClickAndUseItem(item));

        if(item.itemType == ItemType.Key)
        {
            player.HasKey = true;
            Debug.Log("열쇠 얻음! 탈출구로 향하세요!");
        }

        slots.Add(slot); 
    }

    void ClickAndUseItem(ItemDataSet item)
    {
        switch (item.itemType) // 각 아이템 타입에 따른 사용 스킬 작성
        {
            case ItemType.Potion:
                bool used = pHealth.Heal();
                if(!used)
                {
                    return;
                }
                break;
            case ItemType.SpeedUp:
                Debug.Log("플레이어 속도업");
                player.ItemSpeedUp();
                break;
            case ItemType.BrightSight:
                Debug.Log("플레이어 시야밝힘");
                break;
            case ItemType.Key:
                Debug.Log("사용불가 아이템");
                return;
        }
        UpdateUI(item);
    }

    void UpdateUI(ItemDataSet item)
    {
        // 씬의 슬롯은 제거
        for (int i = 0; i < slots.Count; i++)
        {
            Image image = slots[i].transform.Find("ItemButton/ItemImage").GetComponent<Image>();
            if (image.sprite == item.sprite)
            {
                Destroy(slots[i]);
                slots.RemoveAt(i);
                break;
            }
        }
        
        // 리스트 내부의 사용한 부분만 제거 후 UI 적용
        for(int j = 0; j < uiItems.Count; j++)
        {
            if (uiItems[j] == item)
            {
                uiItems.RemoveAt(j);
                break;
            }
        }

    }

}
