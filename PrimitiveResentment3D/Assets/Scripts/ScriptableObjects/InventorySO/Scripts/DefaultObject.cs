using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Object Default", menuName = "Inventory System/Items/Default")]

public class DefaultObject : ItemObject
{
    public void Awake()
    {
        type = itemType.Item;
    }
}
