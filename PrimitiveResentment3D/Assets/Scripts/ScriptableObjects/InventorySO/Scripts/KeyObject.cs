using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Key Object", menuName = "Inventory System/Items/Keys")]

public class KeyObject : ItemObject
{

    public void Awake()
    {
        type = itemType.Key;
    }

}
