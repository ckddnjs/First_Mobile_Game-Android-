using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image image;
    private ItemDataSet currentItem;

    public void SetItem(ItemDataSet item)
    {
        currentItem = item;
        image.sprite = item.sprite;
        image.enabled = true;
    }

    public void ClearSlot()
    {
        currentItem = null;
        image.sprite = null;
        image.enabled = false;
    }
}
