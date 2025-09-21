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

    private void OnEnable() // ������ ������ ���
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
            Debug.Log("���� ����! Ż�ⱸ�� ���ϼ���!");
        }

        slots.Add(slot); 
    }

    void ClickAndUseItem(ItemDataSet item)
    {
        switch (item.itemType) // �� ������ Ÿ�Կ� ���� ��� ��ų �ۼ�
        {
            case ItemType.Potion:
                bool used = pHealth.Heal();
                if(!used)
                {
                    return;
                }
                break;
            case ItemType.SpeedUp:
                Debug.Log("�÷��̾� �ӵ���");
                player.ItemSpeedUp();
                break;
            case ItemType.BrightSight:
                Debug.Log("�÷��̾� �þ߹���");
                break;
            case ItemType.Key:
                Debug.Log("���Ұ� ������");
                return;
        }
        UpdateUI(item);
    }

    void UpdateUI(ItemDataSet item)
    {
        // ���� ������ ����
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
        
        // ����Ʈ ������ ����� �κи� ���� �� UI ����
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
