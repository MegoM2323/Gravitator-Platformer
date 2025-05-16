using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

[CreateAssetMenu]
public class SkinsBox : ScriptableObject
{
    public string itemName;
    public ItemType type;
    public float attack;
}

public enum ItemType
{
    Dagger,
    Axe,
    Sword,
    Staff
}
