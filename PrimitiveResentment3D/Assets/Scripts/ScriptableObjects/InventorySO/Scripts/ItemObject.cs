using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum itemType
{
    Item,
    Key,
    Log
}

public abstract class ItemObject : ScriptableObject
{

    public GameObject prefab;
    public itemType type;
    [TextArea (15, 20)]
    public string description;

}
