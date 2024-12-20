using UnityEngine;

public enum SlotTag { Damage, Decoration, Equipment, None }

[CreateAssetMenu(menuName = "Item Creator/Item")]
public class Item : ScriptableObject
{
    public SlotTag itemTag;
    public Sprite sprite;
    public string itemName;
    public int defense;
    public int damage;
}