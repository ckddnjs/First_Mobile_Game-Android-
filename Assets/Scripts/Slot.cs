using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Button button;
    public Image icon;
    private ItemDataSet item;

    public void AddItem(ItemDataSet newItem)
    {
        item = newItem;
        icon.sprite = item.sprite;
        icon.enabled = true;

      //  button.interactable = true; //???
       // button.onClick.AddListener(OnClick);
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
       // button.interactable = false;
       // button.onClick.RemoveAllListener(); //?
    }

    public bool IsEmpty()
    {
        return item == null;
    }

    private void OnClick()
    {
        Debug.Log("아이템 클릭됨 : " + item.itemName);
    }
}
