using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataSet", menuName = "Scriptable Objects/ItemDataSet")]
public class ItemDataSet : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public string description;
    public ItemType itemType;
}

public enum ItemType
{
    Potion, // ü�� ȸ��
    BrightSight, // �þ� ������
    SpeedUp, // �ӵ� ������
    Key // Ż�� ����
}
