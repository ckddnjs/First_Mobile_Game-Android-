using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataSet", menuName = "Scriptable Objects/ItemDataSet")]
public class ItemDataSet : ScriptableObject
{
    public string itemName;
    public GameObject prefab;
    public string description;
    public ItemType itemType;
}

public enum ItemType
{
    Potion, // 체력 회복
    BrightSight, // 시야 밝히기
    SpeedUp, // 속도 높히기
    Key // 탈출 열쇠
}
