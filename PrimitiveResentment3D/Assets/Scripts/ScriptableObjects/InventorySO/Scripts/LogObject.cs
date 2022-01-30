using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Log Object", menuName = "Inventory System/Items/Logs")]

public class LogObject : ItemObject
{
    private void Awake()
    {
        type = itemType.Log;
    }
}
